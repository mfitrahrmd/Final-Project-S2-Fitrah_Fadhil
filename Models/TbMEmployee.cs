using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMEmployee
{
    public string Nik { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; }

    public DateTime HiringDate { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual TbMAccount? TbMAccount { get; set; }

    public virtual TbMProfiling? TbMProfiling { get; set; }
}

public enum Gender
{
    Male,Female
}
