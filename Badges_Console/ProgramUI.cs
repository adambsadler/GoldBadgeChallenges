using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            SeedBadges();
            MainMenu();
        }

        // Main Menu
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("*****                                *****");
            Console.WriteLine("***          Komodo Insurance          ***");
            Console.WriteLine("**            Security Admin            **");
            Console.WriteLine("***                                    ***");
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome! Please select from the options below:\n" +
                "1. Create New Badge\n" +
                "2. Display All Badges\n" +
                "3. Update a Badge\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            bool validInput = false;
            while (validInput == false)
            {
                switch (userInput)
                {
                    case "1":
                        validInput = true;
                        CreateNewBadge();
                        break;
                    case "2":
                        validInput = true;
                        DisplayAllBadges();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "3":
                        validInput = true;
                        UpdateBadge();
                        break;
                    case "4":
                        validInput = true;
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Security Admin Application.");
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

        // Method to create a new badge and add it to the dictionary
        private void CreateNewBadge()
        {
            Console.Clear();

            Badge newBadge = new Badge();

            Console.WriteLine("Enter the ID for this badge:");
            newBadge.BadgeID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name for this badge:");
            newBadge.Name = Console.ReadLine();

            bool anotherDoor = false;
            do
            {
                Console.WriteLine("Enter the door this badge needs access to:");
                newBadge.DoorNames.Add(Console.ReadLine());
                Console.WriteLine("Does this badge need access to another door? (y/n)");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                        anotherDoor = true;
                        break;
                    case "n":
                        anotherDoor = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response. Does this badge need access to another door? (y/n)");
                        userInput = Console.ReadLine();
                        break;
                }
            } while (anotherDoor);

            _badgeRepo.CreateBadge(newBadge);
            Console.WriteLine("The new badge has been successfully created. Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method to display all badges in the dictionary
        private void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> allBadges = _badgeRepo.GetBadges();

            foreach (var badge in allBadges)
            {
                int id = badge.Key;
                List<string> doors = badge.Value;

                Console.WriteLine($"Badge ID: {id}");
                Console.WriteLine($"Door Access: {string.Join(", ", doors)}");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        // Method to edit the doors associated with a specified badge
        private void UpdateBadge()
        {
            Console.Clear();
            DisplayAllBadges();

            Console.WriteLine("Enter the ID for the badge to update:");
            int oldBadge = Int32.Parse(Console.ReadLine());
            bool doesExist = _badgeRepo.BadgeExists(oldBadge);
            while (doesExist == false)
            {
                Console.WriteLine("That badge ID does not exist. Please enter a valid badge ID:");
                doesExist = _badgeRepo.BadgeExists(Int32.Parse(Console.ReadLine()));
            }

            List<string> oldDoors = _badgeRepo.GetValuesByKey(oldBadge);
            Console.Clear();
            Console.WriteLine($"Badge {oldBadge} has acess to {string.Join(", ", oldDoors)}.");
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Return to the main menu");
            var userInput = Console.ReadLine();
            bool validInput = false;

            while (validInput == false)
            {
                switch (userInput)
                {
                    case "1":
                        validInput = true;
                        Console.WriteLine("Enter the name of the door you would like to remove:");
                        var doorToRemove = Console.ReadLine();
                        bool wasRemoved = _badgeRepo.RemoveDoor(oldBadge, doorToRemove);
                        if (wasRemoved)
                        {
                            Console.WriteLine($"{doorToRemove} has been removed from this badge.");
                        }
                        else
                        {
                            Console.WriteLine("That door is not associated with this badge.");
                        }
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "2":
                        validInput = true;
                        Console.WriteLine("Enter the name of the door you would like to add:");
                        var doorToAdd = Console.ReadLine();
                        _badgeRepo.AddDoor(oldBadge, doorToAdd);
                        Console.WriteLine($"{doorToAdd} has be added to this badge.");
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "3":
                        validInput = true;
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option:");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }

        // Seed method
        private void SeedBadges()
        {
            List<string> basicDoors = new List<string>();
            basicDoors.Add("Entrance");
            basicDoors.Add("First Floor");
            Badge associateBadge = new Badge(1001, basicDoors, "Associate");

            List<string> adminDoors = new List<string>();
            adminDoors.Add("Entrance");
            adminDoors.Add("First Floor");
            adminDoors.Add("Elevators");
            adminDoors.Add("Second Floor");
            Badge adminBadge = new Badge(2009, adminDoors, "Administrator");

            _badgeRepo.CreateBadge(associateBadge);
            _badgeRepo.CreateBadge(adminBadge);
        }
    }
}
