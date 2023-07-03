using ECommerceCMS_API.Core.Interfaces;
using ECommerceCMS_API.Core.Services;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

    var connectionString = configuration.GetConnectionString("LocalConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ITableMetaDataService, TableMetadataService>();
builder.Services.AddTransient<ITableDataService, TableDataService>();
builder.Services.AddTransient<IInputService, InputService>();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
