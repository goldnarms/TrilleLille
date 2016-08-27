using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TrilleLille.Web.Config;
using TrilleLille.Web.Models;
using TrilleLille.Web.Services;

namespace TrilleLille.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;";
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TrilleLilleContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;

            })
                .AddEntityFrameworkStores<TrilleLilleContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<ISideMenuService, SideMenuService>();
            services.AddTransient<IRssReader, RssReader>();

            services.AddSingleton<IMapper>(AddAutomapper(new HostingEnvironment()));
        }

        private IMapper AddAutomapper(IHostingEnvironment env)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile(env));
            });
            return mapperConfiguration.CreateMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            var facebookOptions = new FacebookOptions()
            {
                AppId =
                    env.IsDevelopment()
                        ? Configuration["Authentication:Facebook:AppId_Dev"]
                        : Configuration["Authentication:Facebook:AppId"],
                AppSecret =
                    env.IsDevelopment()
                        ? Configuration["Authentication:Facebook:AppSecret_Dev"]
                        : Configuration["Authentication:Facebook:AppSecret"]
            };
            facebookOptions.Scope.Add("user_birthday");
            facebookOptions.Scope.Add("user_location");
            facebookOptions.Scope.Add("public_profile");
            facebookOptions.Scope.Add("user_hometown");
            facebookOptions.Fields.Add("birthday");
            facebookOptions.Fields.Add("email");
            facebookOptions.Fields.Add("picture");
            facebookOptions.Fields.Add("gender");
            //facebookOptions.Fields.Add("public_profile");
            //facebookOptions.Fields.Add("public_profile.picture");
            app.UseFacebookAuthentication(facebookOptions);


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
