using MediatR;
using System;

namespace Project.Application.Common.Projects.Commands
{
    public class CreateProjectRequestModel : IRequest<CreateProjectResponseModel>
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public DateTime? FrequencyStartDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Priority { get; set; }
        public string Classification { get; internal set; }
        public DateTime? DueDate { get; internal set; }
        public string ProjectImage { get; internal set; }
        public DateTime? CreatedDate { get; set; }
    }
}