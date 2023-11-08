using ECommerceCMS_API.Core.DTOs;
using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Core.Services;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddControllers();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(configureOptions =>
    {
        configureOptions.ExpireTimeSpan = TimeSpan.FromSeconds(6000);
        configureOptions.SlidingExpiration = false;
        configureOptions.Cookie.HttpOnly = false;
        // SameSiteMod Lax for production server, None for local
        configureOptions.Cookie.SameSite = SameSiteMode.Lax;
        configureOptions.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

        // To prevent unnecessary redirections
        configureOptions.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = httpContext =>
            {
                Message message = Message.CreateFailed("Unauthorized", "You need to be authorized to get access.");
                httpContext.Response.ContentType= "application/json";
                httpContext.Response.StatusCode = 401;
                JsonSerializer.Serialize(httpContext.Response.Body, message, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = httpContext =>
            {
                Message message = Message.CreateFailed("Forbidden access", "You don't have enough permissions.");
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 403;
                JsonSerializer.Serialize(httpContext.Response.Body, message, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddCors();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

// Database context
builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("LightSailConnection");
    Console.WriteLine(connectionString);
    //options.UseSqlServer(connectionString);
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));
});

builder.Services.AddTransient<ITableMetaDataService, TableMetadataService>();
builder.Services.AddTransient<ITableDataService, TableDataService>();
builder.Services.AddTransient<IInputService, InputService>();

// Add middleware
var app = builder.Build();

app.UseHttpLogging();

app.UseCors(options =>
{
    string? origin = configuration.GetValue<string>("ClientAppUrl");

    options
        .WithOrigins(origin!)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
