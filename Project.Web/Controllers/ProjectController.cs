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
using Project.Infrastructure.Persistence;
using Project.Application.Common.ViewModels;

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
            var result = _mediator.Send(new GetProjectByIdQuery() { ProjectId = ProjectId });
            
            return View(result.Result);
        }

        public IActionResult Create(ValidationResult errors = null)
        {
            var result = _mediator.Send(new CreateProjectQuery());
            ViewBag.StatusList = result.Result.Statuses;

            return View("Create", result.Result);
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
