using Linkoo.API.Middlewares;
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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

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
