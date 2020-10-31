using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static KomodoClaims.Claim;

namespace KomodoClaims.UI
{
   public class ProgramUI
    {
        private ClaimRepository _claim = new ClaimRepository();
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
                Console.WriteLine("Komodo Claims!\n" +
                    "\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim \n");
                string Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":

                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddANewClaim();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                }
            }
        }
       
        public void SeeAllClaims()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Queue<Claim> claimList = _claim.ClaimList();

            foreach (Claim content in claimList)
            {
                Console.WriteLine($"{content.ClaimID}- {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"ClaimAmount: ${content.ClaimAmount}\n" +
                    $"DateOfIncident: {content.DateOfIncident}\n"+
                    $"DateOfClaim: {content.DateOfClaim}\n"+
                    $"IsValid: {content.IsValid}\n");


            }

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
            Console.ResetColor();
            Console.ReadLine();
        }

        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details on the next claim to be handled: \n");

            Queue<Claim> newList = _claim.ClaimList();
            Claim nextClaim = newList.Peek();

            Console.WriteLine($"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Incident Date: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Claim Date: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Do you want to take this claim? (y/n)");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("You have successfully taken the claim\n" +
                        "Press any key to continue...");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter y or n");
                    break;
            }
           
            Console.ReadLine();
        }




        public void AddANewClaim()
        {
            Claim content = new Claim();

            Console.Clear();

            Console.WriteLine("Enter the new claim number: ");
            content.ClaimID = int.Parse(Console.ReadLine());


            Console.Clear();

            Console.WriteLine("Enter type of claim:\n" +
                "1.Car \n" + 
                "2.Home \n" +
                "3.Theft \n" );

            string typeNumber = Console.ReadLine();
            switch (typeNumber)
            {
                case "1":
                    content.ClaimType = TypeClaim.Car;
                    break;
                case "2":
                    content.ClaimType = TypeClaim.Home;
                    break;
                case "3":
                    content.ClaimType = TypeClaim.Theft;
                    break;
            }

            Console.Clear();

            Console.WriteLine($"Enter a description for {content.ClaimType}: ");
            content.Description = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Enter the claim amount for {content.ClaimType}: ");
            content.ClaimAmount = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine($"Enter the date of incident for {content.ClaimType}: ");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());


            Console.Clear();

            Console.WriteLine($"Enter the date of claim for {content.ClaimType}: ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Clear();


            if (content.DateOfClaim <= content.DateOfIncident.AddDays(30))
            {
                content.IsValid = true;
            }
            else
                content.IsValid = false;
            Console.WriteLine("Claim Summary:\n");

            Console.WriteLine($"Item Number: {content.ClaimID}\n" +
                $"ClaimID: {content.ClaimID}\n" +
                $"ClaimType: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"ClaimAmount: ${content.ClaimAmount}\n" +
                $"DateOfIncident: {content.DateOfIncident.ToShortDateString()}\n" +
                $"DateOfClaim: {content.DateOfClaim.ToShortDateString()}\n"+
                $"IsValid: {content.IsValid}");
            Console.ReadKey();


            Console.WriteLine("Press any key to confirm claim");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Claim successfully added!\n" +
                "Press any key to continue...");
            Console.ReadKey();

            _claim.AddClaim(content);
            Console.ResetColor();

        }


        public void SeedContent()
        {
            Claim claimOne = new Claim(1, TypeClaim.Car, "Accident on I465", 400, DateTime.Parse("04/25/2018"), DateTime.Parse("4/27/2018"), true);
            Claim claimTwo = new Claim(2, TypeClaim.Home, "House fire in kitchen", 4000, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"), true);
            Claim claimThree = new Claim(3, TypeClaim.Theft, "Stolen pancakes", 4, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);

            _claim.AddClaim(claimOne);
            _claim.AddClaim(claimTwo);
            _claim.AddClaim(claimThree);
        }
    }
}
