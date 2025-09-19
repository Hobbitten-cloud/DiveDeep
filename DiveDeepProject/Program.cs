using DiveDeepProject.Models;
using DiveDeepProject.Services;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using Microsoft.EntityFrameworkCore;
using DiveDeepProject.Data;
namespace DiveDeepProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ProductRepo>();
            builder.Services.AddScoped<SortingService>();
            builder.Services.AddScoped<CategoryRepo>();
            builder.Services.AddScoped<PackageRepo>();
            builder.Services.AddScoped<ReceiptRepo>();

			var app = builder.Build();

            app.UseRouting();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}