using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public int Number { get; set; } // Teacher's ID
        public string FirstName { get; set; } // Teacher's first name
        public string LastName { get; set; } // Teacher's last name
        public bool Supervises { get; set; } // Teacher supervises
    }
}
