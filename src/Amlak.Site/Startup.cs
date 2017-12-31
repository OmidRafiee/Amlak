using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Alamut.Service.Messaging.Configration;
using Alamut.Service.Messaging.Contracts;
using Alamut.Service.Messaging.Implementation;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amlak.Site
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


            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IUserResolverService, UserResolverServiceByHttpContext>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IDbConnection>(options => new SqlConnection(Configuration.GetConnectionString("Default")));

            services.ConfigurePoco<EmailConfig>(Configuration.GetSection("EmailConfig"));
            services.AddSingleton<IEmailService, MimeKitEmailServices>();

            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;

                    //For generate integer number
                    options.Tokens.ChangePhoneNumberTokenProvider = "Phone";
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.Cookie.Name = ".Amlak";
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
