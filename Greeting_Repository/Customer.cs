using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public enum TypeOfCustomer
    {
        Current = 1,
        Past,
        Potential
    }
    public class Customer
    {
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfCustomer CustomerType { get; set; }
        public string Greeting { get; set; }

        public Customer() { }

        public Customer(string firstName, string lastName, TypeOfCustomer customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
        }
    }
}
