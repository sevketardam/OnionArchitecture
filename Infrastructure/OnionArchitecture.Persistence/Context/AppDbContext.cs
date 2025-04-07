
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Configurations;

namespace OnionArchitecture.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Brand> Brand { get; set; }
    public DbSet<Detail> Detail { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(x => x.Ignore(RelationalEventId.PendingModelChangesWarning));

    }
}
