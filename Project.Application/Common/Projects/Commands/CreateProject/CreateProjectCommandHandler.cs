using MediatR;
using Project.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectRequestModel, CreateProjectResponseModel>
    {
        private readonly IApplicationDbContext _context;
        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProjectResponseModel> Handle(CreateProjectRequestModel request, CancellationToken cancellationToken)
        {
            var project = new Project.Domain.Entities.Project()
            {
                ProjectId = 0,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Name = request.Name,
                Size = request.Size,
                Priority = request.Priority,
                Classification = request.Classification,
                DueDate = request.DueDate,
                ProjectImage = request.ProjectImage
            };

            var result = new CreateProjectResponseModel()
            {
                CreatedDate = DateTime.Now,
                Description = project.Description,
                ProjectId = project.ProjectId
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
