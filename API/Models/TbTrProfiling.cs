using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_TR_Profilings")]
[Index("EducationId", Name = "ix_tb_tr_profilings_education_id", IsUnique = true)]
public class TbTrProfiling
{
    [Key]
    [Column("employee_nik")]
    [StringLength(5)]
    [Unicode(false)]
    public string EmployeeNik { get; set; } = null!;

    [Column("education_id")] public int EducationId { get; set; }

    [ForeignKey("EducationId")]
    [InverseProperty("TbTrProfiling")]
    public virtual TbMEducation Education { get; set; } = null!;

    [ForeignKey("EmployeeNik")]
    [InverseProperty("TbTrProfiling")]
    public virtual TbMEmployee EmployeeNikNavigation { get; set; } = null!;
}