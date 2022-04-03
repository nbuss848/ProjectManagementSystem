using MediatR;
using Project.Application.Common.Interfaces;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Common.Commands
{
    public class ViewSubTaskQuery :IRequest<SubTaskIndexViewModel>
    {
        public int TaskId { get; set; }
    }

    public class ViewSubTaskQueryHandler : RequestHandler<ViewSubTaskQuery, SubTaskIndexViewModel>
    {
        private readonly IApplicationDbContext _context;
        public ViewSubTaskQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override SubTaskIndexViewModel Handle(ViewSubTaskQuery request)
        {
            var view = new SubTaskIndexViewModel();
            var task = _context.Tasks.Where(x => x.TaskId == request.TaskId).FirstOrDefault();

            var project = _context.Projects.Where(x => x.Tasks.Contains(task)).FirstOrDefault();

            view.ProjectName = project.Name;
            view.Subtasks = _context.Tasks.Where(x => x.ParentTaskId == request.TaskId).Select(x =>
                    new SubtaskListingViewModel()
                    {
                        Description = x.Description,
                        Name = x.Name.ToUpper(),
                        Status = x.Status.Name
                    }
                );
            view.Task = task.Name;

            return view;
        }
    }
}
