namespace Project.Application.Common.ViewModels
{
    public class GetProjectByIdResponseModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public IEnumerable<ProjectTaskListingModel> TaskList { get; set; }
    }
}