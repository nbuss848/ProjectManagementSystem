using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Common.ViewModels
{
    public class SubTaskCreateViewModel
    {
        public int SubTaskId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string ProjectName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public IEnumerable<SubtaskListingViewModel> tasks { get; set; }

    }
}
