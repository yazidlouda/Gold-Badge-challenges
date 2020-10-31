using Cafe.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.UI
{
    public class ProgramUI
    {
        private MenuRepository _order = new MenuRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("The Komodo Cafe!\n" +
                    "\n" +
                    "1. See all orders\n" +
                    "2. Add an order\n" +
                    "3. Remove an order\n");
                Console.ResetColor();

                string Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":

                        SeeAllOrders();
                        break;
                    case "2":
                        AddeOrderToMenu();
                        break;
                    case "3":
                        RemoveOrderFromMenu();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                }
            }
        }

        public void SeeAllOrders()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            List<Menu> ItemList = _order.ListOrders();

            foreach (Menu content in ItemList)
            {
                Console.WriteLine($"{content.OrderNumber}- {content.OrderName}\n" +
                    $"Description: {content.OrderDescription}\n" +
                    $"Ingredients: {content.OrderIngredients}\n" +
                    $"Price: ${content.OrderPrice}");
            }

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
            Console.ResetColor();
            Console.ReadLine();
        }


        public void AddeOrderToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Menu content = new Menu();

            Console.Clear();

            Console.WriteLine("Enter the new meal number: ");
            content.OrderNumber = int.Parse(Console.ReadLine());


            Console.Clear();

            Console.WriteLine("Enter the item's name: ");
            content.OrderName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Enter a description for {content.OrderName}: ");
            content.OrderDescription = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Enter the ingrediants for {content.OrderName}: ");
            content.OrderIngredients = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Enter the Price for {content.OrderName}: ");
            content.OrderPrice = double.Parse(Console.ReadLine());


            Console.Clear();


            Console.WriteLine("Order Summary:\n");

            Console.WriteLine($"Item Number: {content.OrderNumber}\n" +
                $"Name: {content.OrderName}\n" +
                $"Description: {content.OrderDescription}\n" +
                $"Ingrediants: {content.OrderIngredients}\n" +
                $"Price: ${content.OrderPrice}");

            Console.WriteLine("Press any key to confirm order");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Order successfully added!\n" +
                "Press any key to continue...");
            Console.ReadKey();

            _order.AddOrder(content);
            Console.ResetColor();

        }

        public void RemoveOrderFromMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("What order would you like to remove?\n\n" +
                "(Select item number)\n");

            List<Menu> menuList = _order.ListOrders();

            foreach (Menu order in menuList)
            {
                Console.WriteLine($"#{order.OrderNumber} - {order.OrderName}\n");
            }

            int removeOrder = int.Parse(Console.ReadLine());

            Menu menuObject = _order.getdOrderByNumber(removeOrder);

            _order.RemoveOrder(menuObject);

            Console.WriteLine("Order successfully removed!\n" +
            "Press any key to continue...");

            Console.ReadKey();
            Console.ResetColor();

        }
        public void SeedContent()
        {
            Menu chickenFettuccineAlfredo = new Menu(1, "Chicken Fettuccine Alfredo", "Fettuccine pasta tossed with our rich and creamy Alfredo sauce.", "Grilled chicken,green pepper, red pepper,saisoned rice,alfredo sauce.", 9.99);
            Menu smotheredChoppedSteak = new Menu(2, "Smothered Chopped Steak", "A half chopped angus steak smothered with sauteed mushrooms. ", "Angus Steak, mushrooms,onions.green pepper,Swiss and American cheeses.", 9.79);
            Menu grilledChickenSalad = new Menu(3, "Grilled chicken salad", "Mixed greens with chicken salad.", "Chicken,tomatos,green peppers,cucumber,boiled egges.", 7.99);
            Menu mediteraneanSalad = new Menu(4, "Mediterranean salad", "Exotic salad.", "greens,feta cheese,olives,tomatos,green peppers,cucumber,boiled egges.", 5.99);


            _order.AddOrder(chickenFettuccineAlfredo);
            _order.AddOrder(smotheredChoppedSteak);
            _order.AddOrder(grilledChickenSalad);
            _order.AddOrder(mediteraneanSalad);

        }
    }
}
