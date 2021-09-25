using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedItems();
            MainMenu();
        }

        // Main Menu
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("*****                                *****");
            Console.WriteLine("***             Komodo Cafe            ***");
            Console.WriteLine("**            Menu Management           **");
            Console.WriteLine("***                                    ***");
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome! Please select from the options below:\n" +
                "1. Create New Menu Item\n" +
                "2. Display All Menu Items\n" +
                "3. Delete Menu Item\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            bool validInput = false;
            while(validInput == false)
            {
                switch(userInput)
                {
                    case "1": // Create New Menu Item
                        validInput = true;
                        CreateNewMenuItem();
                        break;
                    case "2": // Display All Menu Items
                        validInput = true;
                        DisplayMenuItems();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "3": // Delete Menu Item
                        validInput = true;
                        DeleteMenuItem();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "4": // Exit the program
                        validInput = true;
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Menu Management Application.");
                        Console.WriteLine("Developed by Adam Sadler");
                        Console.WriteLine("Please press any key to close the program.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please select a valid option\n" +
                            "1. Create New Menu Item\n" +
                            "2. Display All Menu Items\n" +
                            "3. Delete Menu Item\n" +
                            "4. Exit");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }

        // Method to create a new menu item and add it to the list of menu items
        private void CreateNewMenuItem()
        {
            Console.Clear();

            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter the number for this new menu item:");
            newMenuItem.MealNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name for this new menu item:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description for this new menu item:");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("How many ingredients are in this new menu item?");
            int numberOfIngredients = Int32.Parse(Console.ReadLine());
            while(numberOfIngredients > 0)
            {
                Console.WriteLine("Enter the name of the ingredient");
                Ingredient newIngredient = new Ingredient(Console.ReadLine());
                _menuRepo.CreateIngredient(newIngredient);
                newMenuItem.Ingredients.Add(newIngredient);
                numberOfIngredients--;
            }

            Console.WriteLine("Enter the price of this new menu item:");
            newMenuItem.MealPrice = Decimal.Parse(Console.ReadLine());

            _menuRepo.CreateMenuItem(newMenuItem);
            Console.WriteLine($"{newMenuItem.MealName} has successfully been created.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Method to display all menu items
        private void DisplayMenuItems()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuRepo.GetMenuItems();

            foreach(Menu item in listOfItems)
            {
                List<Ingredient> itemIngredient = _menuRepo.GetItemIngredients(item);
                Console.WriteLine($"Meal Number: {item.MealNumber}");
                Console.WriteLine($"Meal Name: {item.MealName}");
                Console.WriteLine($"Meal Description: {item.MealDescription}");
                Console.WriteLine($"Meal Price: {item.MealPrice}");
                Console.WriteLine("Ingredients:");
                foreach(Ingredient ingredient in itemIngredient)
                {
                    Console.WriteLine(ingredient.Name);
                }
                Console.WriteLine("----------------------------------------------------");
            }
        }

        // Method to delete a menu item
        private void DeleteMenuItem()
        {
            DisplayMenuItems();

            Console.WriteLine("Enter the number of the meal to delete:");
            int oldNumber = Int32.Parse(Console.ReadLine());

            bool wasDeleted = _menuRepo.DeleteMenuItem(oldNumber);

            if(wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted. Please try again.");
            }
        }

        // Seed Method
        private void SeedItems()
        {
            Ingredient beefPatty = new Ingredient("Beef Patty");
            Ingredient bun = new Ingredient("Bun");
            Ingredient porkSausage = new Ingredient("Pork Sausage");
            Ingredient cheese = new Ingredient("Cheese");
            Ingredient lettuce = new Ingredient("Lettuce");
            Ingredient mustard = new Ingredient("Mustard");
            Ingredient pickle = new Ingredient("Pickle");
            _menuRepo.CreateIngredient(beefPatty);
            _menuRepo.CreateIngredient(bun);
            _menuRepo.CreateIngredient(porkSausage);
            _menuRepo.CreateIngredient(cheese);
            _menuRepo.CreateIngredient(lettuce);
            _menuRepo.CreateIngredient(mustard);
            _menuRepo.CreateIngredient(pickle);
            List<Ingredient> cheeseBurgerToppings = new List<Ingredient>();
            List<Ingredient> hotDogToppings = new List<Ingredient>();

            cheeseBurgerToppings.Add(cheese);
            cheeseBurgerToppings.Add(lettuce);
            cheeseBurgerToppings.Add(beefPatty);
            cheeseBurgerToppings.Add(bun);
            hotDogToppings.Add(porkSausage);
            hotDogToppings.Add(bun);
            hotDogToppings.Add(mustard);
            hotDogToppings.Add(pickle);
            Menu cheeseBurger = new Menu(1, "Cheeseburger", "A juicy all beef patty, cooked to perfection.", cheeseBurgerToppings, 6.99m);
            Menu hotDog = new Menu(2, "Hot Dog", "A premium pork hot dog on a toasted bun.", hotDogToppings, 3.99m);

            _menuRepo.CreateMenuItem(cheeseBurger);
            _menuRepo.CreateMenuItem(hotDog);
        }
    }
}
