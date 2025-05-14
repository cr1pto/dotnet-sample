// Copyright (c) Duende Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.


using Samples.Lib;
using Samples.Lib.Entities;
using Samples.Lib.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SampleDb");

builder.Services.AddPostgresDb<SampleDbContext>(connectionString);

builder.Services.AddTransient<ICaseHandlerService, CaseHandlerService>();

builder.Services.AddRequiredStsServices();

var allowedOrigins = new[] { "http://localhost:4200", "https://localhost:4200", "https://localhost:5001", "https://localhost:5071" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default",
        builder =>
        {
            builder.WithOrigins(allowedOrigins)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("identity", (ClaimsPrincipal user) => user.Claims.Select(c => new { c.Type, c.Value }))
    .RequireAuthorization("ApiScope");

app.MapGet("cases", async (ICaseHandlerService caseHandlerService, CancellationToken cancellationToken) =>
{
    var cases = await caseHandlerService.GetCases(cancellationToken);

    return Results.Ok(cases);
})
    .RequireAuthorization("ApiScope");

app.MapPost("cases", async (Case legalCase, ICaseHandlerService caseHandlerService, CancellationToken cancellationToken) =>
{
    var cases = await caseHandlerService.CreateCase(legalCase, cancellationToken);

    return Results.Created();
})
    .RequireAuthorization("ApiScope");

app.MapDelete("cases/{id}", async (Guid id, ICaseHandlerService caseHandlerService, CancellationToken cancellationToken) =>
{
    var cases = await caseHandlerService.DeleteCase(id, cancellationToken);

    return Results.Accepted();
})
    .RequireAuthorization("ApiScope");

app.MapPut("cases/{id}", async (Guid id, Case legalCase, ICaseHandlerService caseHandlerService, CancellationToken cancellationToken) =>
{
    var cases = await caseHandlerService.UpdateCase(legalCase, cancellationToken);

    return Results.Ok(cases);
})
    .RequireAuthorization("ApiScope");

app.UseCors("Default");

app.Run();
