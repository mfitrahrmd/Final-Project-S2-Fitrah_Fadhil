using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMEducation
{
    public int Id { get; set; }

    public string Major { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public double Gpa { get; set; }

    public int UniversityId { get; set; }

    public virtual TbMProfiling? TbMProfiling { get; set; }

    public virtual TbMUniversity University { get; set; } = null!;
}
