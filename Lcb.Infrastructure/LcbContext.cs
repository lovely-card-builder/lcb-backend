using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Template.DAL.Models;

namespace Lcb.Infrastructure;

public class LcbContext : DbContext
{
    public LcbContext()
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Postcard> Postcards { get; set; }

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