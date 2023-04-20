using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Extras;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Employees")]
[Index("Email", Name = "ix_tb_m_employees_email", IsUnique = true)]
public class TbMEmployee : IEntity<string>
{
    [Column("nik")]
    [StringLength(5)]
    [Unicode(false)]
    [Key]
    public string Nik { get; set; } = null!;

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("birthdate")]
    public DateTime Birthdate { get; set; }

    [Column("gender")]
    public Gender Gender { get; set; }

    [Column("hiring_date")]
    public DateTime HiringDate { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [JsonIgnore]
    [InverseProperty("EmployeeNikNavigation")]
    public virtual TbMAccount? TbMAccount { get; set; }

    [JsonIgnore]
    [InverseProperty("EmployeeNikNavigation")]
    public virtual TbTrProfiling? TbTrProfiling { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public string Pk
    {
        get => Nik;
        set => Nik = value;
    }

    [JsonIgnore]
    [NotMapped]
    public string Fullname => $"{FirstName} {LastName}";
}