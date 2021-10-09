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
        private CustomerRepo _customerRepo = new CustomerRepo();

        public void Run()
        {
            SeedCustomerList();
            Menu();
        }

        //MENU
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                //display menu
                Console.WriteLine("\nKomodo Customers\n\n" +
                    "Choose an option from the menu below:\n\n" +
                    "1. Add new customer\n" +
                    "2. View all customers\n" +
                    "3. Find customer by ID\n" +
                    "4. Update existing customer\n" +
                    "5. Delete existing customer\n" +
                    "6. EXIT");

                //prompt for selection
                string input = Console.ReadLine();

                //evaluate selection and do what is needed
                switch (input)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        ViewListOfCustomers();
                        break;
                    case "3":
                        FindCustomerById();
                        break;
                    case "4":
                        UpdateCustomerOnList();
                        break;
                    case "5":
                        RemoveCustomerFromList();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }


        }
        private void CreateCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();
            //first name
            Console.WriteLine("Enter the customer's first name:");
            newCustomer.FirstName = Console.ReadLine();

            //last name
            Console.WriteLine("Enter the customer's last name:");
            newCustomer.LastName = Console.ReadLine();

            //customer type
            Console.WriteLine("What type of customer are they? Choose from menu below:\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);
            newCustomer.TypeOfCustomer = (CustomerType)inputAsInt;

            //phone number
            Console.WriteLine("Enter the customer's phone number:");
            newCustomer.PhoneNumber = Console.ReadLine();

            //location
            Console.WriteLine("Enter the customer's location:");
            newCustomer.Location = Console.ReadLine();

            _customerRepo.AddCustomer(newCustomer);
        }
        private void ViewListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("First Name" + "\t" + "Last Name" + "\t" + "Type" + "\t\t" + "Email\n\n");
            List<Customer> listOfCustomers = _customerRepo.ViewCustomers();
            //var sortedList = listOfCustomers.OrderBy(x => x).ToList();
            //listOfCustomers.Sort();
            foreach (Customer customer in listOfCustomers)
            {
                Console.WriteLine($"{customer.FirstName} \t {customer.LastName} \t { customer.TypeOfCustomer}");
            }
        }
        private void FindCustomerById()
        {
            Console.Clear();

            //prompt for full name
            Console.WriteLine("Enter the id of the customer you wish to view:");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);

            //find customer
            Customer customer = _customerRepo.GetCustomerById(inputAsInt);

            //display customer's info
            Console.Clear();
            if(customer != null)
            {
                Console.WriteLine($"First Name: {customer.FirstName}\n\n" +
                    $"Last Name: {customer.LastName}\n\n" +
                    $"Phone Number: {customer.PhoneNumber}\n\n" +
                    $"Location: {customer.Location}\n\n" +
                    $"Type: {customer.TypeOfCustomer}\n\n");
            }
            else
            {
                Console.WriteLine("No customer found by that name.");
            }
        }

        private void UpdateCustomerOnList()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the customer you would like to update:");
            string oldCustomerAsString = Console.ReadLine();
            int oldCustomer = int.Parse(oldCustomerAsString);

            Customer newCustomer = new Customer();
            //first name
            Console.WriteLine("Enter the customer's first name:");
            newCustomer.FirstName = Console.ReadLine();

            //last name
            Console.WriteLine("Enter the customer's last name:");
            newCustomer.LastName = Console.ReadLine();

            //customer type
            Console.WriteLine("What type of customer are they? Choose from menu below:\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);
            newCustomer.TypeOfCustomer = (CustomerType)inputAsInt;

            //phone number
            Console.WriteLine("Enter the customer's phone number:");
            newCustomer.PhoneNumber = Console.ReadLine();

            //location
            Console.WriteLine("Enter the customer's location:");
            newCustomer.Location = Console.ReadLine();

            bool wasUpdated = _customerRepo.UpdateCustomer(oldCustomer, newCustomer);

            if(wasUpdated)
            {
                Console.WriteLine("Customer was updated.");
            }
            else
            {
                Console.WriteLine("Customer could not be updated.");
            }
        }
        private void RemoveCustomerFromList()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the customer you would like to remove:");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);

            bool wasRemoved = _customerRepo.DeleteCustomer(inputAsInt);

            if(wasRemoved)
            {
                Console.WriteLine("Customer successfully removed.");
            }
            else
            {
                Console.WriteLine("Could not remove customer.");
            }
        }

        //SEED METHOD
        private void SeedCustomerList()
        {
            Customer customerOne = new Customer("Andrew", "Smith", CustomerType.Current, "3171234567", "Fishers, IN", 1);
            Customer customerTwo = new Customer("Katherine", "Jones", CustomerType.Past, "7651230987", "Anderson, IN", 2);
            Customer customerThree = new Customer("Chelsea", "Wilson", CustomerType.Potential, "2195679876", "Fort Wayne, IN", 3);
            Customer customerFour = new Customer("Nathaniel", "Johnson", CustomerType.Current, "3179987644", "Indianapolis, IN", 4);

            _customerRepo.AddCustomer(customerOne);
            _customerRepo.AddCustomer(customerTwo);
            _customerRepo.AddCustomer(customerThree);
            _customerRepo.AddCustomer(customerFour);

        }

        //send email method
        private void SendEmailToCustomer()
        {
            Customer customer = new Customer();
            switch(customer)
        }
    }
}
