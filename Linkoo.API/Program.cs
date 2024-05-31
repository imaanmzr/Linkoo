using Linkoo.Application;
using Linkoo.Persistence;
using Linkoo.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();


builder.Services.AddCors(options=>{
    options.AddPolicy("CorsPolicy", policy=>{
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});


var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseAuthorization();

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
