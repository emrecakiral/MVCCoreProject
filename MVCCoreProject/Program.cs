using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer(@"Server=.\mssqlexpress;Database=Northwind;uid=sa;pwd=123");
});

builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<ProductsRepository>();
builder.Services.AddTransient<RegionRepository>();

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


app.UseEndpoints(endpoints => {

    endpoints.MapControllerRoute(name: "areas",
        pattern: "{area:exists}/{controller}/{action}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});




app.Run();
