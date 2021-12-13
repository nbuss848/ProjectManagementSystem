using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Domain.MySql
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int ProjectId { get; set; }
        public int? StatusId { get; set; }
        public string ProjectImage { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Priority { get; set; }
        public int? Size { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual Statuscode Status { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
