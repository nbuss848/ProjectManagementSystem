using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Commands;
using Project.Application.Common.ViewModels;
using Project.Application.Common.Queries;
using Project.Infrastructure.Models;
using Project.Application.Common.Projects.Commands.Subtask;

namespace Project.Web.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly PMSContext _context;
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;

        public ProjectTaskController(PMSContext context, IMediator mediatR, IMapper mapper)
        {
            _context = context;
            _mediatR = mediatR;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int projectId)
        {
            var viewmodel = _mediatR.Send(new GetProjectTasksByProjectIdQuery(projectId));

            return View(viewmodel.Result);
        }

        [HttpGet]
        public IActionResult AddTask(int projectId)
        {
            var newTask = new ProjectTaskCreateViewModel()
            {
                ProjectId = projectId,
                TaskId = 0                
            };

            return View("CreateProjectTask", newTask);
        }

        [HttpGet]
        public async Task<IActionResult> AddSubTask(int taskId)
        {
            var command = new LoadCreateSubtaskCommand() { taskId = taskId };
            var response = await _mediatR.Send(command);
            return View("AddSubTask", response);
        }

        [HttpGet]
        public IActionResult SubTaskIndex(int taskId)
        {
            var query = new ViewSubTaskQuery() { TaskId = taskId };

            SubTaskIndexViewModel view = _mediatR.Send(query).Result;

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
