using Project.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Common.Projects.Commands.GetProject
{
    public class GetProjectByIdQueryHandler : IGetProjectByIdQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetProjectByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public GetProjectByIdResponseModel GetProjectById(GetProjectByIdRequestModel request)
        {
            var response = _context.Projects
                .Where(x => x.ProjectId == request.ProjectId)
                .Select(x => new GetProjectByIdResponseModel()
                {
                    ProjectId = x.ProjectId,
                    Description = x.Description,
                    Name = x.Name
                }).FirstOrDefault();

            return response;
        }
    }
}
