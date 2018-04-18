using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infomerc_site.Data;
using infomerc_site.Models;
using infomerc_site.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infomerc_site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InfomercContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<InfomercContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                //// Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                //// User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/account/login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireClaim("Administrador"));
                options.AddPolicy("UsuarioPremium", policy => policy.RequireClaim("Usuario", "Premium"));
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddRouting(options =>
                {
                    options.LowercaseUrls = true;
                });
             
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            { 
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
