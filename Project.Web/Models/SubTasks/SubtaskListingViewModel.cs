namespace Project.Web.Models.SubTasks
{
    public class SubtaskListingViewModel
    {
        public int TaskId { get; set; }
        public int SubtaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}