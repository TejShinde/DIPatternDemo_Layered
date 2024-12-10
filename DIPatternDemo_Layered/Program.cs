using DIPatternDemo_Layered .Data;
using DIPatternDemo_Layered .Repositories;
using DIPatternDemo_Layered .Services;
using Microsoft .AspNetCore .Http;
using Microsoft .EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configuration of session
builder .Services .AddSession(options =>
{
    options .IdleTimeout = TimeSpan .FromMinutes(30);
    options .Cookie .IsEssential = true;
});



//read connection string from appsetting.json
var conn = builder .Configuration .GetConnectionString("DefaultConnection");
//pass connection string to applicationdbcontext class
builder.Services.AddDbContext<ApplicationDBContext>(options => options .UseSqlServer(conn));


builder .Services .AddSingleton<IHttpContextAccessor , HttpContextAccessor>();


builder .Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();

builder .Services .AddScoped<ICategoryRepository , CategoryRepository>();
builder .Services .AddScoped<ICategoryService , CategoryService>();

builder .Services .AddScoped<IProductRepository , ProductRepository>();
builder .Services .AddScoped<IProductService , ProductService>();

builder .Services .AddScoped<IUserRepository , UserRepository>();
builder .Services .AddScoped<IUserService , UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app .UseSession();

app .UseAuthorization();



app .MapControllerRoute(
    name: "default",
     // pattern: "{controller=Category}/{action=Index}/{id?}");
     pattern: "{controller=User}/{action=Login}/{id?}");
app .Run();
