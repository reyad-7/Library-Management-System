using System.Configuration;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Library_Management_SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<Library_Management_SystemContext>();


builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{

    option.Password.RequiredLength = 6;
    option.Password.RequireDigit = true;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;

})
    .AddEntityFrameworkStores<Library_Management_SystemContext>();

//builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = true;
//}).AddEntityFrameworkStores<Library_Management_SystemContext>();



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
