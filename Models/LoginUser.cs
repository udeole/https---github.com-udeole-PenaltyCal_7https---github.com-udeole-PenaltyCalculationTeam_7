using System;
using System.Collections.Generic;

namespace PenaltyCal_7.Models;

public partial class LoginUser
{
    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public char? CntlUserid { get; set; }

    public int RoleId { get; set; }

    public virtual Userrole Role { get; set; } = null!;
}
