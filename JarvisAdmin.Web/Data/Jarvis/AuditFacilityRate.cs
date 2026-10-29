using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilityRate
{
    public int AuditFacilityRatesKey { get; set; }

    public int FacilityRatesKey { get; set; }

    public int OrganizationKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public decimal? HourlyRate { get; set; }

    public decimal? HourlyRateNonResident { get; set; }

    public decimal? HourlyRateNonprofit { get; set; }

    public decimal? HalfDayRate { get; set; }

    public decimal? HalfDayRateNonResident { get; set; }

    public decimal? HalfDayRateNonprofit { get; set; }

    public decimal? DailyRate { get; set; }

    public decimal? DailyRateNonResident { get; set; }

    public decimal? DailyRateNonprofit { get; set; }

    public decimal? FullDayRate { get; set; }

    public decimal? FullDayRateNonResident { get; set; }

    public decimal? FullDayRateNonprofit { get; set; }

    public decimal? AdditionalPerHour { get; set; }

    public decimal? SecurityDeposit { get; set; }

    public decimal? SecurityDepositNonResident { get; set; }

    public decimal? SecurityDepositAlcohol { get; set; }

    public decimal? SecurityDepositAlcoholNon { get; set; }

    public bool RentHourly { get; set; }

    public bool RentHalfDay { get; set; }

    public bool RentDaily { get; set; }

    public bool? RentFullDay { get; set; }

    public bool RentFree { get; set; }

    public bool AlcoholAllowed { get; set; }

    /// <summary>
    /// Minimum days between booking and actual reservation. For example, if 2, you could not reserve the day before.
    /// </summary>
    public int? ReservationDaysInAdvance { get; set; }

    public int? MinNbrOfHours { get; set; }

    public int? MaxNbrOfHours { get; set; }

    /// <summary>
    /// Maximum number of days between booking and actual reservation.
    /// </summary>
    public int? MaximumDaysInAdvance { get; set; }

    public int? MinuteIncrement { get; set; }

    public bool OnlineRequireApproval { get; set; }

    public bool DepositOnlyToReserve { get; set; }

    public int? PrepTimeMinutes { get; set; }

    public int? CleanupTimeMinutes { get; set; }

    public int? MaximumCapacity { get; set; }

    public DateTime? StartDateToReserve { get; set; }

    public DateTime? EndDateToReserve { get; set; }

    public int? MaximumWithTablesChairs { get; set; }

    public int? MaximumWithChairsOnly { get; set; }

    public int? MaximumWithDanceStage { get; set; }

    public int? MaximumPerWeek { get; set; }

    public string? RentalAgreement { get; set; }

    public string? AlcoholAgreement { get; set; }

    public string? NoAlcoholAgreement { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
