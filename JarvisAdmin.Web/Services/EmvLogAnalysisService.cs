using System.Globalization;
using System.Text.RegularExpressions;

namespace JarvisAdmin.Web.Services;

// Reads the two EMV log files the Jarvis2024 app writes on the production server (App_Data) -
// paymentservice.log (PaymentService: terminal calls to Valor, MakeEMVPayment, RecordEMVPayment)
// and posregister.log (the POS register page: InsertPOSTransactionForRegisterEmv, MakeEMVPayment
// ENTRY/EXIT, CompletePOSTransactionAfterEmv) - and, for a payment that is in MX Merchant but has
// no payment row in Jarvis, finds the terminal sale attempt(s) behind it, builds a timeline across
// both logs and works out from the logged outcome why Jarvis never recorded it.
//
// How the logs tie together:
// - paymentservice.log: one "[ProcessTerminalSale] Start req_txn_id=<base>_<suffix>" per terminal
//   attempt. Lines carry req_txn_id/uniqueTxnId/reqTxnId or the terminal's epi; the REQUEST_JSON
//   body carries ORDER_ID ("POS-<txnKey>" for the register). The MakeEMVPayment outcome block
//   ("===== START: PAYMENTSERVICE" .. " End of ...") has no ids except "GroupId=<base>", and is
//   written in a single burst, so it's attached to the latest finished attempt with that base.
// - posregister.log: every line ends with sessionId=; InsertPOSTransactionForRegisterEmv SUCCESS
//   gives the txnKey, and later lines in the same session belong to that sale. EXIT_OK's returnClip
//   carries RegistrationNbr/ValorTxnId on approval.
// - RegistrationNbr is the Valor RRN. It's only ever logged once Jarvis has received an approval, so
//   for an unrecorded payment it usually isn't in either log - the match then falls back to amount +
//   time. The RRN itself encodes the UTC processing date/hour (Y DDD HH nnnnnn), which is used both to
//   widen the search and to sanity-check each candidate.
public class EmvLogAnalysisService(IConfiguration configuration, IWebHostEnvironment environment)
{
    private const string PaymentServiceLogName = "paymentservice";
    private const string PosRegisterLogName = "posregister";
    private const int MaxCandidates = 20;

    private static readonly TimeSpan CandidateWindow = TimeSpan.FromMinutes(15);
    private static readonly TimeSpan RetryGap = TimeSpan.FromMinutes(5);

    private static readonly Regex LineRx = new(@"^(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3}) \| ?(.*)$", RegexOptions.Compiled);
    private static readonly Regex StartRx = new(@"\[ProcessTerminalSale\] Start req_txn_id=(\S+) \(base=(\S+)\) epi=(\S+) amount=([\d.]+)", RegexOptions.Compiled);
    private static readonly Regex TxnIdRx = new(@"(?:uniqueTxnId|reqTxnId|req_txn_id)=(?<req>[\w-]+)|""REQ_TXN_ID"":\s*""(?<req>[\w-]+)""|""MER_TXN_ID"":\s*""(?<mer>[\w-]+)""", RegexOptions.Compiled);
    private static readonly Regex EpiRx = new(@"\bepi=(\d+)", RegexOptions.Compiled);
    private static readonly Regex GroupIdRx = new(@"\[MakeEMVPayment\] Initialize\w* ms\. GroupId=(\S+)", RegexOptions.Compiled);
    private static readonly Regex OrderIdRx = new(@"""ORDER_ID"":\s*""([^""]*)""", RegexOptions.Compiled);
    private static readonly Regex PosOrderRx = new(@"^POS-(\d+)$", RegexOptions.Compiled);
    private static readonly Regex RegistrationNbrRx = new(@"RegistrationNbr=(\d+)|""RegistrationNbr"":""(\d+)""", RegexOptions.Compiled);
    private static readonly Regex ValorTxnIdRx = new(@"""TXN_ID"":""(\d+)""|""ValorTxnId"":""(\d+)""", RegexOptions.Compiled);
    private static readonly Regex ElapsedRx = new(@"elapsedMs=(\d+)", RegexOptions.Compiled);
    private static readonly Regex DeclineMessageRx = new(@"message=(.*?) vl\d+=", RegexOptions.Compiled);
    private static readonly Regex ErrorMsgRx = new(@"ErrorMsg=(.*?) ErrorCode=(\S*)", RegexOptions.Compiled);
    private static readonly Regex LookupErrorRx = new(@"VALOR_ERROR error_no=(\S+) msg=(.*?) desc=(.*?) body=", RegexOptions.Compiled);
    private static readonly Regex RequestStartUtcRx = new(@"requestStartUtc=(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})", RegexOptions.Compiled);
    private static readonly Regex SessionIdRx = new(@"sessionId=(\S+)", RegexOptions.Compiled);
    private static readonly Regex TxnKeyRx = new(@"txnKey=(\d+)", RegexOptions.Compiled);
    private static readonly Regex TotalDueRx = new(@"totalDue=([\d.]+)", RegexOptions.Compiled);
    private static readonly Regex UserRx = new(@"\buser=(\S+)", RegexOptions.Compiled);
    private static readonly Regex OrgRx = new(@"\borg=(\d+)", RegexOptions.Compiled);
    private static readonly Regex ShiftRx = new(@"\bshift=(\d+)", RegexOptions.Compiled);
    private static readonly Regex ReturnClipRx = new(@"returnClip=(.*?) user=", RegexOptions.Compiled);
    private static readonly Regex AppIdRx = new(@"(""appid"":\s*""|AppId=|appid=)[^""\s]+", RegexOptions.Compiled);
    private static readonly Regex WhitespaceRx = new(@"\s+", RegexOptions.Compiled);
    private static readonly Regex ProblemRx = new(@"EXCEPTION|ERROR|FAIL|DECLINED|NO_MATCH|WARNING|Timeout/Cancelled|Timeout\/Cancelled|E_TIMEOUT|In progress|could not confirm|End of Error|ALREADY_CLAIMED|S00 but STATE", RegexOptions.Compiled);
    private static readonly Regex GoodRx = new(@"\] SUCCESS|\] APPROVED|After RecordEMVPayment|End of Approved|""ReturnResponse"":""Approved""|approved=True|CompletePOSTransactionAfterEmv SUCCESS|InsertPOSTransactionForRegisterEmv SUCCESS", RegexOptions.Compiled);

    private sealed class LogEntry(DateTime timestamp, string log, int lineNumber, string text)
    {
        public DateTime Timestamp { get; } = timestamp;
        public string Log { get; } = log;
        public int LineNumber { get; } = lineNumber;
        public string Text { get; set; } = text;
    }

    private sealed class Attempt
    {
        public required string ReqTxnId { get; init; }
        public required string BaseId { get; init; }
        public required string Epi { get; init; }
        public decimal Amount { get; init; }
        public DateTime Start { get; init; }
        public string? OrderId { get; set; }
        public string? RegistrationNbr { get; set; }
        public string? ValorTxnId { get; set; }
        public bool InOutcomeBlock { get; set; }
        public bool Ended { get; set; }
        // Set when a later request on the terminal was refused because this sale was still running on it.
        public (LogEntry Entry, Attempt Requester)? StillInProgressReport { get; set; }
        public Attempt? BlockedBy { get; set; }
        public string? Org { get; set; }
        public RegisterSale? Sale { get; set; }
        public List<LogEntry> Entries { get; } = [];
        // Entries are appended in log order.
        public DateTime LastTimestamp => Entries.Count > 0 ? Entries[^1].Timestamp : Start;
        public bool Has(string s) => Entries.Any(e => e.Text.Contains(s, StringComparison.Ordinal));
        public LogEntry? Find(string s) => Entries.FirstOrDefault(e => e.Text.Contains(s, StringComparison.Ordinal));
    }

    private sealed class RegisterSale
    {
        public required string SessionId { get; init; }
        public int? TxnKey { get; set; }
        public decimal? TotalDue { get; set; }
        public int? ShiftKey { get; set; }
        public string? User { get; set; }
        public string? Org { get; set; }
        public Dictionary<string, string?> RegistrationNbrs { get; } = [];
        public List<LogEntry> Entries { get; } = [];
    }


    // Time zones the entered date/time can be in (Windows time zone ids - DST handled per date). A null
    // LogTimeZoneId means the time is already in log (server) time.
    public static readonly IReadOnlyList<EmvTimeZoneOption> TimeZones =
    [
        new("Eastern Standard Time", "Eastern"),
        new("Central Standard Time", "Central"),
        new("Mountain Standard Time", "Mountain"),
        new("US Mountain Standard Time", "Arizona (no DST)"),
        new("Pacific Standard Time", "Pacific"),
        new("UTC", "UTC"),
        new(LogTimeZoneId, "Log time (no conversion)"),
    ];

    public const string DefaultTimeZoneId = "Central Standard Time";
    public const string LogTimeZoneId = "Log";

    public Task<EmvAnalysisResult> AnalyzeAsync(int organizationKey, DateTime enteredInZone, string? enteredTimeZoneId, decimal amount, string referenceNbr, IReadOnlyList<ReferenceNbrDetailRow> jarvisRows)
        => Task.Run(() => Analyze(organizationKey, enteredInZone, enteredTimeZoneId, amount, referenceNbr.Trim(), jarvisRows));

    private EmvAnalysisResult Analyze(int organizationKey, DateTime enteredInZone, string? enteredTimeZoneId, decimal amount, string referenceNbr, IReadOnlyList<ReferenceNbrDetailRow> jarvisRows)
    {
        var folder = configuration["EmvLogs:Folder"] ?? "JarvisData/EMVLogs";
        if (!Path.IsPathRooted(folder))
            folder = Path.Combine(environment.ContentRootPath, folder);

        var paymentServicePath = Path.Combine(folder, configuration["EmvLogs:PaymentServiceLog"] ?? "paymentservice.log");
        var posRegisterPath = Path.Combine(folder, configuration["EmvLogs:PosRegisterLog"] ?? "posregister.log");

        var missing = new[] { paymentServicePath, posRegisterPath }.Where(p => !File.Exists(p)).ToList();
        if (missing.Count > 0)
            return new EmvAnalysisResult($"Log file not found: {string.Join(", ", missing)}", null, [], []);

        var paymentEntries = ReadLog(paymentServicePath, PaymentServiceLogName);
        var registerEntries = ReadLog(posRegisterPath, PosRegisterLogName);

        var allAttempts = ParsePaymentService(paymentEntries);
        var allSales = ParseRegister(registerEntries);
        LinkAttemptsToSales(allAttempts, allSales);
        AssignOrganizations(allAttempts);

        // Only the selected organization's sales are searched from here on.
        var org = organizationKey.ToString(CultureInfo.InvariantCulture);
        var attempts = allAttempts.Where(a => a.Org == org).ToList();
        var sales = allSales.Where(s => s.Org == org).ToList();

        var coverage = $"paymentservice.log {DescribeRange(paymentEntries)}; posregister.log {DescribeRange(registerEntries)}";
        var general = new List<EmvFinding>();

        var unknownOrg = allAttempts.Count(a => a.Org is null);
        general.Add(new(EmvFindingSeverity.Info,
            $"Searching only organization {org}: {attempts.Count} of {allAttempts.Count} terminal sale attempts in the logs belong to it" +
            (unknownOrg > 0 ? $" ({unknownOrg} attempt(s) could not be tied to any organization and are skipped)." : ".")));

        var otherOrgHit = allAttempts.FirstOrDefault(a => a.Org != org && a.RegistrationNbr == referenceNbr)
            ?? allAttempts.FirstOrDefault(a => a.Org != org && a.Sale?.RegistrationNbrs.ContainsKey(referenceNbr) == true);
        if (otherOrgHit is not null)
            general.Add(new(EmvFindingSeverity.Warning,
                $"RegistrationNbr {referenceNbr} is in the logs under organization {otherOrgHit.Org ?? "(unknown)"} ({otherOrgHit.Start:MM/dd/yyyy h:mm tt}), not the selected organization."));

        if (jarvisRows.Count > 0)
            general.Add(new(EmvFindingSeverity.Warning,
                $"Jarvis DOES have {jarvisRows.Count} payment row(s) with RegistrationNbr {referenceNbr} ({string.Join(", ", jarvisRows.Select(r => $"{r.SourceTable} {r.PaymentAmount:C} on {r.PaymentDate:MM/dd/yyyy h:mm tt}"))}). The payment was recorded - check its amount/batch stamping rather than why it is missing."));
        else
            general.Add(new(EmvFindingSeverity.Info, $"Confirmed: no Jarvis payment table has a row with RegistrationNbr {referenceNbr}."));

        // The log timestamps are server-local; requestStartUtc lines give the server's UTC offset.
        var utcOffset = FindUtcOffset(paymentEntries, enteredInZone);
        var enteredTime = ToLogTime(enteredInZone, enteredTimeZoneId, utcOffset, general);
        var rrnLocalHour = DecodeRrnHour(referenceNbr, enteredTime, utcOffset, general);

        var directMatches = FindByRegistrationNbr(referenceNbr, attempts, sales);
        var registerOnly = sales
            .Where(s => s.RegistrationNbrs.ContainsKey(referenceNbr))
            .SelectMany(s => s.Entries.Where(e => e.Text.Contains(referenceNbr, StringComparison.Ordinal)))
            .FirstOrDefault();
        if (directMatches.Count > 0)
            general.Add(new(EmvFindingSeverity.Info, $"RegistrationNbr {referenceNbr} appears in the logs - Jarvis did receive an approval for it."));
        else if (registerOnly is not null)
            general.Add(new(EmvFindingSeverity.Warning,
                $"RegistrationNbr {referenceNbr} appears in posregister.log at {registerOnly.Timestamp:MM/dd/yyyy h:mm:ss tt} - the register was told the sale was approved - but its terminal request isn't in paymentservice.log (it is probably from before the log starts). Line: {registerOnly.Text}"));
        else
            general.Add(new(EmvFindingSeverity.Info,
                $"RegistrationNbr {referenceNbr} does not appear in either log. Jarvis only logs it after it receives an approval, so Jarvis never saw this sale as approved. Searching by amount {amount:C} within {CandidateWindow.TotalMinutes:0} minutes of {enteredTime:MM/dd/yyyy h:mm tt}" +
                (rrnLocalHour.HasValue ? $" and within the RRN hour ({rrnLocalHour:h:mm tt} - {rrnLocalHour.Value.AddHours(1):h:mm tt} server time)." : ".")));

        var windowMatches = attempts.Where(a => a.Amount == amount &&
            ((a.Start - enteredTime).Duration() <= CandidateWindow ||
             (rrnLocalHour.HasValue && a.Start >= rrnLocalHour.Value.AddMinutes(-5) && a.Start < rrnLocalHour.Value.AddMinutes(65))))
            .ToList();

        // Nothing near the time: the sale may have been started in Jarvis at one time and only reached
        // MX much later, so drop the time - first any time on the entered date, then any date in the logs.
        if (directMatches.Count == 0 && windowMatches.Count == 0)
        {
            windowMatches = attempts.Where(a => a.Amount == amount && a.Start.Date == enteredTime.Date).ToList();
            if (windowMatches.Count > 0)
                general.Add(new(EmvFindingSeverity.Warning,
                    $"No {amount:C} sale was found near {enteredTime:h:mm tt}, so the time was dropped: showing {windowMatches.Count} {amount:C} sale attempt(s) at any time on {enteredTime:MM/dd/yyyy} (log time)."));
            else
            {
                windowMatches = attempts.Where(a => a.Amount == amount).ToList();
                if (windowMatches.Count > 0)
                    general.Add(new(EmvFindingSeverity.Warning,
                        $"No {amount:C} sale was found on {enteredTime:MM/dd/yyyy}, so the date and time were dropped: showing {amount:C} sale attempts on any date in the logs ({windowMatches.Count} found{(windowMatches.Count > MaxCandidates ? $", the {MaxCandidates} most likely shown" : "")})."));
            }
        }


        var candidates = directMatches
            .Concat(windowMatches.Where(a => !directMatches.Contains(a))
                .OrderBy(a => Likelihood(a, referenceNbr))
                .ThenBy(a => (a.Start - enteredTime).Duration()))
            .Take(MaxCandidates)
            .Select(a => BuildCandidate(a, attempts, enteredTime, amount, referenceNbr, directMatches.Contains(a), rrnLocalHour))
            .ToList();

        if (candidates.Count == 0)
            general.Add(new(EmvFindingSeverity.Problem,
                $"No terminal sale for {amount:C} was found for this organization on any date in the logs. Check that the amount is the card amount and that the date falls inside the log coverage. A sale that never went through this server's EMV flow (e.g. an online card payment) will not appear in these logs."));

        return new EmvAnalysisResult(null, coverage, general, candidates);
    }

    private static List<LogEntry> ReadLog(string path, string logName)
    {
        var entries = new List<LogEntry>();
        // The production app may still be appending to the file.
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
        using var reader = new StreamReader(stream);

        LogEntry? current = null;
        var lineNumber = 0;
        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            lineNumber++;
            var m = LineRx.Match(line);
            if (m.Success && DateTime.TryParseExact(m.Groups[1].Value, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out var ts))
            {
                current = new LogEntry(ts, logName, lineNumber, m.Groups[2].Value);
                entries.Add(current);
            }
            else if (current is not null && !string.IsNullOrWhiteSpace(line))
            {
                // Multi-line REQUEST_JSON bodies - fold them into the line that started them.
                current.Text += " " + line.Trim();
            }
        }

        return entries;
    }

    private static List<Attempt> ParsePaymentService(List<LogEntry> entries)
    {
        var attempts = new List<Attempt>();
        var byTxnId = new Dictionary<string, Attempt>();
        var openByEpi = new Dictionary<string, Attempt>();
        var pendingPrefix = new List<LogEntry>();
        var pendingBlock = new List<LogEntry>();
        Attempt? lookupAttempt = null;
        Attempt? blockAttempt = null;

        foreach (var e in entries)
        {
            var text = e.Text;

            // Refunds run through the same terminals but are not sales.
            if (text.StartsWith("[ProcessTerminalRefund]", StringComparison.Ordinal) || text.StartsWith("[CheckBatchStatus]", StringComparison.Ordinal)
                || text.StartsWith("[ProcessEMVRefund]", StringComparison.Ordinal) || text.StartsWith("[InitializeValorTerminalRefund", StringComparison.Ordinal)
                || text.StartsWith("----- START PROCESSTERMINALREFUND", StringComparison.Ordinal))
                continue;

            var start = StartRx.Match(text);
            if (start.Success)
            {
                var attempt = new Attempt
                {
                    ReqTxnId = start.Groups[1].Value,
                    BaseId = start.Groups[2].Value,
                    Epi = start.Groups[3].Value,
                    Amount = decimal.Parse(start.Groups[4].Value, CultureInfo.InvariantCulture),
                    Start = e.Timestamp,
                };
                attempt.Entries.AddRange(pendingPrefix.Where(p => (e.Timestamp - p.Timestamp).TotalSeconds <= 2));
                attempt.Entries.Add(e);
                pendingPrefix.Clear();

                attempts.Add(attempt);
                byTxnId[attempt.ReqTxnId] = attempt;
                openByEpi[attempt.Epi] = attempt;
                continue;
            }

            if (text.StartsWith("[Initialize", StringComparison.Ordinal) && !text.Contains("After Process", StringComparison.Ordinal)
                || text.StartsWith("----- START PROCESSTERMINALSALE", StringComparison.Ordinal))
            {
                pendingPrefix.Add(e);
                continue;
            }

            if (text.StartsWith("[Initialize", StringComparison.Ordinal) || text.StartsWith("===== START: PAYMENTSERVICE", StringComparison.Ordinal))
            {
                pendingBlock.Add(e);
                blockAttempt = null;
                continue;
            }

            var group = GroupIdRx.Match(text);
            if (group.Success)
            {
                // Several terminals can share a base (GroupId), so pick the one whose terminal phase just
                // finished - the outcome block is written immediately after its last terminal/lookup line.
                var groupId = group.Groups[1].Value;
                blockAttempt = attempts
                    .Skip(Math.Max(0, attempts.Count - 50))
                    .Where(a => a.BaseId == groupId && !a.InOutcomeBlock && e.Timestamp - a.LastTimestamp <= RetryGap)
                    .MaxBy(a => a.LastTimestamp);
                if (blockAttempt is not null)
                {
                    blockAttempt.InOutcomeBlock = true;
                    blockAttempt.Entries.AddRange(pendingBlock.Where(p => (e.Timestamp - p.Timestamp).TotalSeconds <= 2));
                    blockAttempt.Entries.Add(e);
                    if (openByEpi.TryGetValue(blockAttempt.Epi, out var open) && open == blockAttempt)
                        openByEpi.Remove(blockAttempt.Epi);
                }
                pendingBlock.Clear();
                continue;
            }

            if (blockAttempt is not null && (text.StartsWith("[MakeEMVPayment]", StringComparison.Ordinal)
                || text.Contains(" End of ", StringComparison.Ordinal) || text.StartsWith("End of ", StringComparison.Ordinal)
                || text.StartsWith("===== END: PAYMENTSERVICE", StringComparison.Ordinal)))
            {
                blockAttempt.Entries.Add(e);
                if (text.Contains("End of ", StringComparison.Ordinal))
                    blockAttempt.Ended = true;
                var reg = RegistrationNbrRx.Match(text);
                if (reg.Success)
                    blockAttempt.RegistrationNbr = reg.Groups[1].Value;
                if (text.StartsWith("===== END", StringComparison.Ordinal))
                    blockAttempt = null;
                continue;
            }

            // Prefer the requesting attempt's id. Valor's "in progress" answer names both the request it
            // refused (REQ_TXN_ID) and the sale still running on the terminal (MER_TXN_ID) - the line
            // belongs to the requester, and the running sale is flagged as still live at that moment.
            Attempt? target = null;
            Attempt? merAttempt = null;
            foreach (Match m in TxnIdRx.Matches(text))
            {
                if (target is null && m.Groups["req"].Success)
                    byTxnId.TryGetValue(m.Groups["req"].Value, out target);
                if (merAttempt is null && m.Groups["mer"].Success)
                    byTxnId.TryGetValue(m.Groups["mer"].Value, out merAttempt);
            }

            if (target is null)
                target = merAttempt;
            else if (merAttempt is not null && merAttempt != target && text.Contains("In progress", StringComparison.OrdinalIgnoreCase))
            {
                merAttempt.StillInProgressReport ??= (e, target);
                target.BlockedBy = merAttempt;
            }

            if (target is null && text.StartsWith("[LookupTerminalSaleAfterTimeout]", StringComparison.Ordinal))
                target = lookupAttempt;

            if (target is null)
            {
                var epi = EpiRx.Match(text);
                if (epi.Success)
                    openByEpi.TryGetValue(epi.Groups[1].Value, out target);
            }

            if (target is null)
                continue;

            target.Entries.Add(e);

            if (text.StartsWith("[LookupTerminalSaleAfterTimeout] Start", StringComparison.Ordinal))
                lookupAttempt = target;

            var order = OrderIdRx.Match(text);
            if (order.Success)
                target.OrderId = order.Groups[1].Value;

            var valor = ValorTxnIdRx.Match(text);
            if (valor.Success && target.ValorTxnId is null)
                target.ValorTxnId = valor.Groups[1].Value;
        }

        return attempts;
    }

    private static List<RegisterSale> ParseRegister(List<LogEntry> entries)
    {
        var sales = new List<RegisterSale>();
        var currentBySession = new Dictionary<string, RegisterSale>();
        var byTxnKey = new Dictionary<int, RegisterSale>();

        foreach (var e in entries)
        {
            var session = SessionIdRx.Match(e.Text);
            if (!session.Success)
                continue;
            var sessionId = session.Groups[1].Value;

            RegisterSale? sale = null;
            var txnKeyMatch = TxnKeyRx.Match(e.Text);
            var txnKey = txnKeyMatch.Success ? int.Parse(txnKeyMatch.Groups[1].Value, CultureInfo.InvariantCulture) : (int?)null;

            if (e.Text.StartsWith("InsertPOSTransactionForRegisterEmv START", StringComparison.Ordinal))
            {
                sale = new RegisterSale { SessionId = sessionId };
                sales.Add(sale);
                currentBySession[sessionId] = sale;
            }
            else if (txnKey.HasValue && byTxnKey.TryGetValue(txnKey.Value, out var known))
            {
                sale = known;
            }
            else if (!currentBySession.TryGetValue(sessionId, out sale))
            {
                sale = new RegisterSale { SessionId = sessionId };
                sales.Add(sale);
                currentBySession[sessionId] = sale;
            }

            sale.Entries.Add(e);

            if (txnKey.HasValue && sale.TxnKey is null)
            {
                sale.TxnKey = txnKey;
                byTxnKey[txnKey.Value] = sale;
            }

            var shift = ShiftRx.Match(e.Text);
            if (shift.Success)
                sale.ShiftKey = int.Parse(shift.Groups[1].Value, CultureInfo.InvariantCulture);

            var totalDue = TotalDueRx.Match(e.Text);
            if (totalDue.Success)
                sale.TotalDue = decimal.Parse(totalDue.Groups[1].Value, CultureInfo.InvariantCulture);

            var user = UserRx.Match(e.Text);
            if (user.Success)
                sale.User = user.Groups[1].Value;

            var org = OrgRx.Match(e.Text);
            if (org.Success)
                sale.Org = org.Groups[1].Value;

            var reg = RegistrationNbrRx.Match(e.Text);
            if (reg.Success)
            {
                var valor = ValorTxnIdRx.Match(e.Text);
                sale.RegistrationNbrs[reg.Groups[2].Success ? reg.Groups[2].Value : reg.Groups[1].Value] = valor.Success ? valor.Groups[2].Value : null;
            }
        }

        return sales;
    }

    private static void LinkAttemptsToSales(List<Attempt> attempts, List<RegisterSale> sales)
    {
        var byTxnKey = sales.Where(s => s.TxnKey.HasValue).GroupBy(s => s.TxnKey!.Value).ToDictionary(g => g.Key, g => g.First());
        var byValorTxnId = sales
            .SelectMany(s => s.RegistrationNbrs.Values.Where(v => v is not null).Select(v => (ValorTxnId: v!, Sale: s)))
            .GroupBy(x => x.ValorTxnId)
            .ToDictionary(g => g.Key, g => g.First().Sale);

        foreach (var a in attempts)
        {
            var pos = PosOrderRx.Match(a.OrderId ?? "");
            if (pos.Success && byTxnKey.TryGetValue(int.Parse(pos.Groups[1].Value, CultureInfo.InvariantCulture), out var sale))
                a.Sale = sale;
            else if (a.ValorTxnId is not null && byValorTxnId.TryGetValue(a.ValorTxnId, out var byValor))
                a.Sale = byValor;
        }
    }

    // An attempt's organization comes from its register sale, else from the org= on its CARD_DECLINED
    // / AMEX_CHECK line. An approved non-register sale (registration, membership...) logs no org at
    // all, so it falls back to its terminal: each terminal (EPI) belongs to one organization, which the
    // terminal's other attempts reveal.
    private static void AssignOrganizations(List<Attempt> attempts)
    {
        foreach (var a in attempts)
            a.Org = a.Sale?.Org ?? a.Entries.Select(e => OrgRx.Match(e.Text)).FirstOrDefault(m => m.Success)?.Groups[1].Value;

        var orgByEpi = attempts
            .Where(a => a.Org is not null)
            .GroupBy(a => a.Epi)
            .ToDictionary(g => g.Key, g => g.GroupBy(a => a.Org!).MaxBy(o => o.Count())!.Key);

        foreach (var a in attempts.Where(a => a.Org is null))
            a.Org = orgByEpi.GetValueOrDefault(a.Epi);
    }

    private static List<Attempt> FindByRegistrationNbr(string referenceNbr, List<Attempt> attempts, List<RegisterSale> sales)
    {
        var found = attempts.Where(a => a.RegistrationNbr == referenceNbr).ToList();

        foreach (var sale in sales.Where(s => s.RegistrationNbrs.ContainsKey(referenceNbr)))
        {
            var valorTxnId = sale.RegistrationNbrs[referenceNbr];
            var linked = attempts.Where(a => a.Sale == sale && (valorTxnId is null || a.ValorTxnId == valorTxnId)).ToList();
            found.AddRange(linked.Where(a => !found.Contains(a)));
        }

        return found;
    }

    private static TimeSpan? FindUtcOffset(List<LogEntry> entries, DateTime near)
    {
        var withUtc = entries
            .Where(e => e.Text.Contains("requestStartUtc=", StringComparison.Ordinal))
            .Select(e => (Entry: e, Match: RequestStartUtcRx.Match(e.Text)))
            .Where(x => x.Match.Success)
            .ToList();
        if (withUtc.Count == 0)
            return null;

        var best = withUtc.MinBy(x => (x.Entry.Timestamp - near).Duration());

        var utc = DateTime.ParseExact(best.Match.Groups[1].Value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        // The lookup line is written up to ~75s after the request started, so round to the half hour.
        var minutes = Math.Round((best.Entry.Timestamp - utc).TotalMinutes / 30) * 30;
        return TimeSpan.FromMinutes(minutes);
    }

    // Converts the entered time from the selected time zone to log time: to UTC through the time
    // zone's rules for that date, then to log time with the server offset read from the logs.
    private static DateTime ToLogTime(DateTime enteredInZone, string? timeZoneId, TimeSpan? logUtcOffset, List<EmvFinding> findings)
    {
        if (timeZoneId is null or LogTimeZoneId)
            return enteredInZone;

        if (logUtcOffset is null)
        {
            findings.Add(new(EmvFindingSeverity.Warning,
                "The logs' UTC offset could not be determined (no requestStartUtc lines), so the entered time was used as log time without conversion."));
            return enteredInZone;
        }

        var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        var utc = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(enteredInZone, DateTimeKind.Unspecified), zone);
        var logTime = utc + logUtcOffset.Value;
        var zoneOffset = zone.GetUtcOffset(enteredInZone);
        var label = TimeZones.FirstOrDefault(z => z.Id == timeZoneId)?.Label ?? timeZoneId;

        findings.Add(new(EmvFindingSeverity.Info,
            $"Entered time {enteredInZone:MM/dd/yyyy h:mm tt} {label} (UTC{FormatOffset(zoneOffset)}) = {logTime:MM/dd/yyyy h:mm tt} log time (UTC{FormatOffset(logUtcOffset.Value)}). All times below are log time."));
        return logTime;
    }

    private static string FormatOffset(TimeSpan offset) => $"{(offset < TimeSpan.Zero ? "-" : "+")}{offset.Duration():h\\:mm}";

    // RRN layout: Y DDD HH nnnnnn - last digit of the year, day of year and hour, all UTC.
    private static DateTime? DecodeRrnHour(string referenceNbr, DateTime enteredTime, TimeSpan? utcOffset, List<EmvFinding> findings)
    {
        if (referenceNbr.Length != 12 || !referenceNbr.All(char.IsDigit))
            return null;

        var yearDigit = referenceNbr[0] - '0';
        var dayOfYear = int.Parse(referenceNbr.AsSpan(1, 3), CultureInfo.InvariantCulture);
        var hour = int.Parse(referenceNbr.AsSpan(4, 2), CultureInfo.InvariantCulture);
        if (dayOfYear is < 1 or > 366 || hour > 23)
            return null;

        var year = Enumerable.Range(enteredTime.Year - 5, 11).First(y => y % 10 == yearDigit);
        var utcHour = new DateTime(year, 1, 1).AddDays(dayOfYear - 1).AddHours(hour);

        if (utcOffset is null)
        {
            findings.Add(new(EmvFindingSeverity.Info, $"RRN {referenceNbr} encodes a processing time of {utcHour:MM/dd/yyyy h:'00' tt} - {utcHour.AddHours(1):h:'00' tt} UTC."));
            return null;
        }

        var localHour = utcHour + utcOffset.Value;
        findings.Add(new(EmvFindingSeverity.Info,
            $"RRN {referenceNbr} encodes a processing time of {utcHour:MM/dd/yyyy h:'00' tt} UTC = {localHour:MM/dd/yyyy h:'00' tt} - {localHour.AddHours(1):h:'00' tt} server time (UTC{(utcOffset.Value < TimeSpan.Zero ? "-" : "+")}{utcOffset.Value.Duration():h\\:mm})."));

        if (enteredTime < localHour.AddMinutes(-15) || enteredTime > localHour.AddMinutes(75))
            findings.Add(new(EmvFindingSeverity.Warning,
                $"The entered time {enteredTime:MM/dd/yyyy h:mm tt} is outside that RRN hour - check the date, time and time zone entered. Sales in the RRN hour are searched too."));

        return localHour;
    }

    private static EmvCandidate BuildCandidate(Attempt attempt, List<Attempt> allAttempts, DateTime enteredTime, decimal amount,
        string referenceNbr, bool matchedByReferenceNbr, DateTime? rrnLocalHour)
    {
        var related = RetryChain(attempt, allAttempts);
        var attemptLabels = related.Select((a, i) => (a, Label: $"#{i + 1}")).ToDictionary(x => x.a, x => x.Label);

        var findings = new List<EmvFinding>();
        var (terminalResult, recording, conclusion) = Diagnose(attempt, related, attemptLabels, referenceNbr, findings);

        if (attempt.Amount != amount)
            findings.Insert(0, new(EmvFindingSeverity.Warning, $"Terminal amount {attempt.Amount:C} differs from the entered amount {amount:C}."));

        if (rrnLocalHour.HasValue)
        {
            var consistent = attempt.Start >= rrnLocalHour.Value.AddMinutes(-5) && attempt.Start < rrnLocalHour.Value.AddMinutes(65);
            findings.Insert(0, consistent
                ? new(EmvFindingSeverity.Info, "The attempt's time is consistent with the hour encoded in the RRN.")
                : new(EmvFindingSeverity.Warning, "The attempt's time does NOT match the hour encoded in the RRN - this is probably not the sale MX has."));
        }

        var timeline = related
            .SelectMany(a => a.Entries.Select(e => (Entry: e, Label: attemptLabels[a] + (a == attempt ? " (this)" : ""))))
            .Concat(related.Select(a => a.Sale).Where(s => s is not null).Distinct()
                .SelectMany(s => s!.Entries.Select(e => (Entry: e, Label: "Register"))))
            .DistinctBy(x => (x.Entry.Log, x.Entry.LineNumber))
            .OrderBy(x => x.Entry.Timestamp).ThenBy(x => x.Entry.Log == PosRegisterLogName ? 1 : 0).ThenBy(x => x.Entry.LineNumber)
            .Select(x => ToTimelineRow(x.Entry, x.Label))
            .ToList();

        return new EmvCandidate(
            attempt.ReqTxnId,
            attempt.Start,
            attempt.Amount,
            attempt.Epi,
            attempt.OrderId,
            attempt.Sale?.TxnKey,
            attempt.Sale?.User,
            attempt.Org,
            terminalResult,
            recording,
            Math.Round((attempt.Start - enteredTime).TotalMinutes, 1),
            matchedByReferenceNbr,
            conclusion,
            findings,
            timeline,
            attempt.Sale?.ShiftKey ?? attempt.Entries.Select(e => ShiftRx.Match(e.Text)).Where(m => m.Success).Select(m => (int?)int.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture)).FirstOrDefault(),
            attempt.BaseId);
    }

    // Ranks how likely an attempt is to be an MX charge Jarvis never recorded (lower = more likely):
    // outcomes where the terminal may well have completed the sale after Jarvis gave up come first,
    // a plain decline next, and an attempt Jarvis recorded under a different RegistrationNbr (a
    // different charge) last.
    private static int Likelihood(Attempt a, string referenceNbr)
    {
        if (a.RegistrationNbr is not null && a.RegistrationNbr != referenceNbr)
            return 4;
        if (a.StillInProgressReport is not null || a.Has("[ProcessTerminalSale] EXCEPTION") || a.Has("Timeout/Cancelled")
            || a.Has("approved=True") || a.Has("Before RecordEMVPayment") && !a.Has("After RecordEMVPayment") || !a.Ended)
            return 0;
        if (a.Has("CARD_DECLINED") && !a.Has("In progress"))
            return 2;
        return 1;
    }

    private static bool IsApproved(Attempt a) => a.Has("[MakeEMVPayment] APPROVED") || a.Has("[ProcessTerminalSale] SUCCESS");

    // The cashier's retries of the same sale: a register retry inserts a new POS transaction (new
    // ORDER_ID), so they're found as back-to-back attempts on the same terminal for the same amount,
    // each one following a failed attempt within RetryGap. Any other sale on the terminal in between,
    // or an approval, ends the chain.
    private static List<Attempt> RetryChain(Attempt attempt, List<Attempt> allAttempts)
    {
        var onTerminal = allAttempts.Where(a => a.Epi == attempt.Epi).OrderBy(a => a.Start).ToList();
        var index = onTerminal.IndexOf(attempt);

        var first = index;
        while (first > 0 && IsRetryOf(onTerminal[first], onTerminal[first - 1]))
            first--;

        var last = index;
        while (last < onTerminal.Count - 1 && IsRetryOf(onTerminal[last + 1], onTerminal[last]))
            last++;

        return onTerminal.GetRange(first, last - first + 1);
    }

    private static bool IsRetryOf(Attempt next, Attempt previous)
        => next.Amount == previous.Amount && !IsApproved(previous) && next.Start - previous.LastTimestamp <= RetryGap;

    private static (string TerminalResult, string Recording, string Conclusion) Diagnose(
        Attempt a, List<Attempt> related, Dictionary<Attempt, string> labels, string referenceNbr, List<EmvFinding> findings)
    {
        var approved = IsApproved(a);
        var beforeRecord = a.Find("Before RecordEMVPayment");
        var afterRecord = a.Has("After RecordEMVPayment");
        var exception = a.Find("[ProcessTerminalSale] EXCEPTION");
        var unresolved = a.Has("E_TIMEOUT_UNRESOLVED");
        var timeoutCancelled = a.Has("Timeout/Cancelled") || a.Has(@"Timeout\/Cancelled");
        var inProgress = a.Has("TRANSACTION_IN_PROGRESS") || a.Has("In progress");
        var offline = a.Has("OFFLINE");
        var nonS00 = a.Find("NON_S00_FAILURE");
        var httpResponse = a.Find("[ProcessTerminalSale] HTTP_RESPONSE");
        var lookupError = a.Find("[LookupTerminalSaleAfterTimeout] VALOR_ERROR");
        var lookupNoMatch = a.Find("[LookupTerminalSaleAfterTimeout] NO_MATCH");
        var lookupMatch = a.Find("[LookupTerminalSaleAfterTimeout] MATCH_FOUND");
        var alreadyClaimed = a.Find("CANDIDATE_ALREADY_CLAIMED");
        var declined = a.Find("CARD_DECLINED");
        var errorLine = a.Find("[MakeEMVPayment] ErrorDesc=");

        var declineMessage = declined is null ? null : DeclineMessageRx.Match(declined.Text) is { Success: true } dm ? dm.Groups[1].Value.Trim() : null;
        var errorMessage = errorLine is null ? null : ErrorMsgRx.Match(errorLine.Text) is { Success: true } em ? em.Groups[1].Value.Trim() : null;
        var elapsedSource = exception ?? httpResponse;
        var elapsedSeconds = elapsedSource is not null && ElapsedRx.Match(elapsedSource.Text) is { Success: true } el
            ? int.Parse(el.Groups[1].Value, CultureInfo.InvariantCulture) / 1000.0
            : (double?)null;

        findings.Add(new(EmvFindingSeverity.Info,
            $"Attempt {labels[a]} of {related.Count} in this retry sequence (same terminal, same amount): terminal request sent {a.Start:MM/dd/yyyy h:mm:ss tt} to terminal EPI {a.Epi} for {a.Amount:C} (req_txn_id {a.ReqTxnId}, ORDER_ID {(string.IsNullOrEmpty(a.OrderId) ? "(none)" : a.OrderId)})."));

        if (a.Sale is not null)
            findings.Add(new(EmvFindingSeverity.Info,
                $"Register sale: POS txnKey {a.Sale.TxnKey?.ToString() ?? "(not logged)"}, total due {a.Sale.TotalDue?.ToString("C") ?? "?"}, user {a.Sale.User}, org {a.Sale.Org}, session {a.Sale.SessionId}."));
        else if (a.OrderId?.StartsWith("POS-", StringComparison.Ordinal) == true)
            findings.Add(new(EmvFindingSeverity.Warning, $"No posregister.log entries were found for {a.OrderId}."));
        else
            findings.Add(new(EmvFindingSeverity.Info, "This was not a POS register sale (ORDER_ID is not POS-...), so posregister.log has no entries for it."));

        if (elapsedSeconds is > 60)
            findings.Add(new(EmvFindingSeverity.Warning, $"The terminal call took {elapsedSeconds:0.#} seconds."));

        string terminalResult;
        if (approved)
            terminalResult = "Approved";
        else if (exception is not null)
            terminalResult = $"No response (gave up after {elapsedSeconds:0}s)";
        else if (timeoutCancelled)
            terminalResult = "Timeout/Cancelled";
        else if (inProgress)
            terminalResult = "Transaction in progress";
        else if (offline)
            terminalResult = "Device offline";
        else if (declineMessage is not null)
            terminalResult = $"Declined: {declineMessage}";
        else if (errorMessage is not null)
            terminalResult = $"Error: {errorMessage}";
        else if (httpResponse is null)
            terminalResult = "No result logged";
        else
            terminalResult = "Error";

        var recording = afterRecord ? "RecordEMVPayment completed"
            : beforeRecord is not null ? "RecordEMVPayment started, never finished"
            : a.Ended ? "Not recorded (treated as failed)"
            : "Not recorded (no outcome logged)";

        // Post-timeout recovery: Jarvis asks Valor for the terminal's recent sales to see if this one went through.
        string? lookupSummary = null;
        if (lookupError is not null)
        {
            var le = LookupErrorRx.Match(lookupError.Text);
            lookupSummary = $"The automatic follow-up lookup on Valor failed ({(le.Success ? $"{le.Groups[1].Value} {le.Groups[2].Value} - {le.Groups[3].Value}" : "VALOR_ERROR")}), so Jarvis could not confirm the outcome.";
            findings.Add(new(EmvFindingSeverity.Problem, lookupSummary));
        }
        else if (lookupMatch is not null)
        {
            lookupSummary = lookupMatch.Text.Contains("approved=True", StringComparison.Ordinal)
                ? "The follow-up lookup found the sale on Valor and it was APPROVED."
                : "The follow-up lookup found the sale on Valor and it was not approved.";
            findings.Add(new(lookupMatch.Text.Contains("approved=True", StringComparison.Ordinal) ? EmvFindingSeverity.Warning : EmvFindingSeverity.Info, lookupSummary + " (" + lookupMatch.Text + ")"));
        }
        else if (lookupNoMatch is not null)
        {
            lookupSummary = "The follow-up lookup found no matching sale on Valor at that moment (the terminal hadn't finished or hadn't uploaded it yet).";
            findings.Add(new(EmvFindingSeverity.Problem, lookupSummary + " (" + lookupNoMatch.Text + ")"));
        }
        if (alreadyClaimed is not null)
            findings.Add(new(EmvFindingSeverity.Warning, $"The lookup skipped a Valor sale already claimed by another attempt ({alreadyClaimed.Text})."));

        if (a.StillInProgressReport is { } stillRunning)
            findings.Add(new(EmvFindingSeverity.Problem,
                $"At {stillRunning.Entry.Timestamp:h:mm:ss tt} the terminal refused the next request (req_txn_id {stillRunning.Requester.ReqTxnId}) because this sale was still in progress on it - after Jarvis had already finished with it as '{terminalResult}'."));

        AddRegisterFindings(a, approved, findings);

        string conclusion;
        if (approved && beforeRecord is not null && !afterRecord)
        {
            conclusion = $"The terminal APPROVED the sale and Jarvis started recording it (RecordEMVPayment, RegistrationNbr {a.RegistrationNbr}), but the log never shows 'After RecordEMVPayment'. The payment insert failed or the app stopped in the middle of writing it - that is why MX has the charge and Jarvis has no payment.";
            findings.Add(new(EmvFindingSeverity.Problem, "RecordEMVPayment started but never finished."));
        }
        else if (approved && afterRecord)
        {
            conclusion = "The logs show a normal approval: the terminal approved the sale and RecordEMVPayment completed" +
                (a.RegistrationNbr is not null ? $" with RegistrationNbr {a.RegistrationNbr}" : "") +
                ". The payment was not lost at the terminal or recording step - if it is missing from Jarvis now, it was written with different values (see findings) or removed afterwards.";
            if (a.RegistrationNbr is not null && a.RegistrationNbr != referenceNbr)
                findings.Add(new(EmvFindingSeverity.Warning, $"Jarvis recorded RegistrationNbr {a.RegistrationNbr}, not {referenceNbr} - this attempt is probably a different charge than the one in MX."));
        }
        else if (a.StillInProgressReport is { } report)
        {
            conclusion = $"Jarvis was told this sale failed ({terminalResult}) and recorded nothing - but at {report.Entry.Timestamp:h:mm:ss tt}, when the cashier tried again (req_txn_id {report.Requester.ReqTxnId}), the terminal refused because THIS sale was still in progress on it. The terminal kept running the sale after Jarvis had given up on it, so it most likely completed and settled in MX without Jarvis ever recording it. " + (lookupSummary ?? "");
        }
        else if (lookupMatch is not null && lookupMatch.Text.Contains("approved=True", StringComparison.Ordinal))
        {
            conclusion = "The terminal call failed but the follow-up lookup found the sale APPROVED on Valor - and Jarvis still did not record it. The recovery path found the approval but didn't save the payment.";
        }
        else if (exception is not null || unresolved)
        {
            conclusion = $"Jarvis waited {elapsedSeconds:0} seconds for the terminal and gave up (TaskCanceledException, E_TIMEOUT_UNRESOLVED). " +
                (lookupSummary ?? "") +
                " Jarvis told the register it 'could not confirm the outcome' and recorded no payment. The terminal finished the sale after Jarvis stopped waiting, so the card was charged (MX has it) but Jarvis never got the approval.";
        }
        else if (timeoutCancelled)
        {
            conclusion = "Valor answered this attempt with STATE -1 'Timeout/Cancelled', so Jarvis treated it as a failed sale and recorded nothing. Since MX has the charge, the terminal/processor actually completed the sale (e.g. the card was presented as the terminal was timing out). " + (lookupSummary ?? "");
        }
        else if (inProgress)
        {
            var blocker = a.BlockedBy is null ? "an earlier request"
                : $"an earlier sale (req_txn_id {a.BlockedBy.ReqTxnId}, sent {a.BlockedBy.Start:h:mm:ss tt}{(labels.TryGetValue(a.BlockedBy, out var blockerLabel) ? $", attempt {blockerLabel}" : "")})";
            conclusion = $"Valor answered 'Transaction in progress' - the terminal was still busy with {blocker}. Jarvis treated this attempt as failed and recorded nothing, but the sale in progress on the terminal most likely completed afterwards and settled in MX. " + (lookupSummary ?? "");
        }
        else if (offline || nonS00 is not null || errorMessage is not null && declineMessage is null)
        {
            conclusion = $"Valor returned an error to Jarvis ({errorMessage ?? "non-S00 response"}), so Jarvis recorded nothing. If MX has this charge, the terminal processed it even though Jarvis was told it failed.";
        }
        else if (declineMessage is not null)
        {
            conclusion = $"The terminal reported a decline ('{declineMessage}'), so Jarvis correctly recorded nothing. This attempt is probably not the charge MX has - check the other attempts.";
        }
        else
        {
            conclusion = "The log stops without a terminal response or a MakeEMVPayment outcome - the request was cut off (app pool recycle/restart or the request was aborted), so Jarvis never recorded a payment.";
            findings.Add(new(EmvFindingSeverity.Problem, "No terminal outcome was ever logged for this attempt."));
        }

        foreach (var other in related.Where(r => r != a && r.Start > a.Start && r.Has("After RecordEMVPayment")))
            findings.Add(new(EmvFindingSeverity.Warning,
                $"Attempt {labels[other]} at {other.Start:h:mm:ss tt} (the cashier's retry) was approved and recorded (RegistrationNbr {other.RegistrationNbr ?? "?"}). If this attempt was also charged, the customer was charged twice - MX would show both charges, Jarvis only the recorded one."));

        return (terminalResult, recording, conclusion);
    }

    private static void AddRegisterFindings(Attempt a, bool approved, List<EmvFinding> findings)
    {
        if (a.Sale is null)
            return;

        var windowEnd = a.LastTimestamp.AddMinutes(2);
        var during = a.Sale.Entries.Where(e => e.Timestamp >= a.Start.AddSeconds(-30) && e.Timestamp <= windowEnd).ToList();
        var exit = during.FirstOrDefault(e => e.Timestamp >= a.Start && e.Text.Contains("MakeEMVPayment EXIT", StringComparison.Ordinal));

        if (exit is null)
            findings.Add(new(EmvFindingSeverity.Warning, "posregister.log has no MakeEMVPayment EXIT for this attempt - the register's request ended (browser closed, refreshed or timed out) before Jarvis answered."));
        else if (ReturnClipRx.Match(exit.Text) is { Success: true } clip)
            findings.Add(new(EmvFindingSeverity.Info, $"The register was told: {clip.Groups[1].Value}"));

        foreach (var e in during.Where(e => e.Text.Contains("EXCEPTION", StringComparison.Ordinal) || e.Text.Contains(" FAIL", StringComparison.Ordinal)
                     || e.Text.Contains("INVENTORY_DEDUCT_FAILED", StringComparison.Ordinal)))
            findings.Add(new(EmvFindingSeverity.Problem, $"Register error at {e.Timestamp:h:mm:ss tt}: {Truncate(e.Text, 300)}"));

        if (approved)
        {
            var completed = a.Sale.Entries.Any(e => e.Timestamp >= a.Start && e.Text.StartsWith("CompletePOSTransactionAfter", StringComparison.Ordinal) && e.Text.Contains(" SUCCESS", StringComparison.Ordinal));
            if (!completed)
                findings.Add(new(EmvFindingSeverity.Warning, "The register never logged CompletePOSTransactionAfterEmv SUCCESS - the POS transaction was left pending after the approval."));
        }
    }

    private static EmvTimelineRow ToTimelineRow(LogEntry e, string attemptLabel)
    {
        var detail = Truncate(WhitespaceRx.Replace(AppIdRx.Replace(e.Text, "$1…"), " ").Trim(), 700);
        var words = e.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var eventWords = words.TakeWhile(w => !w.Contains('=') && !w.StartsWith('{')).Take(5);
        var eventText = string.Join(' ', eventWords);
        var problem = ProblemRx.IsMatch(e.Text);

        return new EmvTimelineRow(
            e.Timestamp,
            e.Log + ".log",
            attemptLabel,
            eventText.Length > 0 ? eventText : Truncate(detail, 40),
            detail,
            problem ? EmvFindingSeverity.Problem : null,
            !problem && GoodRx.IsMatch(e.Text));
    }

    private static string DescribeRange(List<LogEntry> entries)
        => entries.Count == 0 ? "(empty)" : $"{entries[0].Timestamp:MM/dd/yyyy h:mm tt} - {entries[^1].Timestamp:MM/dd/yyyy h:mm tt}";

    private static string Truncate(string s, int max) => s.Length <= max ? s : s[..max] + "…";
}
