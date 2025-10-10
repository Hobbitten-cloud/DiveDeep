
using DiveDeepProject.Data;
using DiveDeepProject.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

namespace DiveDeepProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
            });

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));
            });

            // Configure Identity and Authentication
            builder.Services.AddAuthentication();
            builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<DiveDeepContext>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy
                    // Only allow these origins
                    .WithOrigins("https://localhost:7280")
                    .WithOrigins("https://localhost:9999")
                    // Only allow these request headers
                    .WithHeaders("Content-Type", "Authorization", "Accept")
                    // Only allow these HTTP methods
                    .WithMethods("GET", "POST", "PUT", "DELETE");
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            // Identity and Authentication
            app.MapIdentityApi<ApplicationUser>();

            // Apply the named CORS policy globally
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
