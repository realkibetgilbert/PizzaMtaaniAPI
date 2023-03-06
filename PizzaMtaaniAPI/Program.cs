using Serilog.Events;
using Serilog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
               .WriteTo.File(
               path: "C:\\Temp\\PIZZAMTAANIAPILOGS-.txt",
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm,ss.fff zzz}[{Level:u3}] {Message:lj}{NewLine}{Exception}",
               rollingInterval: RollingInterval.Day,
               restrictedToMinimumLevel: LogEventLevel.Information
               ).CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PIZZA MTAANI API",
        Description = "This API provides services for PizzaMtaani operations",

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
