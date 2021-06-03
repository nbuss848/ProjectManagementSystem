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

namespace Project.Application.Common.Queries
{
    public class GetProjectTasksByProjectIdQuery : IRequest<ProjectTaskIndexViewModel>
    {
        public int ProjectId { get; set; }
        public GetProjectTasksByProjectIdQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }

    public class GetProjectTasksByProjectIdQueryHandler : IRequestHandler<GetProjectTasksByProjectIdQuery, ProjectTaskIndexViewModel>
    {
        private readonly IApplicationDbContext _context;
        public GetProjectTasksByProjectIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProjectTaskIndexViewModel> Handle(GetProjectTasksByProjectIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Project project = _context.Projects
                    .Include(x => x.Tasks).ThenInclude(x => x.Status)
                    .Where(x => x.ProjectId == request.ProjectId)
                    .FirstOrDefault();

            var viewmodel = new ProjectTaskIndexViewModel()
            {
                Name = project.Name,
                Description = project.Description,
                TaskList = project.Tasks.Select(x => new ProjectTaskListingModel()
                {
                    TaskId = x.TaskId,
                    ProjectId = request.ProjectId,
                    Description = x.Description,
                    Name = x.Name,
                    Status = x.Status.Name
                })
            };

            return viewmodel;
        }
    }
}
