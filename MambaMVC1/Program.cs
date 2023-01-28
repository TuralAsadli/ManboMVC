using MambaMVC1.Abstractions.Repositories;
using MambaMVC1.Abstractions.Services;
using MambaMVC1.DAL;
using MambaMVC1.Models;
using MambaMVC1.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ManbaDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 5;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<ManbaDbContext>();

builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IPositionRepository, IPositionRepository>();
builder.Services.AddScoped<IEmployeeService, IEmployeeService>();
builder.Services.AddScoped<IPositionService, IPositionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
