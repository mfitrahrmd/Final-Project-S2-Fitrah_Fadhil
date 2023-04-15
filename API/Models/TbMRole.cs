using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Roles")]
public class TbMRole : IEntity<int>
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<TbTrAccountRole> TbTrAccountRoles { get; set; } = new List<TbTrAccountRole>();

    [JsonIgnore]
    [NotMapped]
    public int Pk
    {
        get => Id;
        set => Id = value;
    }
}