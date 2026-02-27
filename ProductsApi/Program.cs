using ProductsApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Amazon.CloudWatch;
using ProductsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var amazonCloudConfig = new AmazonCloudWatchConfig
{
    RegionEndpoint = Amazon.RegionEndpoint.EUNorth1,
};

builder.Services.AddSingleton(x => new CloudWatchMetricsService(new AmazonCloudWatchClient(amazonCloudConfig)));

var connectionString = builder.Configuration.GetConnectionString("Default");
var serverVersion = new MySqlServerVersion(new Version(8, 4, 6));

builder.Services.AddDbContext<ProductContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Run the application
app.Run();
