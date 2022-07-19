using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.EntityFramework;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> parameters)
        : base(parameters)
    {
    }

    public DbSet<Node> Nodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>().HasKey(node => node.Id);
    }
}
