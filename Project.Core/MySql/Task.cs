using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Domain.MySql
{
    public partial class Task
    {
        public Task()
        {
            InverseParentTask = new HashSet<Task>();
        }

        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int StatusId { get; set; }
        public int? ParentTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Size { get; set; }
        public DateTime? FrequencyStartDate { get; set; }
        public DateTime? ReminderDate { get; set; }

        public virtual Task ParentTask { get; set; }
        public virtual Project Project { get; set; }
        public virtual Statuscode Status { get; set; }
        public virtual ICollection<Task> InverseParentTask { get; set; }
    }
}
