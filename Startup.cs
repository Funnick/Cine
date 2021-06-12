using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Cine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Cine.ModelsRepository;
using Cine.SQLiteRepository;

namespace Cine
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
            services.AddControllersWithViews();

            services.AddDbContext<CineDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("CineConnection")));

            services.AddIdentity<TheaterUser, IdentityRole>()
                .AddEntityFrameworkStores<CineDbContext>();

            services.AddScoped<ITheaterUserRepository, DbTheaterUserRepository>();
            services.AddScoped<ITheaterMemberRepository, DbTheaterMemberRepository>();
            services.AddScoped<IGetRepository<Movie>, DbMovieRepository>();
            services.AddScoped<IGetRepository<Show>, DbShowRepository>();
            services.AddScoped<IGetRepository<Cinema>, DbCinemaRepository>();

            //services.AddDatabaseDeveloperPageExceptionFilter();
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
                app.UseExceptionHandler("/Main/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Index}/{id?}");
            });

            
        }
    }
}
