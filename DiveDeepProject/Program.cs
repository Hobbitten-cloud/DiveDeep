using DiveDeepProject.Models;
using DiveDeepProject.Services;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using Microsoft.EntityFrameworkCore;
using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
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

            builder.Services.AddDefaultIdentity<ApplicationUser>
                (options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<DiveDeepContext>();
           
            builder.Services.AddRazorPages();

			var app = builder.Build();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}