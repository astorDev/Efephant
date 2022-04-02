using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Efephant;

public static class ApplicationSetupExtensions
{
    public static void Migrate<TContext>(this IHost host) where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        if (!context.Database.ProviderName!.Contains("InMemory")) context.Database.Migrate();
    }

    public static void AddPostgres<TContext>(this IServiceCollection services, IConfiguration configuration, string configurationKey = "ConnectionStrings:Postgres") where TContext : DbContext
    {
        var connectionString = configuration[configurationKey];
        services.AddDbContext<TContext>(o => o.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
    }

    public static void AddInMemory<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TContext>));
        if (descriptor != null) services.Remove(descriptor);
        
        var guid = Guid.NewGuid().ToString();
        services.AddDbContext<TContext>(o => o.UseInMemoryDatabase(guid));
    }
}