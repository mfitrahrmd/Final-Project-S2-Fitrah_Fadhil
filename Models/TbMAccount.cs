using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMAccount
{
    public string Nik { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual TbMEmployee NikNavigation { get; set; } = null!;

    public virtual ICollection<TbMAccountRole> TbMAccountRoles { get; set; } = new List<TbMAccountRole>();
}
