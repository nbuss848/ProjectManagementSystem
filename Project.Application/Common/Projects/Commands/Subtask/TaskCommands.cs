using MediatR;
using Project.Application.Common.Interfaces;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Commands
{
    public class CreateTaskForProjectCommand : IRequest
    {
        public ProjectTaskCreateViewModel model { get; set; }
    }

    public class CreateTaskForProjectCommandHandler : IRequestHandler<CreateTaskForProjectCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateTaskForProjectCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Unit> Handle(CreateTaskForProjectCommand request, CancellationToken cancellationToken)
        {
            var currentProject = _context.Projects.Where(x => x.ProjectId == request.model.ProjectId).FirstOrDefault();
            var project = new Domain.MySql.Task()
            {
                TaskId = 0,
                Name = request.model.Name,
                Description = request.model.Description,
                ProjectId = request.model.ProjectId,
                FrequencyStartDate = request.model.FrequencyStartDate,
                ReminderDate = request.model.ReminderDate,
                Size = request.model.Size,                
                StatusId = _context.Statuscodes.Where(x => x.Name.ToLower() == "open").Select(x=>x.StatusId).FirstOrDefault()
            };

            await _context.Tasks.AddAsync(project);
            await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
