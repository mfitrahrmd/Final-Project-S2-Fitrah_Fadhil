using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TbMAccountRole> TbMAccountRoles { get; set; } = new List<TbMAccountRole>();
}
