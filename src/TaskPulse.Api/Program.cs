using Microsoft.EntityFrameworkCore;
using TaskPulse.Api;
using TaskPulse.Api.Middlewares;
using TaskPulse.Application;
using TaskPulse.Infrastructure;
using TaskPulse.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Ou dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/scalar", () => Results.Content(@"
        <!doctype html>
        <html>
          <head>
            <title>TaskPulse API - Documentação</title>
            <meta charset=""utf-8"" />
            <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
          </head>
          <body>
            <script id=""api-reference"" data-url=""/openapi/v1.json""></script>
            <script src=""https://cdn.jsdelivr.net/npm/@scalar/api-reference""></script>
          </body>
        </html>
    ", "text/html"));

app.MapGet("/", () => Results.Ok(new { message = "TaskPulse API está a funcionar com sucesso!" }))
   .WithName("GetStatus");

app.MapTaskEndpoints();

app.Run();