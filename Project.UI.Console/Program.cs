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
        private readonly IMediator _mediator;
        public Program(IMediator mediator)
        {
            _mediator = mediator;
        }
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Domain.Entities.Project, ProjectViewModel>();
                CreateMap<ProjectCreateModel, CreateProjectRequestModel>();
                CreateMap<SubTaskCreateViewModel, CreateSubTaskCommand>();
            }
        }
        static void Main(string[] args)
        {

            //var host = CreateHostBuilder(args).Build();
            //host.Services.GetRequiredService<Program>.

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();

            var host = IHostConfiguration(config);

            host.Services.GetRequiredService<Program>().GetProjects();
        }

        private void GetProjects()
        {
            var projects = _mediator.Send(new GetProjectsQuery());
            foreach (var project in projects.Result.ProjectViewModels)
            {
                Console.WriteLine(project.Description + " " + project.NumberOfTasks);
            }
        }

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
