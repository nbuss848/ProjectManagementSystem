using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Common.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMCController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PMCController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult ViewProjects()
        {
            var projects = _mediator.Send(new GetProjectsQuery());

            return Ok(projects);
        }
    }
}
