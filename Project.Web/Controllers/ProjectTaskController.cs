using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Persistence;
using Project.Web.Models.ProjectTasks;
using Project.Web.Models.SubTasks;

namespace Project.Web.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int projectId)
        {
            Domain.Entities.Project project = _context.Projects.Include(x => x.Tasks).ThenInclude(x=>x.Status)
                .Where(x => x.ProjectId == projectId).FirstOrDefault();

            var viewmodel = new ProjectTaskIndexViewModel()
            { 
                Name = project.Name,
                Description = project.Description,
                TaskList = project.Tasks.Select(x=> new ProjectTaskListingModel()
                {
                    TaskId = x.TaskId,
                    ProjectId = projectId,
                    Description = x.Description,
                    Name = x.Name,
                    Status = x.Status.Name
                })
            };


            return View(viewmodel);
        }

        public IActionResult AddTask(int projectId)
        {
            var newTask = new ProjectTaskCreateViewModel()
            {
                ProjectId = projectId,
                TaskId = 0                
            };

            return View("CreateProjectTask", newTask);
        }

        public IActionResult AddSubTask(int taskId)
        {
           // var task = _context.Tasks.Where(x => x.TaskId == taskId).FirstOrDefault();

            var newSubTask = new SubTaskCreateViewModel()
            {
                TaskId = taskId
            };

            return View("CreateSubTask", newSubTask);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSubTask(SubTaskCreateViewModel model)
        {
            var task = _context.Tasks.Where(x => x.TaskId == model.TaskId).FirstOrDefault();
            var project = new Domain.Entities.SubTask()
            {
                Task = task,
                Name = model.Name,
                Description = model.Description,
                Size = model.Size,
                Status = _context.Statuses.Where(x => x.Name.ToLower() == "open").FirstOrDefault()
            };

            await _context.AddAsync(project);
            await _context.SaveChangesAsync();

            return RedirectToAction("SubTaskIndex", "ProjectTask", new { model.TaskId });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTask(ProjectTaskCreateViewModel model)
        {
            var currentProject = _context.Projects.Where(x => x.ProjectId == model.ProjectId).FirstOrDefault();
            var project = new Domain.Entities.Task()
            {
                TaskId = 0,
                Name = model.Name,
                Description = model.Description,
                FrequencyStartDate = model.FrequencyStartDate,
                ReminderDate = model.ReminderDate,
                Size = model.Size,
                Project = currentProject
            };

            await _context.AddAsync(project);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ProjectTask", new { model.ProjectId });
        }
    }
}
