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
        public string Description { get; set; } // Activity description
        public DateTime StartDate { get; set; } // Activity start date and time
        public DateTime EndDate { get; set; } // Activity end date and time 
    }
}
