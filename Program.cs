/*using Microsoft.EntityFrameworkCore;
using PenaltyCal_7.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PenaltyCalContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("Server=localhost;Port=5432;Database=Penalty_Calculation;User Id=postgres;Password=Priti@123")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();*/


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PenaltyCal_7.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<PenaltyCalContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("Server=localhost;Port=5432;Database=Penalty_Calculation;User Id=postgres;Password=Priti@123")));

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

app.UseAuthorization();

app.MapControllerRoute(

    name: "default",

    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(

    name: "default",

    pattern: "{controller=Registration}/{action=SignUp}/{id?}");

app.MapControllerRoute(
    name: "search",
    pattern: "/Show/SearchResults",
    defaults: new { controller = "Show", action = "SearchResults" }
);



app.Run();