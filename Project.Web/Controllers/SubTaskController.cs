using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.Persistence;
using Project.Web.Models.SubTasks;

namespace Project.Web.Controllers
{
    public class SubTaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int taskId)
        {
            var subtask = new SubtaskListingViewModel();

            return View(subtask);
        }
    }
}
