using Microsoft.EntityFrameworkCore;
using SampleCrud.Contracts.Entities;
namespace SampleTwoCRUD.EntityFramework.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}
    public DbSet<Students> Students { get; set; }
}
