using MediatR;
using Microsoft.Extensions.Hosting;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.UI.CW
{
    public class Worker : BackgroundService
    {
        private IMediator _mediator;
        public Worker(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {                        
            ProjectIndexViewModel Index = await _mediator.Send(new GetProjectsQuery());            

            foreach (var item in Index.ProjectViewModels)
            {
                Console.WriteLine(item.Description + " " + item.NumberOfTasks);
            }            
        }
    }
}
