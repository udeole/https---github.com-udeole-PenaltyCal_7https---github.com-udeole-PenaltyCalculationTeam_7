using System;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class SignupUser
{
    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? TelephoneNumber { get; set; }

    public DateTime? CntlTimestamp { get; set; }

    public char? CntlUserid { get; set; }

    public int RoleId { get; set; }

    public virtual Userrole Role { get; set; } = null!;
}
