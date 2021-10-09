using Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Console
{
    class ProgramUI
    {
        private OutingsRepo _outingsRepo = new OutingsRepo();
        List<Outings> listOfOutings = new List<Outings>();
        public void Run()
        {
            SeedOutingList();
            Menu();
        }

        //MENU
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                //display options
                Console.WriteLine("\nKomodo Outings\n\n" +
                    "Please select an option from the menu below:\n\n" +
                    "1. View list of outings\n" +
                    "2. Add outing to list\n" +
                    "3. Individual outing information\n" +
                    "4. Total Cost for All Events\n" +
                    "5. EXIT");

                //prompt for input
                string input = Console.ReadLine();

                //do what they are requesting
                switch (input)
                {
                    case "1":
                        ViewListOfOutings();
                        break;
                    case "2":
                        AddOutingToList();
                        break;
                    case "3":
                        ViewIndividualEvent();
                        break;
                    case "4":
                        GetSumOfTotalCost();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ViewListOfOutings()
        {
            Console.Clear();
            List<Outings> listOfOutings = _outingsRepo.ViewOutings();
            foreach (Outings outing in listOfOutings)
            {
                Console.WriteLine($"{outing.Name}    {outing.Date}\n");
            }
            
        }
        private void AddOutingToList()
        {
            Console.Clear();
            Outings newOuting = new Outings();

            //name
            Console.WriteLine("Create an name for the outing:");
            newOuting.Name = Console.ReadLine();

            //number of ppl
            Console.WriteLine("How many people will be attending this outing?");
            string number = Console.ReadLine();
            newOuting.NumberOfPeople = int.Parse(number);

            //date
            Console.WriteLine("What is the date of this outing? (01/01/2000)");
            string dateOfOuting = Console.ReadLine();
            newOuting.Date = DateTime.Parse(dateOfOuting);

            //total cost
            Console.WriteLine("What is the total cost of this outing?");
            string costAsString = Console.ReadLine();
            newOuting.TotalCost = double.Parse(costAsString);

            //total cost per person
            Console.WriteLine("What is the total cost per person?");
            string costPerPerson = Console.ReadLine();
            newOuting.TotalCostPerPerson = double.Parse(costPerPerson);

            //event type
            Console.WriteLine("Choose the type of outing from the list below:\n\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. AmusementPark\n" +
                "4. Concert");
            string outingAsString = Console.ReadLine();
            int outingAsInt = int.Parse(outingAsString);
            newOuting.TypeOfEvent = (EventType)outingAsInt;
            _outingsRepo.AddOuting(newOuting);
            listOfOutings.Add(newOuting);
        }
        private void ViewIndividualEvent()
        {
            Console.Clear();
            ViewListOfOutings();
            //prompt for name
            Console.WriteLine("Enter the name of the outing you would like to view:");
            string input = Console.ReadLine().ToLower();

            //find event
            Outings outing = _outingsRepo.ViewOutingByName(input);

            //display event info
            Console.Clear();
            if (outing != null)
            {
                Console.WriteLine($"Outing: {outing.Name}\n\n" +
                    $"Date of Outing: {outing.Date}\n\n" +
                    $"Number of People Attending: {outing.NumberOfPeople}\n\n" +
                    $"Type of Outing: {outing.TypeOfEvent}\n\n" +
                    $"Total Cost: {outing.TotalCost}\n\n" +
                    $"Total Cost Per Person: {outing.TotalCost / outing.NumberOfPeople}\n");
            }
            else
            {
                Console.WriteLine("No outing found by that name.");
            }
        }
        //private void ViewCostBreakdown()
        //{
        //    Console.Clear();
        //    Outings outing = new Outings();
        //    //double total = new double();

        //    Console.WriteLine("\nThis page is to show the breakdown of costs.\n\n" +
        //        "Total Cost by Event Type\n" +
        //        $"Golf: \n" +
        //        $"Bowling: \n" +
        //        $"Amusement Parks: \n" +
        //        $"Concerts: \n\n" +
        //        $"Total Cost Combined: " );

            
        //}

        //SEED METHOD
        private void SeedOutingList()
        {
            Outings outingOne = new Outings("Bird's Eye View", 150, new DateTime(2022, 6, 8, 10, 30, 0), 1680.00, 11.20, EventType.Golf);
            Outings outingTwo = new Outings("The Bowling Stones", 96, new DateTime(2021, 12, 15, 16, 45, 0), 800.00, 8.33, EventType.Bowling);
            Outings outingThree = new Outings("King's Island Adventure Day", 78, new DateTime(2022, 5, 14, 9, 00, 0), 1950.00, 25.00, EventType.AmusementPark);
            Outings outingFour = new Outings("Phish", 54, new DateTime(2022, 8, 21, 17, 30, 0), 1350.00, 25.00, EventType.Concert);

            _outingsRepo.AddOuting(outingOne);
            _outingsRepo.AddOuting(outingTwo);
            _outingsRepo.AddOuting(outingThree);
            _outingsRepo.AddOuting(outingFour);
            listOfOutings.Add(outingOne);
            listOfOutings.Add(outingTwo);
            listOfOutings.Add(outingThree);
            listOfOutings.Add(outingFour);
        }

        private void GetSumOfTotalCost()
        {
            Console.Clear();

            var total = listOfOutings.Sum(item => item.TotalCost);
            Console.WriteLine($"Total Cost: {total}");

        }


    }
}
