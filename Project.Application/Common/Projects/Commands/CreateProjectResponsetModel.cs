using System;

namespace Project.Application.Common.Projects.Commands
{
    public class CreateProjectResponseModel
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}