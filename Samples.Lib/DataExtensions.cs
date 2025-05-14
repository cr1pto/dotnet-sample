using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Lib;

public static class DataExtensions
{
    public static IServiceCollection AddPostgresDb<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
    {
        services.AddDbContext<TContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static DbContextOptionsBuilder UsePostgres(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.UseNpgsql(connectionString);

        return optionsBuilder;
    }
}