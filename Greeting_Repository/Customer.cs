using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public enum CustomerType
    {
        Potential = 1,
        Current,
        Past
    }
    
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }


        public Customer() { }
        public Customer(string firstName, string lastName, CustomerType typeOfCustomer, string phoneNumber, string location, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
            PhoneNumber = phoneNumber;
            Location = location;
            Id = id;
        }


    }
}
