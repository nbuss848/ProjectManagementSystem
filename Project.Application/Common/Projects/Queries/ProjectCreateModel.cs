using FluentValidation.Results;
using Project.Domain.Entities;
using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models
{
    public class ProjectCreateModel
    {
        public string ProjectImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public PriorityLevel Priority { get; set; }
        public int Size { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }

        public string Status { get; set; }
        
        //public SelectList StatusList { get; set; }
        public List<string> Statuses { get; set; }
        public ValidationResult Errors { get; internal set; }
    }
}
