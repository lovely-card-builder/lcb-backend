using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Template.Infrastructure;

public class LcbContext : DbContext
{
    public LcbContext()
    {
    }

    public LcbContext(DbContextOptions<LcbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        throw new Exception("Context was not configured");
    }
}