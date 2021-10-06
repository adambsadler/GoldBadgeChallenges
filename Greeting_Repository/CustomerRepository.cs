using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class CustomerRepository
    {
        private List<Customer> _customerRepo = new List<Customer>();
        private int _countId;

        // Create
        public void CreateNewCustomer(Customer newCustomer)
        {
            // Checks to see what type of customer it is and then assigns the appropriate greeting
            switch(newCustomer.CustomerType)
            {
                case TypeOfCustomer.Current:
                    newCustomer.Greeting = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case TypeOfCustomer.Past:
                    newCustomer.Greeting = "It's been a long time since we've heard from you, we want you back.";
                    break;
                case TypeOfCustomer.Potential:
                    newCustomer.Greeting = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
            }
            newCustomer.IdNumber = ++_countId;
            _customerRepo.Add(newCustomer);
        }

        // Read
        public List<Customer> GetAllCustomers()
        {
            return _customerRepo;
        }

        // Update
        public bool UpdateCustomerInfo(int id, Customer newCustomer)
        {
            Customer oldCustomer = FindCustomerByID(id);

            if(oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.CustomerType = newCustomer.CustomerType;
                switch(newCustomer.CustomerType)
                {
                    case TypeOfCustomer.Current:
                        newCustomer.Greeting = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    case TypeOfCustomer.Past:
                        newCustomer.Greeting = "It's been a long time since we've heard from you, we want you back.";
                        break;
                    case TypeOfCustomer.Potential:
                        newCustomer.Greeting = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveCustomer(int id)
        {
            Customer customer = FindCustomerByID(id);

            if(customer == null)
            {
                return false;
            }

            int initialCount = _customerRepo.Count;
            _customerRepo.Remove(customer);

            if(initialCount > _customerRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper method
        public Customer FindCustomerByID(int customerId)
        {
            foreach(Customer customer in _customerRepo)
            {
                if(customer.IdNumber == customerId)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
