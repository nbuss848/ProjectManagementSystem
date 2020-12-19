namespace Project.Application.Common.Projects.Commands
{
    public class GetProjectByIdResponseModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public IEnumerable<ProjectTaskListingModel> TaskList { get; set; }
    }
}