using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class SuperviseService
    {
        SuperviseDao supervisedb;

        // Constructor
        public SuperviseService()
        {
            // Create new ActivityDAO object
            supervisedb = new SuperviseDao();
        }

        public List<Supervise> GetSupervisors(int activityId)
        {
            // Get all supervisors
            return supervisedb.GetAllSupervisors(activityId);
        }

        public List<Supervise> GetNonSupervisors(int activityId)
        {
            // Get all non supervisors from that activity
            return supervisedb.GetAllNonSupervisors(activityId);
        }

        public void AddSupervisor(int activityId, int employeeId)
        {
            string query = $"INSERT INTO SUPERVISES (Employee_Id, Activity_Id) VALUES({employeeId}, {activityId});";

            // Edit database
            supervisedb.EditSupervisors(query);
        }

        public void RemoveSupervisor(int activityId, int employeeId)
        {
            string query = $"DELETE FROM SUPERVISES WHERE Employee_Id = {employeeId} AND Activity_Id = {activityId};";

            // Edit database
            supervisedb.EditSupervisors(query);
        }
    }
}
