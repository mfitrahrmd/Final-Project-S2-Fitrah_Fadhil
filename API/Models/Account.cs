using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Accounts")]
public class Account : IEntity<string>
{
    [Column("employee_nik")]
    [StringLength(5)]
    [Unicode(false)]
    [Key]
    public string EmployeeNik { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("EmployeeNik")]
    [InverseProperty("TbMAccount")]
    public virtual Employee EmployeeNikNavigation { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("AccountNikNavigation")]
    public virtual ICollection<AccountRole> TbTrAccountRoles { get; set; } = new List<AccountRole>();

    [JsonIgnore]
    [NotMapped]
    public string Pk
    {
        get => EmployeeNik;
        set => EmployeeNik = value;
    }
}