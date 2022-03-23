using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class ActivityService
    {
        ActivityDao activitydb;

        // Constructor
        public ActivityService()
        {
            // Create new ActivityDAO object
            activitydb = new ActivityDao();
        }

        public List<Activity> GetActivities()
        {
            // Return list of activities 
            return activitydb.GetAllActivities();
        }

        public void AddActivity(string activityName, string description, DateTime startDate, DateTime endDate)
        {
            // Create query
            string query = $"INSERT INTO ACTIVITY(Activity_Name, Description, Start_Date, End_Date) VALUES ('{activityName}','{description}','{startDate}','{endDate}');";

            // Add activity to database
            activitydb.EditActivity(query);
        }
        public void ChangeActivity(int activityId, string activityName, string  description, DateTime startDate, DateTime endDate)
        {
            // Create query
            string query = $"UPDATE ACTIVITY SET Activity_Name = '{activityName}', Description = '{description}', Start_Date = '{startDate}', End_Date = '{endDate}' WHERE Activity_Id = '{activityId}';";

            // Change activity from database
            activitydb.EditActivity(query);
        }

            public void RemoveActivity(int activityId)
        {
            // Create query
            string query = $"DELETE FROM ACTIVITY WHERE Activity_Id = '{activityId}';";

            // Remove activity from database
            activitydb.EditActivity(query);
        }
  
    }
}
