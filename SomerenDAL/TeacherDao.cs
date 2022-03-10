using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class TeacherDao : BaseDao
    {
        public List<Teacher> GetAllTeachers()
        {
            // Create query
            string query = "SELECT Employee_Id, First_Name, Last_Name, Supervises FROM TEACHER";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            // Create new list of Teacher objects
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                // For each data row, set all data to new Teacher object
                foreach (DataRow dr in dataTable.Rows)
                {
                    Teacher teacher = new Teacher()
                    {
                        Number = (int)dr["Employee_Id"],
                        FirstName = (string)(dr["First_Name"].ToString()),
                        LastName = (string)(dr["Last_Name"].ToString()),
                        Supervises = (bool)(dr["Supervises"])
                    };
                    // Add new Teacher object to list of Teachers
                    teachers.Add(teacher);
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the teacher data from the database.");
            }


            // Return list of Teacher objects
            return teachers;
        }
    }
}
