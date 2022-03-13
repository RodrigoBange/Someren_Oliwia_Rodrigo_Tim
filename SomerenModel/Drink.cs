using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        public int Number { get; set; } // Drink's ID
        public string Name { get; set; } // Drink's name
        public decimal Price { get; set; } // Drink's price
        public bool Type { get; set; } // Drink alcoholic or not
        public int Stock { get; set; } // Drink stock
        public int AmountSold { get; set; } // Drink amount sold
    }
}
