using AutoMapper;
using MediatR;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Projects.Queries
{
    public class GetProjectsQuery : IRequest<ProjectIndexViewModel>
    {

    }

    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, ProjectIndexViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectIndexViewModel> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var view = _mapper.ProjectTo<ProjectViewModel>(_context.Projects);

            var modelview = new ProjectIndexViewModel()
            {
                ProjectViewModels = view
            };

            return modelview;
        }
    }
}
