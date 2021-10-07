using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuItemsRepo
    {
        private List<MenuItems> _listOfMenuItems = new List<MenuItems>();

        //CREATE
        public void AddMenuItem(MenuItems menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }

        //READ
        public List<MenuItems> ViewMenuItems()
        {
            return _listOfMenuItems;
        }


        //HELPER METHOD
        public MenuItems GetItemByName(string mealName)
        {
            foreach(MenuItems menuItem in _listOfMenuItems)
            {
                if(menuItem.MealName.ToLower() == mealName.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }


        //DELETE
        public bool RemoveMenuItem(string mealName)
        {
            MenuItems menuItem = GetItemByName(mealName);

            if(menuItem == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItem);
            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
