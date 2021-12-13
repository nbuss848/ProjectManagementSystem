using MediatR;
using Project.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Commands
{
    public class CreateSubTaskCommand : IRequest<int>
    {
        public int SubTaskId { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
    }

    public class CreateSubTask : IRequestHandler<CreateSubTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSubTask(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSubTaskCommand request, CancellationToken cancellationToken)
        {
            var projectId = _context.Tasks.Where(x => x.TaskId == request.TaskId).Select(x => x.ProjectId).FirstOrDefault();
            Domain.MySql.Task task = new Domain.MySql.Task()
            {                
                ProjectId = projectId,
                ParentTaskId = request.TaskId,
                StatusId = _context.Statuscodes.Where(x => x.Name.ToLower() == "open").Select(x=>x.StatusId).FirstOrDefault(),
                Name = request.Name,
                Description = request.Description,
                Size = request.Size
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);

            return task.TaskId;
        }
    }
}
