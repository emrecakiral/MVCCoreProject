using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer(@"Server=DESKTOP-D6TMB1B;Database=Northwind;uid=sa;pwd=123");
});


builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<ProductsRepository>();

builder.Services.AddAutoMapper(typeof(Program)); // inject ediyoruz..


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
