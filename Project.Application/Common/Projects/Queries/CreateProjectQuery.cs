using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Queries;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Projects.Queries
{
    public class CreateProjectQuery : IRequest<ProjectCreateModel>
    {
    }

    public class CreateProjectQueryHandler : IRequestHandler<CreateProjectQuery, ProjectCreateModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateProjectQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectCreateModel> Handle(CreateProjectQuery request, CancellationToken cancellationToken)
        {
            var status = _context.Statuses.OrderBy(x => x.StatusId).Select(x => x.Name);

            var createView = new ProjectCreateModel()
            {
                Statuses = status.ToList(),
                CreatedDate = DateTime.Now,
                Errors = new ValidationResult()
            };

            return createView;
        }
    }
}
