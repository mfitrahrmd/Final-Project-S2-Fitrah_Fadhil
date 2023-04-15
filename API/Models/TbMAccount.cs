using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Accounts")]
public class TbMAccount : IEntity<string>
{
    [Key]
    [Column("employee_nik")]
    [StringLength(5)]
    [Unicode(false)]
    public string EmployeeNik { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [ForeignKey("EmployeeNik")]
    [InverseProperty("TbMAccount")]
    public virtual TbMEmployee EmployeeNikNavigation { get; set; } = null!;

    [InverseProperty("AccountNikNavigation")]
    public virtual ICollection<TbTrAccountRole> TbTrAccountRoles { get; set; } = new List<TbTrAccountRole>();

    [JsonIgnore]
    [NotMapped]
    public string Pk
    {
        get => EmployeeNik;
        set => EmployeeNik = value;
    }
}