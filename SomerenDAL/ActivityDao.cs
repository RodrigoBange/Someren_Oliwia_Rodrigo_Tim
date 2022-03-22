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
    public class ActivityDao : BaseDao
    {
        public List<Activity> GetAllActivities()
        {
            // Create query
            string query = "SELECT Activity_Id, Activity_Name, Description, Start_Date, End_Date FROM ACTIVITY";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            // Create new list of Activity objects
            List<Activity> activities = new List<Activity>();

            try
            {
                // For each data row, set all data to new Activity object
                foreach (DataRow dr in dataTable.Rows)
                {
                    Activity activity = new Activity()
                    {
                        Number = (int)dr["Activity_Id"],
                        Name = (string)dr["Activity_Name"],
                        Description = (string)dr["Description"],
                        StartDate = (DateTime)dr["Start_Date"],
                        EndDate = (DateTime)dr["End_Date"]
                    };
                    // Add new Activity object to list of Activities
                    activities.Add(activity);
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the Activity data from the database.");
            }

            // Return list of Activities 
            return activities;
        }

        public void EditActivity(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}

