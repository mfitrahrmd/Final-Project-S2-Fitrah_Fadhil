using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Employees")]
[Index("Email", Name = "ix_tb_m_employees_email", IsUnique = true)]
public class TbMEmployee
{
    [Key]
    [Column("nik")]
    [StringLength(5)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("birthdate")] public DateTime Birthdate { get; set; }

    [Column("gender")] public int Gender { get; set; }

    [Column("hiring_date")] public DateTime HiringDate { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [InverseProperty("EmployeeNikNavigation")]
    public virtual TbMAccount? TbMAccount { get; set; }

    [InverseProperty("EmployeeNikNavigation")]
    public virtual TbTrProfiling? TbTrProfiling { get; set; }
}