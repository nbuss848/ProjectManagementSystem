using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Application.Common.Interfaces;
using Project.Infrastructure.Identity;
using Project.Infrastructure.Persistence;
using System.Reflection;

namespace Project.UI.CW
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configuration) =>
            {
                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
           .ConfigureServices((hostContext, services) =>
           {
               // services.AddTransient<Program>();
               services.AddHostedService<Worker>();
               services.AddMediatR(typeof(Application.Common.Queries.CreateProjectQuery).GetTypeInfo().Assembly);
               services.AddAutoMapper(typeof(Application.Common.Mappings.MappingProfile).GetTypeInfo().Assembly);
               //services.AddLogging(configure => configure.AddConsole());
               services.AddDbContext<ApplicationDbContext>(opts =>
               {
                   opts.EnableDetailedErrors();
                   opts.UseNpgsql(hostContext.Configuration.GetConnectionString("Default"));
               });
               services.AddScoped<ICurrentUserService, IdentityService>();
               services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
           });
    }
}
