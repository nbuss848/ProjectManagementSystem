using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.Persistence;
using Project.Web.Models;

namespace Project.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var view = _context.Projects.Select(x => new ProjectViewModel() { Name = x.Name, Description = x.Description });
            var modelview = new ProjectIndexViewModel() { ProjectViewModels = view };

            return View(modelview);
        }
    }
}
