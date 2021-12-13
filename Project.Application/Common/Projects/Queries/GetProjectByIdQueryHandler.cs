using MediatR;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Commands
{
    public class GetProjectByIdQuery : IRequest<ProjectViewModel>
    {
        public int ProjectId { get; set; }
    }

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetProjectByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var response = _context.Projects
            .Where(x => x.ProjectId == request.ProjectId)
            .Select(x => new ProjectViewModel()
            {
                ProjectId = x.ProjectId,
               // Description = x.Description,
                Name = x.Name
            }).FirstOrDefault();

            return response;
        }
    }
}
