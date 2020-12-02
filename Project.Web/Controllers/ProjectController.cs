using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Project, ProjectViewModel>();
        }
    }
}
