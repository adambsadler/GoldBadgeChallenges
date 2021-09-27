using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            SeedClaims();
            MainMenu();
        }

        // Main Menu
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("*****                                *****");
            Console.WriteLine("***          Komodo Insurance          ***");
            Console.WriteLine("**        Claims Management Tool        **");
            Console.WriteLine("***                                    ***");
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome! Please select from the options below:\n" +
                "1. See All Claims\n" +
                "2. Process Next Claim\n" +
                "3. Enter a New Claim\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            bool validInput = false;

            while(validInput == false)
            {
                switch(userInput)
                {
                    case "1": // See All Claims
                        validInput = true;
                        DisplayAllClaims();
                        break;
                    case "2": // Process Next Claim
                        validInput = true;
                        ShowNextClaim();
                        break;
                    case "3": // Enter a New Claim
                        validInput = true;
                        CreateClaim();
                        break;
                    case "4": // Exit the program
                        validInput = true;
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Claims Management Tool.");
                        Console.WriteLine("Developed by Adam Sadler");
                        Console.WriteLine("Please press any key to close the program.");
                        Console.ReadKey();
                        break;
                    default: // If user inputs an invalid number
                        Console.Clear();
                        Console.WriteLine("Please Select a valid option.\n" +
                            "1. See All Claims\n" +
                            "2. Process Next Claim\n" +
                            "3. Enter a New Claim\n" +
                            "4. Exit");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }

        // Method to display all current claims in the queue
        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> currentClaims = _claimRepo.GetAllClaims();
            foreach(Claim claim in currentClaims)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Claim ID: {claim.ClaimID}");
                Console.WriteLine($"Type: {claim.ClaimType}");
                Console.WriteLine($"Description: {claim.Description}");
                Console.WriteLine($"Amount: ${claim.ClaimAmount}");
                Console.WriteLine($"Date of Incident: {claim.DateOfIncident.ToString("d")}");
                Console.WriteLine($"Date of Claim: {claim.DateOfClaim.ToString("d")}");
                Console.WriteLine($"Claim is valid: {claim.IsValid}");
                Console.WriteLine("--------------------------------------------");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method for showing next claim in the queue
        private void ShowNextClaim()
        {
            Console.Clear();
            var nextClaim = _claimRepo.SeeNextClaim();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}");
            Console.WriteLine($"Type: {nextClaim.ClaimType}");
            Console.WriteLine($"Description: {nextClaim.Description}");
            Console.WriteLine($"Amount: ${nextClaim.ClaimAmount}");
            Console.WriteLine($"Date of Incident: {nextClaim.DateOfIncident.ToString("d")}");
            Console.WriteLine($"Date of Claim: {nextClaim.DateOfClaim.ToString("d")}");
            Console.WriteLine($"Claim is valid: {nextClaim.IsValid}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Press 1 to process this claim or press 2 to return to the main menu:");

            string userInput = Console.ReadLine();
            bool validInput = false;
            while (validInput == false)
            {
                switch(userInput)
                {
                    case "1":
                        validInput = true;
                        _claimRepo.ProcessClaim(nextClaim);
                        Console.WriteLine("This claim has been processed. Press any key to return to the main menu.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "2":
                        validInput = true;
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }

        // Method for creating a new claim
        private void CreateClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Queue<Claim> claimQueue = _claimRepo.GetAllClaims();

            Console.WriteLine("Enter the ID for this claim:");
            newClaim.ClaimID = Int32.Parse(Console.ReadLine());

            foreach(Claim claim in claimQueue)
            {
                if(newClaim.ClaimID == claim.ClaimID)
                {
                    bool duplicateId = true;

                    while(duplicateId)
                    {
                        Console.WriteLine("This ID is already in use. Please enter a valid ID for this claim:");
                        newClaim.ClaimID = Int32.Parse(Console.ReadLine());

                        if(newClaim.ClaimID != claim.ClaimID)
                        {
                            duplicateId = false;
                        }
                    }
                }
            }

            Console.WriteLine("Enter the type for this claim:");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter the description of this claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount for this claim:");
            newClaim.ClaimAmount = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident for this claim (yyyy/mm/dd):");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of this claim (yyyy/mm/dd):");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            TimeSpan expirationDate = newClaim.DateOfClaim - newClaim.DateOfIncident;

            if(expirationDate.TotalDays <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.CreateNewClaim(newClaim);
            Console.WriteLine("This new claim has been created and add to the queue.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method to seed claims to the queue
        private void SeedClaims()
        {
            var firstClaimDate = new DateTime(2021, 7, 16);
            var firstClaimDate2 = new DateTime(2021, 7, 22);
            Claim firstClaim = new Claim(1, "Car", "Broken windshield", 624.93m, firstClaimDate, firstClaimDate2, true);

            var secondClaimDate = new DateTime(2020, 5, 9);
            var secondClaimDate2 = new DateTime(2021, 9, 26);
            Claim secondClaim = new Claim(2, "Theft", "Stolen phone", 265.89m, secondClaimDate, secondClaimDate2, false);

            _claimRepo.CreateNewClaim(firstClaim);
            _claimRepo.CreateNewClaim(secondClaim);
        }

    }
}
