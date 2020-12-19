using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models.SubTasks
{
    public class SubTaskCreateViewModel
    {
        public int TaskId { get; internal set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
    }
}
