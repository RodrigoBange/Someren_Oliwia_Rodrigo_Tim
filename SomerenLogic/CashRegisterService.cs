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
        public void AddPurchase(int studentId, int drinkId, decimal paidAmount,DateTime purchaseDate)
        {
            // Create query
            string query = $"INSERT INTO PURCHESES(Student_Id, Drink_Id, Paid_Amount, Purchase_Date) VALUES ('{studentId}','{drinkId}','{paidAmount}''{purchaseDate}',0);";

            // Add purcheses to database
            cashRegisterdb.AddPurchase(query);
        }
    }
}
