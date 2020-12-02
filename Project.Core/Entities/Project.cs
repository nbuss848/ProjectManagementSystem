using Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int ProjectId { get; set; }
        public string ProjectImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public PriorityLevel Priority { get; set; }
        public int Size { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }


        public virtual Status Status { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
