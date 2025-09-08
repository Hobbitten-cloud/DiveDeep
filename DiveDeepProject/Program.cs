using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Models;
using DiveDeepProject.Services;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
namespace DiveDeepProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();


            builder.Services.AddSingleton<ProductRepo>();
            builder.Services.AddSingleton<SortingService>();
            builder.Services.AddSingleton<CategoryRepo>();

            var app = builder.Build();

            app.UseRouting();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=ContactUs}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
