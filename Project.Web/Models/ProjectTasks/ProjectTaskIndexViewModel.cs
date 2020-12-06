﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models.ProjectTasks
{
    public class ProjectTaskIndexViewModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProjectTaskListingModel> TaskList { get; set; }
    }
}
