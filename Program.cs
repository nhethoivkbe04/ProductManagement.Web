using Microsoft.EntityFrameworkCore;
using ProductManagement.Web.Data;
using ProductManagement.Web.Mappings;
using ProductManagement.Web.Repositories;
using ProductManagement.Web.Repositories.Interfaces;
using ProductManagement.Web.Services;
using ProductManagement.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Đăng ký DbContext
var connectionString = builder.Configuration.GetConnectionString("ProductDbContext");
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Đăng ký AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 3. Đăng ký Services và Repositories (SOLID)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// 4. Đăng ký MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
