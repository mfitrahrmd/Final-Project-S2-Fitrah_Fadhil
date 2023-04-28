using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Roles")]
public class Role : IEntity<int>
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("Role")]
    public virtual ICollection<AccountRole> TbTrAccountRoles { get; set; } = new List<AccountRole>();

    [JsonIgnore]
    [NotMapped]
    public int Pk
    {
        get => Id;
        set => Id = value;
    }
}