using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Projects.Commands.Subtask
{

    public class LoadCreateSubtaskCommand : IRequest<SubTaskCreateViewModel>
    {
        public int taskId { get; set; }
    }

    public class LoadCreateSubtask : IRequestHandler<LoadCreateSubtaskCommand, SubTaskCreateViewModel>
    {
        private readonly IApplicationDbContext _context;

        public LoadCreateSubtask(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SubTaskCreateViewModel> Handle(LoadCreateSubtaskCommand request, CancellationToken cancellationToken)
        {
            var task = _context.Tasks.Include(x => x.Project).Where(x => x.TaskId == request.taskId).FirstOrDefault();
            var tasks = _context.Tasks
                .Include(x => x.Status)
                .Include(x => x.Project)
                .Where(x => x.Project.ProjectId == task.Project.ProjectId)
                .ToList();

            var newSubTask = new SubTaskCreateViewModel()
            {
                TaskId = request.taskId,
                TaskName = task.Name,
                ProjectName = task.Project.Name,
                tasks = tasks.Where(x => x.ParentTaskId != null).Select(x => new SubtaskListingViewModel()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status.Name
                })
            };

            return newSubTask;
        }
    }
}
