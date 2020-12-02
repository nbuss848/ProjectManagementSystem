using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Entities
{
    public class SubTask
    {
        public int SubTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }

        public virtual Status Status { get; set; }
        public virtual Task Task { get; set; }
    }
}
