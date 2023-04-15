using API.Data;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace API_Tests;

public class InMemoryTugas6Context : Tugas6Context
{
    public virtual DbSet<Entity> Entities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("tugas6");
        optionsBuilder.UseExceptionProcessor();
    }
}