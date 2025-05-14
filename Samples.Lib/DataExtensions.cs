using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Lib;

public static class DataExtensions
{
    public static IServiceCollection AddPostgresDb<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
    {
        return services.AddDbContext<TContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseNpgsql(connectionString);
        });
    }

    public static DbContextOptionsBuilder UsePostgres(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder.EnableDetailedErrors();
        return optionsBuilder.UseNpgsql(connectionString);
    }
}