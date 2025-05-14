using Microsoft.Extensions.DependencyInjection;

public static class AuthExtensions
{
    public static IServiceCollection AddRequiredStsServices(this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                //should probably make this configurable
                options.Authority = "https://localhost:44385";
                options.TokenValidationParameters.ValidateAudience = false;
            });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiScope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "api1");
            });
        });

        return services;
    }

}