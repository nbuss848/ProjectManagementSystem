using MediatR;

namespace Project.Application.Common.Projects.Commands
{
    public class GetProjectByIdRequestModel : IRequest<GetProjectByIdResponseModel>
    {
        public int ProjectId { get; set; }
    }
}