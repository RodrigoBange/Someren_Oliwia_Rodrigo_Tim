using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class CashRegister 
    {
        // Properties
        public int StudentNumber { get; set; } // Student's ID
        public int DrinkNumber { get; set; } // Drink's ID
        public decimal PaidAmount { get; set; } // Paid Amount
        public DateTime PurchaseDate { get; set; } // Date of Purchase
        public int DrinksAmount { get; set; } // Amount of Drinks
    }
}
