using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Universities")]
public class TbMUniversity : IEntity<int>
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("University")]
    public virtual ICollection<TbMEducation> TbMEducations { get; set; } = new List<TbMEducation>();

    public int Pk
    {
        get => Id;
        set => Id = value;
    }
}