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
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAppCard
{
    public class Startup

    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration )
        {
            this._configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CardContext>(option =>
            {
                option.UseSqlServer(_configuration["ConnectionStrings:CardContext"]);
            });


            services.AddIdentity<StoreUser, IdentityRole>(option =>
                {
                    option.User.RequireUniqueEmail = true;
                })
               .AddEntityFrameworkStores<CardContext>();
            //.AddDefaultTokenProviders();
            //.AddTokenProvider("WebCard", typeof(DataProtectorTokenProvider<StoreUser>));

            services.AddAuthentication( options =>
                /*JwtBearerDefaults.AuthenticationScheme*/
                {
                    //option.DefaultAuthenticateScheme = "Bearer";
                    //option.DefaultScheme = "Bearer";
                    //option.DefaultChallengeScheme = "Bearer";
                    //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )
                .AddCookie()
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _configuration["MyToken:JwtIssuer"],
                        ValidAudience = _configuration["MyToken:JwtAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MyToken:JwtKey"]))
                    };
                });

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

            app.UseAuthentication();
            app.UseAuthorization();

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
