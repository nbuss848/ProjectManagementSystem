using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Entities
{
    public class Task
    {
        public Task()
        {
            SubTasks = new HashSet<SubTask>();
        }        
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public DateTime? FrequencyStartDate { get; set; }
        public DateTime? ReminderDate { get; set; }

        public virtual Project Project { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<SubTask> SubTasks { get; set; }
    }
}
