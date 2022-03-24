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

            // Update teacher status
            UpdateSuperviseStatus();
        }

        public void RemoveSupervisor(int activityId, int employeeId)
        {
            string query = $"DELETE FROM SUPERVISES WHERE Employee_Id = {employeeId} AND Activity_Id = {activityId};";

            // Edit database
            supervisedb.EditSupervisors(query);

            // Update teacher status
            UpdateSuperviseStatus();
        }

        private void UpdateSuperviseStatus()
        {
            //First query to update all who supervise in TEACHERS
            string query = $"UPDATE TEACHER SET TEACHER.Supervises = 1 FROM SUPERVISES JOIN TEACHER ON SUPERVISES.Employee_Id = TEACHER.Employee_Id;";

            // Edit database
            supervisedb.EditSupervisors(query);

            // Second query to update all who don't supervise in TEACHERS
            string secondQuery = $"UPDATE TEACHER SET TEACHER.Supervises = 0 FROM TEACHER LEFT JOIN SUPERVISES ON TEACHER.Employee_Id = SUPERVISES.Employee_Id WHERE SUPERVISES.Employee_id IS NULL;";

            // Edit database
            supervisedb.EditSupervisors(secondQuery);
        }
    }
}
