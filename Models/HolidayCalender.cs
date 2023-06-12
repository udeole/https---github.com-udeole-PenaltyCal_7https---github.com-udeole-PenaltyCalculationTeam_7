using System;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class HolidayCalender
{
    public int HolidayId { get; set; }

    public string Country { get; set; } = null!;

    public DateOnly HolidayDate { get; set; }

    public DateOnly LastUpdatedDate { get; set; }

    public string Description { get; set; } = null!;

    public int Year { get; set; }

    public string CntlUserid { get; set; } = null!;
}
