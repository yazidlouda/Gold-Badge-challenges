using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.UI
{
    class ProgramUI
    {
        private KomodoBadgesRepo _badges = new KomodoBadgesRepo();
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
                Console.WriteLine("Komodo Badges!\n" +
                    "\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges \n");
                string Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":

                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                }
            }
        }
        public void AddABadge()
        {

            Badges content = new Badges();

            Dictionary<int, List<string>> _doors = new Dictionary<int, List<string>>();
            List<string> _door = new List<string>();

            Console.WriteLine("What is the new badge number: ");
            content.BadgeID = int.Parse(Console.ReadLine());

          
            Console.Clear();

            Console.WriteLine("Add a door to this badge: ");
           

            _door.Add(Console.ReadLine());
            _doors.Add(content.BadgeID, _door);

            foreach (KeyValuePair<int, List<string>> kvp in _doors)
            {
                foreach (string value in kvp.Value)
                {
                    Console.WriteLine("Badge = {0}, Door = {1}", kvp.Key, value);
                }

            }
            Console.WriteLine("any other door" + " " + "(Y/N )");

            string YesNo = Console.ReadLine().ToUpper();

            if (YesNo == "Y")
                
            {
                Console.WriteLine("Enter door name");

                _door.Add(Console.ReadLine());
               
                foreach (KeyValuePair<int, List<string>> kvp in _doors)
                {
                    foreach (string value in kvp.Value)
                    {
                        Console.WriteLine("Badge = {0}, Door = {1}", kvp.Key, value);
                    }


                }
            Console.WriteLine("any other door" + " " + "(Y/N )");
            YesNo = Console.ReadLine();


            }
            else if (YesNo=="N")
            {
                RunMenu();
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("List all badge view:\n");
        }



        public void EditABadge()
        {



        }




        public void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeList = _badges.GetDictionary();

            foreach (KeyValuePair<int, List<string>> badge in badgeList) 
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
                
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();


        }



        public void SeedContent()
        {
            Badges badgeNumberOne = new Badges(12345, new List<string> { "A7" });
            Badges badgeNumberTwo = new Badges(22345, new List<string> { "A1", "A4","B1","B2" });
            Badges badgeNumberThree = new Badges(32345, new List<string> { "A4","A5" });

            _badges.AddBadge(badgeNumberOne);
            _badges.AddBadge(badgeNumberTwo);
            _badges.AddBadge(badgeNumberThree);



        }
    }
}
