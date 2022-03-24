using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class SuperviseDao : BaseDao
    {
        public List<Supervise> GetAllSupervisors(int activityId)
        {
            // Create query
            string query = $"SELECT S.Employee_Id, S.Activity_Id, T.First_Name, T.Last_Name FROM SUPERVISES AS S JOIN TEACHER AS T ON S.Employee_Id = T.Employee_Id WHERE S.Activity_Id = {activityId};";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTablesSupervises(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Supervise> GetAllNonSupervisors(int activityId)
        {
            // Create query
            string query = $"SELECT T.Employee_Id, T.First_Name, T.Last_Name, ISNULL(S.Activity_Id, 0) AS 'Activity_Id' FROM TEACHER AS T LEFT JOIN SUPERVISES AS S ON S.Employee_Id = T.Employee_Id WHERE S.Employee_Id IS NULL OR S.Activity_Id != {activityId}; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTablesNonSupervisors(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Supervise> ReadTablesSupervises(DataTable dataTable)
        {
            // Create new list of Supervise objects
            List<Supervise> supervisors = new List<Supervise>();

            try
            {
                // For each data row, set all data to new Supervise object
                foreach (DataRow dr in dataTable.Rows)
                {
                    Supervise supervise = new Supervise()
                    {
                        EmployeeId = (int)dr["Employee_Id"],
                        ActivityId = (int)dr["Activity_Id"],
                        FirstName = (string)dr["First_Name"],
                        LastName = (string)dr["Last_Name"]
                    };
                    // Add new Supervise object to list of supervisors
                    supervisors.Add(supervise);
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the supervisors data from the database.");
            }

            // Return list of drinks objects
            return supervisors;
        }

        private List<Supervise> ReadTablesNonSupervisors(DataTable dataTable)
        {
            // Create new list of Supervise objects
            List<Supervise> supervisors = new List<Supervise>();

            try
            {
                // For each data row, set all data to new Drink object
                foreach (DataRow dr in dataTable.Rows)
                {
                    Supervise supervise = new Supervise()
                    {
                        EmployeeId = (int)dr["Employee_Id"],
                        FirstName = (string)dr["First_Name"],
                        LastName = (string)dr["Last_Name"],
                        ActivityId = (int)dr["Activity_Id"]
                    };
                    // Add new Supervise object to the list of supervisors
                    supervisors.Add(supervise);
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the non-supervisors data from the database.");
            }

            // Return list of Supervise objects
            return supervisors;
        }

        public void EditSupervisors(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
