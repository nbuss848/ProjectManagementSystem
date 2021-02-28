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
using Project.Application.Common.Projects.Commands;
using Project.Application.Common.Projects.Commands.GetProject;
using Project.Application.Common.Projects.Commands.Subtask;
using Project.Application.Common.Projects.Queries;
using Project.Application.Common.Queries;
using Project.Infrastructure.Persistence;
using Project.Web.Models;
using Project.Web.Models.SubTasks;

namespace Project.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjectController(ApplicationDbContext context, IMapper automapper, IMediator mediator)
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
            var result = _mediator.Send(new GetProjectByIdRequestModel() { ProjectId = ProjectId });
            
            return View(result.Result);
        }

        public IActionResult Create(ValidationResult errors = null)
        {
            var status = new SelectList(_context.Statuses.OrderBy(x => x.StatusId).Select(x=>x.Name));
            
            var createView = new ProjectCreateModel() 
            { 
                StatusList = status, 
                CreatedDate = DateTime.Now,
                Errors = errors
            };

            return View("Create", createView);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectCreateModel model)
        {
            var map = _mapper.Map<CreateProjectRequestModel>(model);

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

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Project, ProjectViewModel>();        
            CreateMap<ProjectCreateModel, CreateProjectRequestModel>();
            CreateMap<SubTaskCreateViewModel, CreateSubTaskCommand>();
        }
    }
}
