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
    public class StudentDao : BaseDao
    {      
        public List<Student> GetAllStudents()
        {
            // Create query
            string query = "SELECT Student_Id, First_Name, Last_Name, Birth_Date FROM STUDENT";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            // Create new list of Student objects
            List<Student> students = new List<Student>();

            try
            {
                // For each data row, set all data to new Student object
                foreach (DataRow dr in dataTable.Rows)
                {
                    Student student = new Student()
                    {
                        Number = (int)dr["Student_Id"],
                        FirstName = (string)(dr["First_Name"].ToString()),
                        LastName = (string)(dr["Last_Name"].ToString()),
                        BirthDate = (DateTime)(dr["Birth_Date"])
                    };
                    // Add new Student object to list of Students
                    students.Add(student);
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the student data from the database.");
            }
           
            
            // Return list of Student objects
            return students;
        }
    }
}
