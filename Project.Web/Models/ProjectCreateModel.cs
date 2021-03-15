using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Common.Queries
{
    partial class ProjectCreateModel
    {
        public SelectList StatusList { get; set; }
    }
}
