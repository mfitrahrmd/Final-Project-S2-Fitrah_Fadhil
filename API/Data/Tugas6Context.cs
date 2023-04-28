using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class Tugas6Context : DbContext
{
    public Tugas6Context()
    {
    }

    public Tugas6Context(DbContextOptions<Tugas6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> TbMAccounts { get; set; }

    public virtual DbSet<Education> TbMEducations { get; set; }

    public virtual DbSet<Employee> TbMEmployees { get; set; }

    public virtual DbSet<Role> TbMRoles { get; set; }

    public virtual DbSet<University> TbMUniversities { get; set; }

    public virtual DbSet<AccountRole> TbTrAccountRoles { get; set; }

    public virtual DbSet<Profiling> TbTrProfilings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.EmployeeNik).HasName("pk_tb_m_accounts");

            entity.Property(e => e.EmployeeNik).IsFixedLength();

            entity.HasOne(d => d.EmployeeNikNavigation).WithOne(p => p.TbMAccount)
                .HasConstraintName("fk_tb_m_accounts_tb_m_employees_employee_nik");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tb_m_educations");

            entity.HasOne(d => d.University).WithMany(p => p.TbMEducations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_m_educations_tb_m_universities_university_id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Nik).HasName("pk_tb_m_employees");

            entity.HasIndex(e => e.PhoneNumber, "ix_tb_m_employees_phone_number")
                .IsUnique()
                .HasFilter("([phone_number] IS NOT NULL)");

            entity.Property(e => e.Nik).IsFixedLength();
        });

        modelBuilder.Entity<Role>(entity => { entity.HasKey(e => e.Id).HasName("pk_tb_m_roles"); });

        modelBuilder.Entity<University>(entity => { entity.HasKey(e => e.Id).HasName("pk_tb_m_universities"); });

        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tb_tr_account_roles");

            entity.Property(e => e.AccountNik).IsFixedLength();

            entity.HasOne(d => d.AccountNikNavigation).WithMany(p => p.TbTrAccountRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_tr_account_roles_tb_m_accounts_account_nik");

            entity.HasOne(d => d.Role).WithMany(p => p.TbTrAccountRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_tr_account_roles_tb_m_roles_role_id");
        });

        modelBuilder.Entity<Profiling>(entity =>
        {
            entity.HasKey(e => e.EmployeeNik).HasName("pk_tb_tr_profilings");

            entity.Property(e => e.EmployeeNik).IsFixedLength();

            entity.HasOne(d => d.Education).WithOne(p => p.TbTrProfiling)
                .HasConstraintName("fk_tb_tr_profilings_tb_m_educations_education_id");

            entity.HasOne(d => d.EmployeeNikNavigation).WithOne(p => p.TbTrProfiling)
                .HasConstraintName("fk_tb_tr_profilings_tb_m_employees_employee_nik");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}