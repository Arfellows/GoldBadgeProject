using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class CustomerRepo
    {
        private List<Customer> _customers = new List<Customer>();
        //CREATE
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        //READ
        public List<Customer> ViewCustomers()
        {
            return _customers;
        }

        //UPDATE
        public bool UpdateCustomer(int originalId, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerById(originalId);
            if(oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
                oldCustomer.PhoneNumber = newCustomer.PhoneNumber;
                oldCustomer.Location = newCustomer.Location;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool DeleteCustomer(int id)
        {
            Customer customer = GetCustomerById(id);

            if(customer == null)
            {
                return false;
            }
            int initialCount = _customers.Count;
            _customers.Remove(customer);
            
            if(initialCount > _customers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER METHOD
        public Customer GetCustomerById(int id)
        {
            foreach(Customer customer in _customers)
            {
                if(customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
