using MediatR;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Commands
{
    public class CreateTaskForProjectCommand : IRequest
    {
        public ProjectTaskCreateViewModel VM { get; set; }
    }

    public class CreateTaskForProjectCommandHandler : IRequestHandler<CreateTaskForProjectCommand>
    {
        public Task<Unit> Handle(CreateTaskForProjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
