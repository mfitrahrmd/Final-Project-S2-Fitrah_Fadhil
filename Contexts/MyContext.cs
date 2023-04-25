using System;
using System.Collections.Generic;
using DTS_Web_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Web_Api.Contexts;

public partial class MyContext : DbContext
{
    public MyContext()
    {
    }

    public MyContext(DbContextOptions<MyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> TbMAccounts { get; set; }

    public virtual DbSet<AccountRole> TbMAccountRoles { get; set; }

    public virtual DbSet<Education> TbMEducations { get; set; }

    public virtual DbSet<Employee> TbMEmployees { get; set; }

    public virtual DbSet<Profiling> TbMProfilings { get; set; }

    public virtual DbSet<Role> TbMRoles { get; set; }

    public virtual DbSet<University> TbMUniversities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Nik);

            entity.ToTable("tb_m_accounts");

            entity.Property(e => e.Nik)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("nik");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.NikNavigation).WithOne(p => p.TbMAccount)
                .HasForeignKey<Account>(d => d.Nik)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.ToTable("tb_m_account_roles");

            entity.HasIndex(e => e.EmployeeNik, "IX_tb_m_account_roles_employee_nik");

            entity.HasIndex(e => e.RoleId, "IX_tb_m_account_roles_role_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeNik)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employee_nik");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.EmployeeNikNavigation).WithMany(p => p.TbMAccountRoles)
                .HasForeignKey(d => d.EmployeeNik)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Role).WithMany(p => p.TbMAccountRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.ToTable("tb_m_educations");

            entity.HasIndex(e => e.UniversityId, "IX_tb_m_educations_university_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Degree)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("degree");
            entity.Property(e => e.Gpa)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("gpa");
            entity.Property(e => e.Major)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("major");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");

            entity.HasOne(d => d.University).WithMany(p => p.TbMEducations)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Nik);

            entity.ToTable("tb_m_employees");

            entity.HasIndex(e => e.Email, "IX_tb_m_employees_email").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_tb_m_employees_phone_number").IsUnique();

            entity.Property(e => e.Nik)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("nik");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.HiringDate)
                .HasColumnType("datetime")
                .HasColumnName("hiring_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Profiling>(entity =>
        {
            entity.ToTable("tb_m_profilings");

            entity.HasIndex(e => e.EducationId, "IX_tb_m_profilings_education_id").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.EducationId).HasColumnName("education_id");

            entity.HasOne(d => d.Education).WithOne(p => p.TbMProfiling)
                .HasForeignKey<Profiling>(d => d.EducationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TbMProfiling)
                .HasForeignKey<Profiling>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("tb_m_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.ToTable("tb_m_universities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
