using Greeting_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Console
{
    class ProgramUI
    {
        private CustomerRepository _customerRepo = new CustomerRepository();

        public void Run()
        {
            SeedCustomers();
            MainMenu();
        }

        // Main Menu
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("*****                                *****");
            Console.WriteLine("***          Komodo Insurance          ***");
            Console.WriteLine("**      Customer Email Management       **");
            Console.WriteLine("***                                    ***");
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome! Please select from the options below:\n" +
                "1. See All Customers\n" +
                "2. Add a New Customer\n" +
                "3. Update Customer Information\n" +
                "4. Delete a Customer\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            bool validInput = false;

            while (validInput == false)
            {
                switch(userInput)
                {
                    case "1":
                        validInput = true;
                        DisplayAllCustomers();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "2":
                        validInput = true;
                        CreateNewCustomer();
                        break;
                    case "3":
                        validInput = true;
                        UpdateCustomerInfo();
                        break;
                    case "4":
                        validInput = true;
                        DeleteCustomer();
                        break;
                    case "5":
                        validInput = true;
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Customer Email Management application.");
                        Console.WriteLine("Developed by Adam Sadler");
                        Console.WriteLine("Please press any key to close the program.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please Select a valid option.\n" +
                             "1. See All Customers\n" +
                             "2. Add a New Customer\n" +
                             "3. Update Customer Information\n" +
                             "4. Delete a Customer\n" +
                             "5. Exit");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }

        // Display all customers
        private void DisplayAllCustomers()
        {
            Console.Clear();
            List<Customer> allCustomers = _customerRepo.GetAllCustomers();
            var sortedList = from customer in allCustomers orderby customer.LastName ascending select customer;
            foreach(Customer customer in sortedList)
            {
                Console.WriteLine($"Customer ID: {customer.IdNumber}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Customer Type: {customer.CustomerType}");
                Console.WriteLine($"Email: {customer.Greeting}");
                Console.WriteLine("--------------------------------------------------------------------------------------");
            }
        }

        // Add a new customer to the list
        private void CreateNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            Console.WriteLine("Select the type of customer:\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCustomer.CustomerType = (TypeOfCustomer)typeAsInt;

            Console.WriteLine("Enter the customer's first name:");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the customer's last name:");
            newCustomer.LastName = Console.ReadLine();

            _customerRepo.CreateNewCustomer(newCustomer);

            Console.WriteLine("This new customer has been added. Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Update customer information
        private void UpdateCustomerInfo()
        {
            DisplayAllCustomers();

            Console.WriteLine("Enter the ID of the customer to update:");

            int oldCustomer = Int32.Parse(Console.ReadLine());

            Customer newCustomer = new Customer();

            Console.Clear();

            Console.WriteLine("Select the type of customer:\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCustomer.CustomerType = (TypeOfCustomer)typeAsInt;

            Console.WriteLine("Enter the customer's first name:");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the customer's last name:");
            newCustomer.LastName = Console.ReadLine();

            bool wasUpdated = _customerRepo.UpdateCustomerInfo(oldCustomer, newCustomer);

            if(wasUpdated)
            {
                Console.WriteLine("The information for this customer has been udpated.");
            }
            else
            {
                Console.WriteLine("We could not update this information. Please try again.");
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Delete a customer from the list
        private void DeleteCustomer()
        {
            DisplayAllCustomers();

            Console.WriteLine("Enter the ID of the customer to update:");

            int oldCustomer = Int32.Parse(Console.ReadLine());

            bool wasDeleted = _customerRepo.RemoveCustomer(oldCustomer);

            if(wasDeleted)
            {
                Console.WriteLine("This customer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("We could not delete this customer. Please try again.");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            MainMenu();
        }

        // Seed customers to list
        private void SeedCustomers()
        {
            Customer customerOne = new Customer("Adam", "Sadler", TypeOfCustomer.Current);
            _customerRepo.CreateNewCustomer(customerOne);

            Customer customerTwo = new Customer("Allyssa", "Perry", TypeOfCustomer.Past);
            _customerRepo.CreateNewCustomer(customerTwo);

            Customer customerThree = new Customer("Elaine", "Scott", TypeOfCustomer.Potential);
            _customerRepo.CreateNewCustomer(customerThree);
        }
    }
}
