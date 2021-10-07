using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuItems
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Ingredients { get; set; }

        public MenuItems() { }

        public MenuItems(int mealNumber, string mealName, string description, double price, string ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }      
    }
}
