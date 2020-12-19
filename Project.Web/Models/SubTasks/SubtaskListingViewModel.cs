using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models.SubTasks
{
    public class SubtaskListingViewModel
    {
        public string ParentTaskName { get; set; }
        public string ParentDescription { get; set; }
        public int SubTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }
    }
}
