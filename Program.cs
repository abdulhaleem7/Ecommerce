using Ecommerce;
using Ecommerce.DbContextFolder;
using Ecommerce.Implementation.Repositories;
using Ecommerce.Implementation.Services;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectString = builder.Configuration.GetConnectionString("EcommerceString");
builder.Services.AddDataBase(connectString);
builder.Services.AddRepository().AddServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSeedData();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

