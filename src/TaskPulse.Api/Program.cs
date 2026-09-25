using Microsoft.EntityFrameworkCore;
using TaskPulse.Application;
using TaskPulse.Infrastructure;
using TaskPulse.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Ou dbContext.Database.Migrate(); se preferir
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Ok(new { message = "TaskPulse API está a funcionar com sucesso!" }))
   .WithName("GetStatus");

app.Run();