using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Common.ViewModels
{
    public class SubTaskIndexViewModel
    {
        public string ProjectName { get; set; }
        public string Task { get; set; }
        public IEnumerable<SubtaskListingViewModel> Subtasks { get; set; }
    }
}
