using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Common.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfTasks { get; set; }
    }
}
