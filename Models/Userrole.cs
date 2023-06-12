using System;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class Userrole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public DateTime? CntlTimestamp { get; set; }

    public string? CntlUserId { get; set; }
}
