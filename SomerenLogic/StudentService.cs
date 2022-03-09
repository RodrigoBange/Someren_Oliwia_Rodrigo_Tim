using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class StudentService
    {
        // Variables
        StudentDao studentdb;

        // Constructor
        public StudentService()
        {
            // Create new StudentDAO object
            studentdb = new StudentDao();
        }

        public List<Student> GetStudents()
        {
            // Create new Student object list and return the list
            List<Student> students = studentdb.GetAllStudents();
            return students;
        }
    }
}
