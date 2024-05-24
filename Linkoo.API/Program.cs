using Linkoo.Persistence;
using Linkoo.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<LinkooDbContext>();
    await context.Database.MigrateAsync();
    await SeedData.SeedingData(context);
}
catch (Exception ex)
{
var logger = services.GetRequiredService<ILogger>();
    logger.LogError(ex,"An error occured during migration");
}

app.Run();
