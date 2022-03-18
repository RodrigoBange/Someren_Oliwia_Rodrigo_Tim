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
    public class CashRegisterDao : BaseDao
    {

        private List<CashRegister> ReadTables(DataTable dataTable)
        {
            // Create new list of Cash Register objects
            List<CashRegister> cashRegister = new List<CashRegister>();
    
            try
            {
                // For each data row, set data to all Student objects from StudentDao
                foreach (DataRow dr in dataTable.Rows)
                {
                    StudentDao studentDao = new StudentDao();
                    {
                       studentDao.GetAllStudents();
                    };
                }

                // For each data row, set data to all Drink objects from DrinkDao
                foreach (DataRow dr in dataTable.Rows)
                {
                    DrinkDao drinkDao = new DrinkDao();
                    {
                        drinkDao.GetAllDrinks();
                    };
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the students or drinks from the database.");
            }

            // Return list of Cash Register objects
            return cashRegister;
        }
        public void AddPurchase(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}


