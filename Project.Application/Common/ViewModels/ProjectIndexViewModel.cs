﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Common.ViewModels
{
    public class ProjectIndexViewModel
    {
        public IEnumerable<ProjectViewModel> ProjectViewModels { get; set; }
    }
}
