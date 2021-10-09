using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuItemsRepoTests
    {
        
        [TestMethod]
        public void AddMenuItem_IsNotNull()
        {
            MenuItems menuItem = new MenuItems();
            menuItem.MealName = "Tacos";
            MenuItemsRepo repo = new MenuItemsRepo();

            repo.AddMenuItem(menuItem);
            MenuItems itemFromDirectory = repo.GetItemByName("Tacos");

            Assert.IsNotNull(itemFromDirectory);
        }
  
        [TestMethod]
        public void GetItemByName_MenuItemDoesNotExist_ReturnNull()
        {
            MenuItems menuItem = new MenuItems(1, "Lasagna", "Owner's favorite! Classic Italian dish made with marinara meat sauce and lasagna noodles.", 13.99, "Lasagna noodles, Marinara meat sauce, Italian seasoning, Garlic, Ricotta cheese, Mozzarella cheese, Parmesan cheese, Oregano, and Basil.");
            MenuItemsRepo repo = new MenuItemsRepo();
            repo.AddMenuItem(menuItem);
            string mealName = "Pizza";

            MenuItems result = repo.GetItemByName(mealName);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void GetItemByName_MenuItemDoesExist_ReturnNotNull()
        {
            MenuItems menuItem = new MenuItems(1, "Lasagna", "Owner's favorite! Classic Italian dish made with marinara meat sauce and lasagna noodles.", 13.99, "Lasagna noodles, Marinara meat sauce, Italian seasoning, Garlic, Ricotta cheese, Mozzarella cheese, Parmesan cheese, Oregano, and Basil.");
            MenuItemsRepo repo = new MenuItemsRepo();
            repo.AddMenuItem(menuItem);
            string mealName = "Lasagna";

            MenuItems result = repo.GetItemByName(mealName);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RemoveMenuItem_MenuItemIsNull_ReturnFalse()
        {
            string name = "Pizza";
            MenuItems menuItem = new MenuItems(1, "Lasagna", "Owner's favorite! Classic Italian dish made with marinara meat sauce and lasagna noodles.", 13.99, "Lasagna noodles, Marinara meat sauce, Italian seasoning, Garlic, Ricotta cheese, Mozzarella cheese, Parmesan cheese, Oregano, and Basil.");
            MenuItemsRepo repo = new MenuItemsRepo();

            bool result = repo.RemoveMenuItem(name);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveMenuItem_MenuItemIsNotNull_ReturnTrue()
        {
            string name = "Lasagna";
            MenuItems menuItem = new MenuItems(1, "Lasagna", "Owner's favorite! Classic Italian dish made with marinara meat sauce and lasagna noodles.", 13.99, "Lasagna noodles, Marinara meat sauce, Italian seasoning, Garlic, Ricotta cheese, Mozzarella cheese, Parmesan cheese, Oregano, and Basil.");
            MenuItemsRepo repo = new MenuItemsRepo();

            bool result = repo.RemoveMenuItem(name);

            Assert.IsTrue(result);
        }
    }
}
