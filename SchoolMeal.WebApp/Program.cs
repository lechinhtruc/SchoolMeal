using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IReportRepositories, ReportRepositories>();
builder.Services.AddScoped<IAuthRepositories, AuthRepositories>();
builder.Services.AddScoped<IAccountRepositories, AccountRepositories>();
builder.Services.AddScoped<IUserLog, UserLogRepositories>();
builder.Services.AddScoped<IManageAccountsRepositories, ManageAccountsRepositories>();
builder.Services.AddScoped<ISearchRepositores, SearchRepositores>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly("SchoolMeal.WebApp")
));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie((option) =>
    {
        option.LoginPath = "/Auth/DangNhap";
        option.AccessDeniedPath = "/";
        option.Cookie.Name = "SchoolMeal.Session";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
