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
    public class TeacherService
    {
        // Variables
        TeacherDao teacherdb;

        // Constructor
        public TeacherService()
        {
            // Create new TeacherDAO object
            teacherdb = new TeacherDao();
        }

        public List<Teacher> GetTeachers()
        {
            // Create new Teacher object list and return the list
            List<Teacher> teachers = teacherdb.GetAllTeachers();
            return teachers;
        }
    }
}
