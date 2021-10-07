using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuItemsRepo _menuRepo = new MenuItemsRepo();

        public void Run()
        {
            SeedMenuItems();
            Menu();
        }

        //MENU
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                //Display menu options
                Console.WriteLine("\nWelcome to the Komodo Cafe Menu Editor\n\n" +
                    "Choose an option below:\n\n\n" +
                    "A. Create a new menu item\n" +
                    "B. View all menu items\n" +
                    "C. Meal information\n" +
                    "D. Delete a menu item\n" +
                    "E. EXIT");

                //Prompt for input
                string input = Console.ReadLine().ToUpper();

                //Evalute input and do what you gotta do
                switch (input)
                {
                    case "A":
                        CreateNewItem();
                        break;
                    case "B":
                        ViewItems();
                        break;
                    case "C":
                        ViewByName();
                        break;
                    case "D":
                        RemoveItem();
                        break;
                    case "E":
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

        private void CreateNewItem()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();

            //meal number
            Console.WriteLine("What number will this item be on the menu?");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);
                        
            //meal name
            Console.WriteLine("What is the name of this new menu item?");
            newItem.MealName = Console.ReadLine();

            //description
            Console.WriteLine("Write a description for this menu item:");
            newItem.Description = Console.ReadLine();

            //price
            Console.WriteLine("What is the price for this menu item?");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            //ingredients
            Console.WriteLine("What are the ingredients?");
            newItem.Ingredients = Console.ReadLine();

            _menuRepo.AddMenuItem(newItem);
        }

        private void ViewItems()
        {
            Console.Clear();
            List<MenuItems> listOfItems = _menuRepo.ViewMenuItems();
            foreach(MenuItems menuItem in listOfItems)
            {
                Console.WriteLine($"Meal # {menuItem.MealNumber}: {menuItem.MealName}");
            }
        }

        private void ViewByName()
        {
            Console.Clear();
            //prompt for name of meal
            Console.WriteLine("What meal would you like information on?");
            string input = Console.ReadLine();

            //find meal
            MenuItems item = _menuRepo.GetItemByName(input); 
            
            //display meal info
            if(item != null)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Price: {item.Price}\n" +
                    $"Ingredients: {item.Ingredients}");
            }
            else
            {
                Console.WriteLine("That meal does not exist.");
            }

        }

        private void RemoveItem()
        {
            Console.Clear();
            ViewItems();

            //ask what meal to delete
            Console.WriteLine("What meal would you like to remove?");
            string input = Console.ReadLine();
            //delete method
            bool wasRemoved = _menuRepo.RemoveMenuItem(input);

            //was content deleted
            if(wasRemoved)
            {
                Console.WriteLine("The menu item was removed.");
            }
            else
            {
                Console.WriteLine("Menu item could not be removed.");
            }
        }

        //SEED METHOD
        private void SeedMenuItems()
        {
            MenuItems menuItemOne = new MenuItems(1, "Lasagna", "Owner's favorite! Classic Italian dish made with marinara meat sauce and lasagna noodles.", 13.99, "Lasagna noodles, Marinara meat sauce, Italian seasoning, Garlic, Ricotta cheese, Mozzarella cheese, Parmesan cheese, Oregano, and Basil.");
            MenuItems menuItemTwo = new MenuItems(2, "Chicken Fettuccine with Mushrooms", "Our creamy, homeade alfredo sauce over a bed of fettuccine noodles and topped with chargrilled chicken.", 13.99, "Fettuccine noodles, Heavy cream, Garlic, Parmesan cheese, Cream cheese, Pepper, Chicken, Mushrooms.");
            MenuItems menuItemThree = new MenuItems(3, "Basil Pesto", "Linguine noodles with our award-winning basil pesto sauce. You won't want to miss this one!", 11.99, "Linguine noodles, basil, pine nuts, salt and pepper, parmesan cheese, garlic.");

            _menuRepo.AddMenuItem(menuItemOne);
            _menuRepo.AddMenuItem(menuItemTwo);
            _menuRepo.AddMenuItem(menuItemThree);
        }
    }
}
