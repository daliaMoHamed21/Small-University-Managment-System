using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC_Day3.Models;
using MVC_Day3.Services;
using MVC_Day3.TestRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//2-add Services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

    .AddCookie(a =>
    {
        //a.LoginPath = "/home/index";
    });
//1-Registration
builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
//builder.Services.AddSingleton<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddDbContext<Lab3DBContext>(d =>
{

    d.UseSqlServer(builder.Configuration.GetConnectionString("conection1"));
});//,ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
//1- add middelware UseAuthentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
