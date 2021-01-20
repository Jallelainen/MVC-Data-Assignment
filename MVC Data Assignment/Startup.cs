using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_Data_Assignment.Models.Data;
using MVC_Data_Assignment.Models.Database;
using MVC_Data_Assignment.Models.Identity;
using MVC_Data_Assignment.Models.Services;

namespace MVC_Data_Assignment
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
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityPersonDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<IdentityPersonDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPeopleService, PeopleService>();// container setting for IoC
            services.AddScoped<ICityService, CityService>();// container setting for IoC
            services.AddScoped<ICountryService, CountryService>();// container setting for IoC
            services.AddScoped<ILanguageService, LanguageService>();// container setting for IoC

            services.AddScoped<IPeopleRepo, DataBasePeopleRepo>();// container setting for IoC
            services.AddScoped<ICityRepo, DBCityRepo>();// container setting for IoC
            services.AddScoped<ICountryRepo, DBCountryRepo>();// container setting for IoC
            services.AddScoped<ILanguageRepo, DBLanguageRepo>();// container setting for IoC

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //login
            app.UseAuthorization(); //role

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
