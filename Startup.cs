using CheckBox.Data;
using CheckBox.DependencyInjection;
using CheckBox.Web.Helper;
using CheckBox.Web.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


namespace CheckBox.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Helper.ISession, Session>();
            services.AddControllersWithViews();
            services.AddServicesDependency();
            services.AddRepositoryDependency();
            services.AddAutoMapper(typeof(MapperProfile));
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                var connectionstring = $"Server={Environment.GetEnvironmentVariable("MYSQLHOST")};Port=3306;Database={Environment.GetEnvironmentVariable("MYSQL_DATABASE")};User={Environment.GetEnvironmentVariable("MYSQLUSER")};Password={Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD")}";
                services.AddDbContext<Context>(options =>options.UseMySql(connectionstring, 
                        ServerVersion.AutoDetect(connectionstring),mysqlOptions => mysqlOptions.EnableRetryOnFailure()));

                Console.WriteLine($"Connection String: {connectionstring}");
            }
            else
            {
                services.AddDbContext<Context>(opt => opt.UseMySql(Configuration.GetConnectionString("cnMySql"), new MySqlServerVersion(new Version(8, 0, 11))));
            }
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Index}/{id?}");
            });
        }
    }
}
