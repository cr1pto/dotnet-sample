var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// {
//     var connectionString = builder.Configuration.GetConnectionString("IdDb");
//     static void postgresOptions(Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.NpgsqlDbContextOptionsBuilder cfg) => cfg.EnableRetryOnFailure();
//     options.EnableDetailedErrors();
//     options.EnableThreadSafetyChecks();
//     options.UseNpgsql(connectionString, postgresOptions);
// });

var app = builder.Build();

// var scope = app.Services.CreateScope();

// using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
// // await dbContext.Database.EnsureDeletedAsync();
// // var created = await dbContext.Database.EnsureCreatedAsync();
// await dbContext.Database.MigrateAsync();

// var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

// var adminRole = new IdentityUser("Admin");
// var user = new IdentityUser("admin@admin.com");
// var result = await userManager.AddPasswordAsync(user, "admin123");

// if (result.Succeeded)
// {
//     await dbContext.SaveChangesAsync();
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/people", () =>
{
    var people = new[]
    {
        new { Name = "John Doe", Age = 30 },
        new { Name = "Jane Smith", Age = 25 },
        new { Name = "Sam Brown", Age = 40 }
    };
    return Results.Ok(people);
})
.WithName("GetPeople");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
