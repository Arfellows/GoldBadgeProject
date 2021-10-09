using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Greeting_Tests
{
    [TestClass]
    public class CustomerRepoTests
    {
        private readonly CustomerRepo _repo = new CustomerRepo();

        [TestMethod]
        public void AddCustomer_ShouldGetNotNull()
        {
            Customer customer = new Customer();
            customer.Id = 1;
            CustomerRepo repository = new CustomerRepo();

            repository.AddCustomer(customer);
            Customer customerFromDirectory = repository.GetCustomerById(1);

            Assert.IsNotNull(customerFromDirectory);
        }

        [TestMethod]
        public void GetCustomerById_CustomerDoesNotExist_ReturnNull()
        {
            Customer customer = new Customer("Andrew", "Smith", CustomerType.Current, "3171234567", "Fishers, IN", 1);
            CustomerRepo repo = new CustomerRepo();
            repo.AddCustomer(customer);
            int id = 3;

            Customer result = repo.GetCustomerById(id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCustomerById_CustomerDoesExist_ReturnNotNull()
        {
            Customer customer = new Customer("Andrew", "Smith", CustomerType.Current, "3171234567", "Fishers, IN", 1);
            CustomerRepo repo = new CustomerRepo();
            repo.AddCustomer(customer);
            int id = 1;

            Customer result = repo.GetCustomerById(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateCustomer_CustomerDoesNotExist_ReturnFalse()
        {
            int id = 654;
            Customer updateCustomer = new Customer("Andrew", "Smith", CustomerType.Current, "3171234567", "Fishers, IN", 1);

            bool result = _repo.UpdateCustomer(id, updateCustomer);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateCustomer_CustomerDoesExist_ReturnTrue()
        {
            int id = 1;
            Customer updateCustomer = new Customer("Andrew", "Smith", CustomerType.Current, "3171234567", "Fishers, IN", 1);

            bool result = _repo.UpdateCustomer(id, updateCustomer);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteCustomer_CustomerDoesNotExist_ReturnFalse()
        {
            int id = 654;
           

            bool result = _repo.DeleteCustomer(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteCustomer_CustomerDoesExist_ReturnTrue()
        {
            int id = 1;
            

            bool result = _repo.DeleteCustomer(id);

            Assert.IsTrue(result);
        }
    }
}
