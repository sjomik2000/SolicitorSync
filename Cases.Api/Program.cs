using Cases.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Cases.Application.Database;
using Cases.Api.Mapping;
using Serilog;
// This is the main program file used to build API using prebuilt ASP.NET file with added custom configuration
var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Serilog configuration to output log console information and also log information into LogRecords.txt file with Timestamps
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, outputTemplate: 
    "{Timestamp:yyyy-MM-dd HH:mm:ss} {Level}: {Message}{NewLine}{Exception}")
    .WriteTo.File("C:\\Users\\Usere\\Source\\Repos\\SolicitorSync\\Cases.Application\\LogRecords.txt",
                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Level}: {Message}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();

// Services for the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// During AddApplication method, ApplicationServiceCollectionExtensions2.cs initializes DI for the Repository,
// Service and Validation layers.
builder.Services.AddApplication();
// During AddDatabase method, ApplicationServiceCollectionExtensions2.cs initializes DI for the database
// initialization and database connection.
builder.Services.AddDatabase(config["Database:ConnectionString"]!);

var app = builder.Build();

// HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.UseAuthorization();
// Registering Validation Middleware
app.UseMiddleware<ValidationMappingMiddleware>();
app.MapControllers();
// Initialize connection into Postgresql 
var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();
// Run application on specified port
app.Run("https://localhost:5002");
