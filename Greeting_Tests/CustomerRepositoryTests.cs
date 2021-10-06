using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Greeting_Tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repo;
        private Customer _customer;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CustomerRepository();
            _customer = new Customer("Adam", "Sadler", TypeOfCustomer.Current)
            {
                IdNumber = 1
            };
            
        }
        [TestMethod]
        public void CreateNewCustomer_ShouldNotGetNull()
        {
            _repo.CreateNewCustomer(_customer);

            Assert.IsNotNull(_customer);
        }

        [TestMethod]
        public void UpdateCustomerInfo_IsNotNull_ReturnTrue()
        {
            _repo.CreateNewCustomer(_customer);
            Customer newCustomer = new Customer("Allyssa", "Perry", TypeOfCustomer.Past);

            bool wasUpdated = _repo.UpdateCustomerInfo(1, newCustomer);

            Assert.IsTrue(wasUpdated);
        }

        [TestMethod]
        public void UpdateCustomerInfo_IsNotNull_ReturnFalse()
        {
            Customer newCustomer = new Customer("Allyssa", "Perry", TypeOfCustomer.Past);

            bool wasUpdated = _repo.UpdateCustomerInfo(1, newCustomer);

            Assert.IsFalse(wasUpdated);
        }

        [TestMethod]
        public void RemoveCustomer_WasDeleted_ReturnTrue()
        {
            _repo.CreateNewCustomer(_customer);
            bool wasDeleted = _repo.RemoveCustomer(1);

            Assert.IsTrue(wasDeleted);
        }

        [TestMethod]
        public void RemoveCustomer_WasDeleted_ReturnFalse()
        {
            bool wasDeleted = _repo.RemoveCustomer(1);

            Assert.IsFalse(wasDeleted);
        }
    }
}
