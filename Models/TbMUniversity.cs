using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMUniversity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TbMEducation> TbMEducations { get; set; } = new List<TbMEducation>();
}
