using LostAndFoundAPI.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("mySqlDb");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("ConnectionStrings:mySqlDb is missing.");

builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySQL(connectionString)
);

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.Run();