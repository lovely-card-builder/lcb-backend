using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure;

public static class DI
{
    public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MainDb");

        services.AddDbContext<LcbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

        return services;
    }

    public static async Task MigrateDb(this IServiceProvider provider)
    {
        Console.WriteLine("Migrating Db Started");
        using var serviceScope = provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<LcbContext>();
        await context.Database.MigrateAsync();
        await Seeder.Seed(context);
        Console.WriteLine("Migrating Db Finished");
    }
}