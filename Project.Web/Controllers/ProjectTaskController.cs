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
using Project.Application.Common.Queries;

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
            var viewmodel = _mediatR.Send(new GetProjectTasksByProjectIdQuery(projectId));

            return View(viewmodel.Result);
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

        [HttpGet]
        public IActionResult SubTaskIndex(int taskId)
        {
            SubTaskIndexViewModel view = _mediatR.Send(new ViewSubTaskQuery() { TaskId = taskId }).Result;

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
            await _mediatR.Send(new CreateTaskForProjectCommand() { model = model });

            return RedirectToAction("Index", "ProjectTask", new { model.ProjectId });
        }
    }
}
