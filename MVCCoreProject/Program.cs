using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Models;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddRazorRuntimeCompilation => runtime'da razorda yap�lan (viewda) de�i�ikleri f5 ile g�rmek i�in


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer(@"Server=.\mssqlexpress;Database=Northwind;uid=sa;pwd=123");
});

builder.Services.AddIdentity<AppUser, AppRole>(c=> {
    c.Password.RequiredLength = 3; // min. 3 karakter
    c.Password.RequireLowercase = false; // k���k harf zorunlulu�u yok
    c.Password.RequireUppercase = false; // b�y�k harft zorunlulu�u yok
    c.Password.RequireNonAlphanumeric=false; // �ifrede �zel karakter istemiyoruz. (! vb)
    c.User.RequireUniqueEmail = true; // Email adresini unique yap�yoruz...
}) // servise identtiy instancei ekliyoruz..
    .AddEntityFrameworkStores<NorthwindDbContext>() // Manager s�n�flar�na veritaban�n� g�steriyoruz..
    .AddErrorDescriber<UserRegisterError>(); // identity hatalar�n� �zelle�tiyoruz...


builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<ProductsRepository>();
builder.Services.AddTransient<RegionRepository>();
builder.Services.AddTransient<ProductDiscountRepository>();

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


app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(name: "areas",
        pattern: "{area:exists}/{controller}/{action}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});




app.Run();
