using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Commands;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using Project.Infrastructure.Models;

namespace Project.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly PMSContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjectController(PMSContext context, IMapper automapper, IMediator mediator)
        {
            _context = context;
            _mapper = automapper;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            var result = _mediator.Send(new GetProjectsQuery());
                       
            return View(result.Result);
        }

        public IActionResult ViewProject(int ProjectId)
        {            
            var result = _mediator.Send(new GetProjectByIdQuery() { ProjectId = ProjectId });
            
            return View(result.Result);
        }

        public IActionResult Create(ValidationResult errors = null)
        {
            var result = _mediator.Send(new CreateProjectQuery());
            ViewBag.StatusList = result.Result.Statuses.Select(x=> new SelectListItem() {Text = x, Value = x});

            return View("Create", result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectCreateModel model)
        {
            var map = _mapper.Map<CreateProjectCommand>(model);

            var response = await _mediator.Send(map);

            if (response.Errors != null)
            {
                return Create(response.Errors);
            }
            else 
            { 
                return RedirectToAction("Index", "Project");
            }
        }
    }
}
