using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_TR_Profilings")]
[Index("EducationId", Name = "ix_tb_tr_profilings_education_id", IsUnique = true)]
public class Profiling : IEntity<string>
{
    [Column("employee_nik")]
    [StringLength(5)]
    [Unicode(false)]
    [Key]
    public string EmployeeNik { get; set; } = null!;

    [Column("education_id")]
    public int EducationId { get; set; }

    [JsonIgnore]
    [ForeignKey("EducationId")]
    [InverseProperty("TbTrProfiling")]
    public virtual Education Education { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("EmployeeNik")]
    [InverseProperty("TbTrProfiling")]
    public virtual Employee EmployeeNikNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public string Pk
    {
        get => EmployeeNik;
        set => EmployeeNik = value;
    }
}