using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Educations")]
[Index("UniversityId", Name = "ix_tb_m_educations_university_id")]
public class TbMEducation
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("major")]
    [StringLength(100)]
    [Unicode(false)]
    public string Major { get; set; } = null!;

    [Column("degree")]
    [StringLength(10)]
    [Unicode(false)]
    public string Degree { get; set; } = null!;

    [Column("gpa", TypeName = "decimal(3, 2)")]
    public decimal Gpa { get; set; }

    [Column("university_id")] public int UniversityId { get; set; }

    [InverseProperty("Education")] public virtual TbTrProfiling? TbTrProfiling { get; set; }

    [ForeignKey("UniversityId")]
    [InverseProperty("TbMEducations")]
    public virtual TbMUniversity University { get; set; } = null!;
}