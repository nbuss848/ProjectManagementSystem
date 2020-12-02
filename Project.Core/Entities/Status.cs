using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Entities
{
    public class Status
    {
        public Status()
        {
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
            SubTasks = new HashSet<SubTask>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<SubTask> SubTasks { get; set; }

    }
}
