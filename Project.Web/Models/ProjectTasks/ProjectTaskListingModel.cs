namespace Project.Web.Models.ProjectTasks
{
    public class ProjectTaskListingModel
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}