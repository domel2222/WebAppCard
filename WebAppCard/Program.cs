using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebAppCard.Data.Seeder;

namespace WebAppCard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

                RunSeeding(host);
                host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(AddConfiguration)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

        private static void RunSeeding(IHost host)
        {
            //var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = host.Services.CreateScope())
            {
                //var seeder = host.Services.GetService<CardSedder>();
                var seeder = scope.ServiceProvider.GetService<CardSedder>();
                seeder.SeedAsync().Wait();
            }
        }



        private static void AddConfiguration(HostBuilderContext context, 
                                                IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }
    }
}
