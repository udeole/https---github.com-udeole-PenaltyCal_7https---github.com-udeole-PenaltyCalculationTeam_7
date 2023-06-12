﻿using System;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class SecurityPrice
{
    public long PriceId { get; set; }

    public short? Poh { get; set; }

    public string[]? IsinSecId { get; set; }

    public DateOnly? ValidFromDate { get; set; }

    public decimal? SecPrice { get; set; }

    public DateTime CntlTimestamp { get; set; }

    public string[] CntlUserid { get; set; } = null!;
}
