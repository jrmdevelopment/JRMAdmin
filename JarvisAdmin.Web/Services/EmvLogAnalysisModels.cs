namespace JarvisAdmin.Web.Services;

public enum EmvFindingSeverity { Info, Warning, Problem }

public record EmvFinding(EmvFindingSeverity Severity, string Text);

public record EmvTimelineRow(
    DateTime Timestamp,
    string Log,
    string Attempt,
    string Event,
    string Detail,
    EmvFindingSeverity? Highlight,
    bool IsGood);

// One terminal sale attempt (one ProcessTerminalSale call) from paymentservice.log that matched the
// entered reference #, or the entered date/time/amount, plus everything the analysis worked out about it.
public record EmvCandidate(
    string ReqTxnId,
    DateTime StartTime,
    decimal Amount,
    string Epi,
    string? OrderId,
    int? PosTxnKey,
    string? User,
    string? Org,
    string TerminalResult,
    string JarvisRecording,
    double MinutesFromEntered,
    bool MatchedByReferenceNbr,
    string Conclusion,
    List<EmvFinding> Findings,
    List<EmvTimelineRow> Timeline,
    int? ShiftKey,
    string GroupId);

public record EmvAnalysisResult(
    string? Error,
    string? LogCoverage,
    List<EmvFinding> GeneralFindings,
    List<EmvCandidate> Candidates);

public record EmvTimeZoneOption(string Id, string Label);
