using System;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class SecurityPenaltyRate
{
    public long PenaltyId { get; set; }

    public DateOnly? ValidFromDate { get; set; }

    public decimal? PenaltyRate { get; set; }

    public DateOnly? LastUpdatedDate { get; set; }

    public DateTime CntlTimestamp { get; set; }

    public string[] CntlUserid { get; set; } = null!;

    public decimal ApprovePenaltyRequired { get; set; }

    public string Approval { get; set; } = null!;
}
