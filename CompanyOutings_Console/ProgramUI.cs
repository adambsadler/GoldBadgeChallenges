using CompanyOutings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Console
{
    class ProgramUI
    {
        private OutingRepository _outingRepo = new OutingRepository();

        public void Run()
        {
            SeedOutings();
            MainMenu();
        }

        // Main menu
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("*****                                *****");
            Console.WriteLine("***          Komodo Insurance          ***");
            Console.WriteLine("**          Accounting Services         **");
            Console.WriteLine("***                                    ***");
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome! Please select from the options below:\n" +
                "1. Create a new Company Outing\n" +
                "2. Display All Company Outings\n" +
                "3. Show Total Cost of All Company Outings\n" +
                "4. Show Cost of Company Outings by Event Type\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            bool validInput = false;

            while(validInput == false)
            {
                switch(userInput)
                {
                    case "1":
                        validInput = true;
                        CreateOuting();
                        break;
                    case "2":
                        validInput = true;
                        DisplayAllOutings();
                        break;
                    case "3":
                        validInput = true;
                        ShowTotalCost();
                        break;
                    case "4":
                        validInput = true;
                        ShowCostsByType();
                        break;
                    case "5":
                        validInput = true;
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Accounting Services Application.");
                        Console.WriteLine("Developed by Adam Sadler");
                        Console.WriteLine("Please press any key to close the program.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option:");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }

        // Method to create a new company outing
        private void CreateOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("Select the type of event:\n" +
                "1. Bowling\n" +
                "2. Cookout\n" +
                "3. Softball\n" +
                "4. Golf");
            string eventAsString = Console.ReadLine();
            int eventAsInt = int.Parse(eventAsString);
            newOuting.EventType = (TypeOfEvent)eventAsInt;

            Console.WriteLine("Enter the number of people that attended this outing:");
            newOuting.NumberOfPeople = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of this outing in this format (yyyy/mm/dd):");
            newOuting.DateOfEvent = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cost of this event:");
            newOuting.CostPerPerson = Decimal.Parse(Console.ReadLine());

            newOuting.TotalCost = newOuting.NumberOfPeople * newOuting.CostPerPerson;

            _outingRepo.CreateNewOuting(newOuting);

            Console.WriteLine("This new outing has been created. Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method to display all company outings
        private void DisplayAllOutings()
        {
            Console.Clear();
            List<Outing> allOutings = _outingRepo.GetAllOutings();

            foreach(Outing outing in allOutings)
            {
                Console.WriteLine($"Event Type: {outing.EventType}");
                Console.WriteLine($"Attendance: {outing.NumberOfPeople}");
                Console.WriteLine($"Date of Event: {outing.DateOfEvent.ToString("d")}");
                Console.WriteLine($"Cost per Person: ${outing.CostPerPerson}");
                Console.WriteLine($"Total Cost: ${outing.TotalCost}");
                Console.WriteLine("-------------------------------------------------------");
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method to display the total cost of all company outings
        private void ShowTotalCost()
        {
            Console.Clear();
            List<Outing> allOutings = _outingRepo.GetAllOutings();
            decimal totalCost = _outingRepo.TotalOutingCost(allOutings);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"The total combined cost for all company outings is ${totalCost}");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method to display the costs of outings by type
        private void ShowCostsByType()
        {
            Console.Clear();
            List<Outing> allOutings = _outingRepo.GetAllOutings();
        }

        // Seed method
        private void SeedOutings()
        {
            var firstOutingDate = new DateTime(2021, 3, 17);
            Outing firstOuting = new Outing(TypeOfEvent.Bowling, 6, firstOutingDate, 12m, 72m);

            var secondOutingDate = new DateTime(2021, 6, 21);
            Outing secondOuting = new Outing(TypeOfEvent.Cookout, 18, secondOutingDate, 5, 90m);

            _outingRepo.CreateNewOuting(firstOuting);
            _outingRepo.CreateNewOuting(secondOuting);
        }
    }
}
