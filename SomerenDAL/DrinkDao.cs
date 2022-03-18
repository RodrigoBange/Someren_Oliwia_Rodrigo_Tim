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
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            // Create query
            string query = "SELECT Drink_Id, Drink_Name, Drink_Price, Drink_Type, Drink_Amount_Sold, Drink_Stock FROM DRINK ORDER BY Drink_Name";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Return result of query
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            // Create new list of Drink objects
            List<Drink> drinks = new List<Drink>();

            try
            {
                // For each data row, set all data to new Drink object
                foreach (DataRow dr in dataTable.Rows)
                {
                    Drink drink = new Drink()
                    {
                        Number = (int)dr["Drink_Id"],
                        Name = (string)dr["Drink_Name"],
                        Price = (decimal)dr["Drink_Price"],
                        Type = (bool)dr["Drink_Type"],
                        AmountSold = (int)dr["Drink_Amount_Sold"],
                        Stock = (int)dr["Drink_Stock"]
                    };
                    // Add new Drink object to list of Drinks
                    drinks.Add(drink);
                }
            }
            catch (Exception e)
            {
                throw new Exception("There is an issue reading the drinks data from the database.");
            }

            // Return list of drinks objects
            return drinks;
        }

        public void EditDrinks(string query)
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // Execute query
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
