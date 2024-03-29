using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.Application.Common.Interfaces;
using Project.Infrastructure.Identity;
using Project.Infrastructure.Models;

using Project.WinForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var config = builder.Build();
            //ServiceProvider(config);
            IHostConfiguration(config);
        }

        private static void ServiceProvider(IConfiguration configuration)
        {
            var services = new ServiceCollection();
      
            ConfigureServices(services, configuration);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<MainForm>();
                System.Windows.Forms.Application.Run(form1);
            }
        }

        private static void IHostConfiguration(IConfiguration configuration)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainForm>();
                    services.AddSingleton<frmViewTasks>();
                    services.AddSingleton<AddTask>();
                    services.AddSingleton<ProjectViewListing>();
                    services.AddMediatR(typeof(Application.Common.Queries.CreateProjectQuery).GetTypeInfo().Assembly);
                    services.AddAutoMapper(typeof(Application.Common.Queries.CreateProjectQuery).GetTypeInfo().Assembly);
                    services.AddLogging(configure => configure.AddConsole());
                    //services.AddDbContext<ApplicationDbContext>(opts =>.
                    //{
                    //    opts.EnableDetailedErrors();
                    //    opts.UseNpgsql(configuration.GetConnectionString("Default"));
                    //});
                    services.AddScoped<ICurrentUserService, IdentityService>();
                    services.AddDbContext<PMSContext>(opts =>
                    {
                        opts.UseMySQL(configuration.GetConnectionString("MySql"));
                    });

                    //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
                    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<PMSContext>());
                });

            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var main = services.GetRequiredService<MainForm>();
                    System.Windows.Forms.Application.Run(main);
                    Console.WriteLine("Success");
                }
                catch (Exception)
                {

                    throw;
                }
            }             
        }

        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MainForm>();
            //var assembly = AppDomain.CurrentDomain.Load("Project.Application");
            //services.AddMediatR(assembly);
            services.AddMediatR(typeof(Application.Common.Queries.CreateProjectQuery).GetTypeInfo().Assembly);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddDbContext<ApplicationDbContext>(opts => {
            //    opts.EnableDetailedErrors();
            //    opts.UseNpgsql(configuration.GetConnectionString("Default"));
            //});

            // services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddDbContext<PMSContext>(opts => {
                opts.UseNpgsql(configuration.GetConnectionString("MySql"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<PMSContext>());
        }
    }
}
