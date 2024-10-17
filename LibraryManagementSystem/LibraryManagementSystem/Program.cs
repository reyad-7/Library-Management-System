using System.Configuration;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.BookRepository;
using LibraryManagementSystem.Repositories.CheckoutRepositry;
using LibraryManagementSystem.Repositories.MemberRepository;
using LibraryManagementSystem.Repositories.PenaltyRepository;
using LibraryManagementSystem.Repositories.ReturnRepository;
using LibraryManagementSystem.Services.bookService;
using LibraryManagementSystem.Services.checkoutService;
using LibraryManagementSystem.Services.memberService;
using LibraryManagementSystem.Services.PenaltyService;
using LibraryManagementSystem.Services.ReturnService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Library_Management_SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICheckoutRepositry, CheckoutRepositry>();
builder.Services.AddScoped<ICheckOutService, CheckOutService>();

builder.Services.AddScoped<IMemberRepository, memberRepository>();
builder.Services.AddScoped<IMemberService, memberService>();

builder.Services.AddScoped<IPenaltyRepository, PenaltyRepository>();
builder.Services.AddScoped<IPenaltyService, PenaltyService>();

builder.Services.AddScoped<IReturnRepository, ReturnRepository>();
builder.Services.AddScoped<IReturnService,ReturnService>();



builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{

    option.Password.RequiredLength = 6;
    option.Password.RequireDigit = true;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;

})
    .AddEntityFrameworkStores<Library_Management_SystemContext>();


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
