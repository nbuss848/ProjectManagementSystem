using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Infrastructure.Persistence;
using Project.Web.Models;

namespace Project.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectController(ApplicationDbContext context, IMapper automapper)
        {
            _context = context;
            _mapper = automapper;
        }

        public IActionResult Index()
        {
            var view = _mapper.ProjectTo<ProjectViewModel>(_context.Projects);
            var modelview = new ProjectIndexViewModel() { ProjectViewModels = view };
           
            
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
        public async Task<IActionResult> AddProject(ProjectCreateModel model)
        {
            var project = new Domain.Entities.Project()
            {
                ProjectId = 0,
                CreatedDate = model.CreatedDate,
                Description = model.Description,
                Name = model.Name,
                Size = model.Size,
                Priority = model.Priority,
                Classification = model.Classification,
                DueDate = model.DueDate,
                ProjectImage = model.ProjectImage
            };

            await _context.AddAsync(project);
            await _context.SaveChangesAsync();

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
