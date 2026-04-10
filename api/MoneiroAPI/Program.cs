using Microsoft.EntityFrameworkCore;
using MoneiroService;
using MoneiroRepository;
using MoneiroDomain.Interfaces;
using MoneiroService.Interfaces;
using MoneiroService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
builder.Services.AddDbContext<MoneiroDbContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
