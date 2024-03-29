﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Queries
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
            var view = _mapper.ProjectTo<ProjectViewModel>(_context.Projects).ToList();
            

            foreach (var project in view)
            {
                project.NumberOfTasks = _context.Tasks                    
                    .Include(x => x.Project)
                    .Where(x => x.Project.ProjectId == project.ProjectId && x.ParentTaskId == null)
                    .Count();
            }

            var modelview = new ProjectIndexViewModel()
            {
                ProjectViewModels = view              
            };

            return modelview;
        }
    }
}
