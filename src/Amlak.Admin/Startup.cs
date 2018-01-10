using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Alamut.Utilities.AspNet.Configuration;
using Alamut.Utilities.Http;
using Amlak.Core.Entities;
using Amlak.Core.SSOT;
using Amlak.Data;
using Amlak.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Filters;

namespace Amlak.Admin
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();


            //if (env.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.LiterateConsole()
                .WriteTo.Logger(l => l
                    .Filter.ByIncludingOnly(Matching.FromSource("Microsoft.EntityFrameworkCore"))
                    .WriteTo.RollingFile("logs\\EF-{Date}.log"))
                .WriteTo.RollingFile("logs\\{Date}.log", restrictedToMinimumLevel: LogEventLevel.Warning)
                .CreateLogger();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigurePoco<FileConfig>(Configuration.GetSection("FileRepository"));
            services.ConfigurePoco<AppSetting>(Configuration.GetSection("AppSetting"));
            //services.ConfigurePoco<SmsSetting>(Configuration.GetSection("SmsSetting"));


            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(allowedRanges: new[]
                {
                    UnicodeRanges.BasicLatin,
                    UnicodeRanges.Arabic
                }));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IUserResolverService, UserResolverServiceByHttpContext>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IDbConnection>(options => new SqlConnection(Configuration.GetConnectionString("Default")));

            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();

            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});

            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;

                    //options.Cookies.ApplicationCookie.AutomaticAuthenticate = true;
                    //options.Cookies.ApplicationCookie.AutomaticChallenge = true;
                    //options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                    //options.Cookies.ApplicationCookie.CookieName = ".Calabin.Admin";
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
            });

            services.AddScoped<HouseRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<OptionRepository>();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
