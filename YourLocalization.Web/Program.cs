using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using YourLocalization.Application;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.User;
using YourLocalization.Domain.Model;
using YourLocalization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddTransient<IPointService, PointService>();

builder.Services.AddTransient<IValidator<NewUserVm>, NewUserValidation>();
builder.Services.AddTransient<IValidator<NewPointVm>, NewPointValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();