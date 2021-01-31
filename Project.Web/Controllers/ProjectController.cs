using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Projects.Commands;
using Project.Infrastructure.Persistence;
using Project.Web.Models;

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
            var view = _mapper.ProjectTo<ProjectViewModel>(_context.Projects);
            
            var modelview = new ProjectIndexViewModel() 
            { 
                ProjectViewModels = view                
            };
                       
            return View(modelview);
        }

        public IActionResult ViewProject(int ProjectId)
        {            
            var result = _mediator.Send(new GetProjectByIdRequestModel() { ProjectId = ProjectId });

            var viewModel =_mapper.Map<ProjectViewModel>(result);

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var status = new SelectList(_context.Statuses.OrderBy(x => x.StatusId).Select(x=>x.Name));
            
            var createView = new ProjectCreateModel() 
            { 
                StatusList = status, 
                CreatedDate=DateTime.Now 
            };

            return View(createView);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectCreateModel model)
        {
            var map = _mapper.Map<CreateProjectRequestModel>(model);
            
            var response = await _mediator.Send(map);

            return RedirectToAction("Index", "Project");
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Project, ProjectViewModel>();        
            CreateMap<ProjectCreateModel, CreateProjectRequestModel>();
        }
    }
}
