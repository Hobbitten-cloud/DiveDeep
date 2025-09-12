using DiveDeepProject.Models.Inferfaces;
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

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
            });

            builder.Services.AddSingleton<ProductRepo>();
            builder.Services.AddSingleton<SortingService>();
            builder.Services.AddSingleton<CategoryRepo>();
            builder.Services.AddSingleton<PackageRepo>();
            builder.Services.AddSingleton<ReceiptRepo>();
			var app = builder.Build();

            app.UseRouting();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}