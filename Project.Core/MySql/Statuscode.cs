using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Domain.MySql
{
    public partial class Statuscode
    {
        public Statuscode()
        {
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
