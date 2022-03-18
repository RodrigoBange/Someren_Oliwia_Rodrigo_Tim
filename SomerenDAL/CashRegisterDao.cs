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
        public void EditRegister(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        public bool GetPurchases(string query)
        {
            // Create query
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private bool ReadTables(DataTable dataTable)
        {
            try
            {
                // Return if table has values
                if (dataTable == null) { return false; }
                else { return true; }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the purchases data from the database.");
            }
        }
    }
}


