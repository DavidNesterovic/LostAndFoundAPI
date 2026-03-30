using LostAndFoundAPI.Application.Repositories;
using LostAndFoundAPI.Application.Repositories.MySqlRepository;
using LostAndFoundAPI.Data;
using LostAndFoundAPI.Domain.Entities;
using LostAndFoundAPI.Hubs;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IFoundItemRepository, MySqlFoundItemRepository>();
builder.Services.AddScoped<ICategoryRepository, MySqlCategoryRepository>();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var connectionString = builder.Configuration.GetConnectionString("mySqlDb");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("ConnectionStrings:mySqlDb is missing.");

builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddAuthorization();

builder.Services
    .AddIdentityApiEndpoints<ApplicationUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<MySqlDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<FoundItemsHub>("/hubs/found-items");
app.MapIdentityApi<ApplicationUser>();

app.Run();