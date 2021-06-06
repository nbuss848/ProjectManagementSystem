using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Application.Common.Commands;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using Project.Infrastructure.Identity;
using Project.Infrastructure.Persistence;
using System;
using System.IO;
using System.Reflection;

namespace Project.UI.CW
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var options = host.Services.GetRequiredService<IMediator>().Value;
            //var host = CreateHostBuilder(args).Build();
            //host.Services.GetRequiredService<Program>.

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfiguration config = builder.Build();

            //var host = IHostConfiguration(config);

            //host.Services.GetRequiredService<Program>().GetProjects();
        }

        //private void GetProjects()
        //{
        //    var projects = _mediator.Send(new GetProjectsQuery());
        //    foreach (var project in projects.Result.ProjectViewModels)
        //    {
        //        Console.WriteLine(project.Description + " " + project.NumberOfTasks);
        //    }
        //}

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

        private static IHost IHostConfiguration(IConfiguration configuration)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<Program>();
                    services.AddMediatR(typeof(Application.Common.Queries.CreateProjectQuery).GetTypeInfo().Assembly);
                    services.AddAutoMapper(Assembly.GetExecutingAssembly());
                    //services.AddLogging(configure => configure.AddConsole());
                    services.AddDbContext<ApplicationDbContext>(opts =>
                    {
                        opts.EnableDetailedErrors();
                        opts.UseNpgsql(configuration.GetConnectionString("Default"));
                    });
                    services.AddScoped<ICurrentUserService, IdentityService>();
                    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
                });

            var host = builder.Build();

            return host;      
        }
    }
}
