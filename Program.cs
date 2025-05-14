using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Data;
using PROG7311_POE_PART_2.Interfaces;
using PROG7311_POE_PART_2.Repositories;
using PROG7311_POE_PART_2.Services;

namespace PROG7311_POE_PART_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFarmerRepository, FarmerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<FarmerService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();  
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
