using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Entities
{
    public class Frequency
    {
        public int FrequencyId { get; set; }
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
    }
}
