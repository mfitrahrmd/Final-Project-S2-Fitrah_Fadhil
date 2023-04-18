using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("TB_TR_Account_Roles")]
[Index("AccountNik", Name = "ix_tb_tr_account_roles_account_nik")]
[Index("RoleId", Name = "ix_tb_tr_account_roles_role_id")]
public class TbTrAccountRole : IEntity<int>
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("account_nik")]
    [StringLength(5)]
    [Unicode(false)]
    public string AccountNik { get; set; } = null!;

    [Column("role_id")]
    public int RoleId { get; set; }

    [JsonIgnore]
    [ForeignKey("AccountNik")]
    [InverseProperty("TbTrAccountRoles")]
    public virtual TbMAccount AccountNikNavigation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("RoleId")]
    [InverseProperty("TbTrAccountRoles")]
    public virtual TbMRole Role { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public int Pk
    {
        get => Id;
        set => Id = value;
    }
}