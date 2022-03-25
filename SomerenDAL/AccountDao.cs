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
    public class AccountDao : BaseDao
    {
        public Account GetUserInfo(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public void EditAccounts(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        private Account ReadTable(DataTable dataTable)
        {
            // Create new Account object
            Account account = new Account();

            try
            {
                // If an account has been found...
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    account.Email = (string)row["Email"];
                    account.Password = (string)row["Password"];
                    account.Salt = (string)row["Salt"];
                    account.IsAdmin = (bool)row["IsAdmin"];
                }
                else
                {
                    account = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the user data from the database.");
            }

            // Return the account data
            return account;
        }
    }
}
