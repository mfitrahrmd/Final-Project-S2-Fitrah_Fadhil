﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_M_Educations")]
[Index("UniversityId", Name = "ix_tb_m_educations_university_id")]
public class Education : IEntity<int>
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

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

    [Column("university_id")]
    public int UniversityId { get; set; }

    [JsonIgnore]
    [InverseProperty("Education")]
    public virtual Profiling? TbTrProfiling { get; set; }

    [JsonIgnore]
    [ForeignKey("UniversityId")]
    [InverseProperty("TbMEducations")]
    public virtual University University { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public int Pk
    {
        get => Id;
        set => Id = value;
    }
}