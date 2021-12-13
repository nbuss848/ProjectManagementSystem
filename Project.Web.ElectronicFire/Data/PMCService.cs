using MediatR;
using Newtonsoft.Json;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.ElectronicFire.Data
{
    public class PMCService
    {
        private readonly IMediator _mediator;


        public PMCService(IMediator mediator)
        {
            _mediator = mediator;

        }

        public async Task<ProjectIndexViewModel> GetProjects()
        {
            //Console.WriteLine(_context.Projects);
            ProjectIndexViewModel projects = await _mediator.Send(new GetProjectsQuery());
            //WebClient client = new WebClient();
            //var jsonText = client.DownloadString("http://localhost/API/pmc");
            //var json = JsonConvert.DeserializeObject<ProjectIndexViewModel>(jsonText);
            return projects;            
        }
    }
}
