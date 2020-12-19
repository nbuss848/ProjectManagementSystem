using Project.Application.Common.Projects.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project.Application.Common.Interfaces
{
    public interface ICreateProjectCommandHandler
    {
        CreateProjectResponseModel CreateProject(CreateProjectRequestModel request, CancellationToken cancellationToken);
    }
}
