using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Commands;
using Project.Infrastructure.Persistence;
using Project.Application.Common.ViewModels;


namespace Project.Web.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;

        public ProjectTaskController(ApplicationDbContext context, IMediator mediatR, IMapper mapper)
        {
            _context = context;
            _mediatR = mediatR;
            _mapper = mapper;
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
            var task = _context.Tasks.Include(x=>x.Project).Where(x => x.TaskId == taskId).FirstOrDefault();
            var tasks = _context.Tasks
                .Include(x=>x.Status)
                .Include(x => x.Project)
                .Where(x => x.Project.ProjectId == task.Project.ProjectId)
                .ToList();

            var newSubTask = new SubTaskCreateViewModel()
            {
                TaskId = taskId,
                TaskName = task.Name,
                ProjectName = task.Project.Name,
                tasks = tasks.Select(x => new SubtaskListingViewModel()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status.Name                    
                })
            };

            return View("AddSubTask", newSubTask);
        }

        public IActionResult SubTaskIndex(int taskId)
        {
            var view = new SubTaskIndexViewModel();
            var task = _context.Tasks.Where(x => x.TaskId == taskId).FirstOrDefault();

            var project = _context.Projects.Where(x => x.Tasks.Contains(task)).FirstOrDefault();

            view.ProjectName = project.Name;
            view.Subtasks = _context.SubTasks.Where(x => x.Task.TaskId == taskId).Select(x=>
                    new SubtaskListingViewModel()
                    {
                        Description = x.Description,
                        Name = x.Name,
                        Status = x.Status.Name
                    }
                );
            view.Task = task.Name;

            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubTask(SubTaskCreateViewModel model)
        {
            var command = _mapper.Map<CreateSubTaskCommand>(model);

            await _mediatR.Send(command);

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
                Project = currentProject,
                Status = _context.Statuses.Where(x => x.Name.ToLower() == "open").FirstOrDefault()
            };

            await _context.AddAsync(project);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "ProjectTask", new { model.ProjectId });
        }
    }
}
