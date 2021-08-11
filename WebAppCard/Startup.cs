using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCard.Services;
using WebAppCard.Data.DataAccess;
using WebAppCard.Data.Seeder;
using WebAppCard.Data.Repository;
using WebAppCard.Data.Profiles;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using WebAppCard.Data.Models;

namespace WebAppCard
{
    public class Startup

    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration )
        {
            this.Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CardContext>(option =>
            {
                option.UseSqlServer(Configuration["ConnectionStrings:CardContext"]);

            });


            services.AddIdentity<StoreUser, IdentityRole>
               (
                config =>
                {
                    config.User.RequireUniqueEmail = true;
                })
               .AddEntityFrameworkStores<CardContext>();

            services.AddControllers().AddJsonOptions(x =>
                       x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddRazorPages();



            services.AddAutoMapper(typeof(CardProfile).GetTypeInfo().Assembly);
            services.AddScoped<CardSedder>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddTransient<IMailService, MailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //#if DEBUG
            //            app.UseDeveloperExceptionPage();
            //#endif


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add Error Page
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();


            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();
                cfg.MapControllerRoute("Default",
                       "/{controller}/{action}/{id?}",
                       new { controller = "App", action = "Index" });
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

            });
        }
    }
}
