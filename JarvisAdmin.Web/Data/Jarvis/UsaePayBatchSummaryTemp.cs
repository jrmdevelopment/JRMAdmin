using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class UsaePayBatchSummaryTemp
{
    public int UsaePayBatchSummaryKey { get; set; }

    public int? BatchId { get; set; }

    public decimal? PaymentTotal { get; set; }
}
