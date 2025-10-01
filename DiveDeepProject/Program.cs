using DiveDeepProject.Models;
using DiveDeepProject.Services;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using Microsoft.EntityFrameworkCore;
using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DiveDeepProject.Services.Interfaces;
namespace DiveDeepProject
{
    public class Program
    {//
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
            });
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient("WeatherApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            });

            builder.Services.AddHttpClient("MarineApiClient", client =>
            {
                client.BaseAddress = new Uri("https://marine-api.open-meteo.com/v1/");
            });

            builder.Services.AddScoped<IHttpService, HttpService>();

            builder.Services.AddScoped<ProductRepo>();
            builder.Services.AddScoped<SortingService>();
            builder.Services.AddScoped<CategoryRepo>();
            builder.Services.AddScoped<PackageRepo>();
            builder.Services.AddScoped<ReceiptRepo>();
            builder.Services.AddScoped<CustomerRepo>();

            builder.Services.AddDefaultIdentity<ApplicationUser>
                (options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DiveDeepContext>();
           
            builder.Services.AddRazorPages();

			var app = builder.Build();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Member" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

			using (var scope = app.Services.CreateScope())
			{
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string email = "admin@admin.com";
                string password = "Test1234,";

				if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = email;
                    user.Email = email;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
			}

			app.Run();
        }
    }
}