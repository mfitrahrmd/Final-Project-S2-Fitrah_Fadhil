using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMAccountRole
{
    public int Id { get; set; }

    public string EmployeeNik { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual TbMAccount EmployeeNikNavigation { get; set; } = null!;

    public virtual TbMRole Role { get; set; } = null!;
}
