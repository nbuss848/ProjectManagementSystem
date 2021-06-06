using Project.Application.Common.Commands;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Common.Interfaces
{
    public interface IGetProjectByIdQueryHandler
    {
        GetProjectByIdResponseModel GetProjectById(GetProjectByIdRequestModel request);
    }
}
