using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SHMS.Data;
using SHMS.Services;

namespace SHMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews( );
            builder.Services.AddDbContext<DataContext>(options => {
                options.UseSqlite("Data Source=patientMonitoring.db");
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/Account/Login");
            builder.Services.AddAuthorization( );
            builder.Services.AddScoped<TestResultService>( );
            builder.Services.AddScoped<UserService>( );

            var app = builder.Build( );

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment( ))
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts( );
            }

            app.UseHttpsRedirection( );
            app.UseStaticFiles( );

            app.UseRouting( );

            app.UseAuthentication( );
            app.UseAuthorization( );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run( );
        }
    }
}
