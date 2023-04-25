using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Universities")]
public class University : IEntity<int>
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("University")]
    public virtual ICollection<Education> TbMEducations { get; set; } = new List<Education>();

    [JsonIgnore]
    [NotMapped]
    public int Pk
    {
        get => Id;
        set => Id = value;
    }
}