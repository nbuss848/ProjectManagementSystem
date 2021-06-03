using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Application.Common.ViewModels
{
    public class ProjectTaskCreateViewModel
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public DateTime? FrequencyStartDate { get; set; }
        public DateTime? ReminderDate { get; set; }
    }
}
