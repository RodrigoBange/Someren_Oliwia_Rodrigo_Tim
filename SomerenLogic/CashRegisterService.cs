using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class CashRegisterService
    {
        CashRegisterDao cashRegisterdb;

        // Constructor
        public CashRegisterService()
        {
            // Create new CashRegisterDAO object
            cashRegisterdb = new CashRegisterDao();
        }

        public void AddPurchase(CashRegister cashRegister)
        {
            // Create query
            string query = $"INSERT INTO PURCHASES(Student_Id, Drink_Id, Paid_Amount, Purchase_Date, Drinks_Amount) VALUES ('{cashRegister.StudentNumber}','{cashRegister.DrinkNumber}','{cashRegister.PaidAmount}','{cashRegister.PurchaseDate}','{cashRegister.DrinksAmount}');";

            // Add purchases to database
            cashRegisterdb.EditRegister(query);
        }

        public void UpdatePurchase(CashRegister cashRegister)
        {
            // Create query
            string query = $"UPDATE PURCHASES SET Paid_Amount = Paid_Amount + '{cashRegister.PaidAmount}', Purchase_Date = '{cashRegister.PurchaseDate}', Drinks_Amount = Drinks_Amount + '{cashRegister.DrinksAmount}' WHERE Student_Id = '{cashRegister.StudentNumber}' AND Drink_Id = '{cashRegister.DrinkNumber}';";

            // Add purchases to database
            cashRegisterdb.EditRegister(query);
        }

        public bool CheckPurchases(int studentId, int drinkId)
        {
            // Create query
            string query = $"SELECT Student_Id, Drink_Id FROM PURCHASES WHERE Student_Id = '{studentId}' AND Drink_Id = '{drinkId}';";

            // Ask for specific purchase and return if it exists
            return cashRegisterdb.GetPurchases(query);
        }
    }
}
