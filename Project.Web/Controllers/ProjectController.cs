using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IGetProjectByIdQueryHandler _getProjectByIdQueryHandler;
        private readonly ICreateProjectCommandHandler _createProjectQueryHandler;

        public ProjectController(ApplicationDbContext context, IMapper automapper, ICreateProjectCommandHandler createProjectQueryHandler, IGetProjectByIdQueryHandler getProjectByIdQueryHandler)
        {
            _context = context;
            _mapper = automapper;
            _createProjectQueryHandler = createProjectQueryHandler;
            _getProjectByIdQueryHandler = getProjectByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var view = _mapper.ProjectTo<ProjectViewModel>(_context.Projects);
            
            var modelview = new ProjectIndexViewModel() 
            { 
                ProjectViewModels = view                
            };

            var result = _getProjectByIdQueryHandler.GetProjectById(new Application.Common.Projects.Commands.GetProjectByIdRequestModel() { ProjectId = 1 });
                       
            return View(modelview);
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
        public async Task<IActionResult> AddProject(CreateProjectRequestModel model)
        {
            var response = _createProjectQueryHandler.CreateProject(model, new System.Threading.CancellationToken());

            return RedirectToAction("Index", "Project");
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Project, ProjectViewModel>();            
        }
    }
}
