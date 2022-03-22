using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activity
    {
        public int Number { get; set; } // Activity ID
        public string Name { get; set; } // Activity name
        public string Description { get; set; }
        public DateTime StartDate { get; set; } // 
        public DateTime EndDate { get; set; } // 
    }
}
