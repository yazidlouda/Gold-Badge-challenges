using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repo
{
    public class Menu
    {

        public int OrderNumber { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public string OrderIngredients { get; set; }
        public double OrderPrice { get; set; }



        public Menu() { }

        public Menu(int itemNumber, string name, string description, string ingredients, double price)
        {
            OrderNumber = itemNumber;
            OrderName = name;
            OrderDescription = description;
            OrderIngredients = ingredients;
            OrderPrice = price;
        }
    }
}
