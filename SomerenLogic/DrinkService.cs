using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class DrinkService
    {
        DrinkDao drinkdb;

        // Constructor
        public DrinkService()
        {
            // Create new DrinkDAO object
            drinkdb = new DrinkDao();
        }

        public List<Drink> GetDrinks()
        {
            // Return list of drinks
            return drinkdb.GetAllDrinks();
        }

        public void AddDrink(string drinkName, decimal drinkPrice, int drinkStock, bool drinkType)
        {
            // Create query
            string query = $"INSERT INTO DRINK(Drink_Name, Drink_Price, Drink_Type, Drink_Stock, Drink_Amount_Sold) VALUES ('{drinkName}','{drinkPrice}','{drinkType}','{drinkStock}',0);";
            
            // Add drink to database
            drinkdb.EditDrinks(query);
        }

        public void RemoveDrink(int drinkId)
        {
            // Create query
            string query = $"DELETE FROM DRINK WHERE Drink_Id = '{drinkId}';";

            // Remove drink from database
            drinkdb.EditDrinks(query);
        }

        public void EditDrink(int drinkId, string drinkName, decimal drinkPrice, bool drinkType, int drinkStock)
        {
            // Create query
            string query = $"UPDATE DRINK SET Drink_Name = '{drinkName}', Drink_Price = '{drinkPrice}', Drink_Type = '{drinkType}', Drink_Stock = '{drinkStock}' WHERE Drink_Id = '{drinkId}';";

            // Edit drink from database
            drinkdb.EditDrinks(query);
        }

        public void UpdateStock(int drinkId, int drinksAmount)
        {
            // Create query
            string query = $"UPDATE DRINK SET Drink_Stock=Drink_Stock-'{drinksAmount}', Drink_Amount_Sold=Drink_Amount_Sold+'{drinksAmount}' WHERE Drink_Id='{drinkId}';";

            // Edit drink from database
            drinkdb.EditDrinks(query);
        }
    }
}
