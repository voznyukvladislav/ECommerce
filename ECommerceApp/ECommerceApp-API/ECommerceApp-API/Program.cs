using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Core.Services;
using ECommerceApp_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

// Add services to the container.
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
        configureOptions.Cookie.SameSite = SameSiteMode.None;
        configureOptions.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

        // To prevent unnecessary redirections
        configureOptions.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = httpContext =>
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = httpContext =>
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 403;
                
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    string? connectionString = configuration!.GetConnectionString("LocalConnection");
    options.UseSqlServer(connectionString!);
});

builder.Services.AddCors();

// Custom services
builder.Services.AddTransient<ISidebarService, SidebarService>();
builder.Services.AddTransient<IPopupService, PopupService>();

// Add middleware
var app = builder.Build();

app.UseCors(options =>
{
    string? origin = configuration!.GetValue<string>("ClientAppUrl");

    options
        .WithOrigins(origin!)
        .AllowAnyHeader()
        .AllowAnyMethod()
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
