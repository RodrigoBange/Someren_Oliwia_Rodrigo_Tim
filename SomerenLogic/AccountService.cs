using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class AccountService
    {
        AccountDao accountdb; 

        // Constructor
        public AccountService()
        {
            // Create new AccountDao Object
            accountdb = new AccountDao();
        }

        public void RegisterAccount(Account user)
        {
            // Convert bool to byte
            byte isAdmin = Convert.ToByte(user.IsAdmin);

            // Create query
            string query = $"INSERT INTO USERS(Email, Password, Salt, IsAdmin) VALUES ('{user.Email}', '{user.Password}', '{user.Salt}', {isAdmin});";

            // Add to database
            accountdb.EditAccounts(query);
        }

        public Account GetUserInfo(string email)
        {
            // Create query
            string query = $"SELECT Email, Password, Salt, IsAdmin FROM USERS WHERE Email = '{email}';";

            // Get account information from database
            Account account = accountdb.GetUserInfo(query);

            // Return account
            return account;
        }
    }
}
