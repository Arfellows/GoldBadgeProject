using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuItemsRepoTests
    {
        //CREATE/ADD METHOD
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            MenuItems menuItem = new MenuItems();
            menuItem.MealName = "Tacos";
            MenuItemsRepo repo = new MenuItemsRepo();

            repo.AddMenuItem(menuItem);
            MenuItems itemFromDirectory = repo.GetItemByName("Tacos");

            Assert.IsNotNull(itemFromDirectory);
        }

        //READ METHOD
        [TestMethod]
        public void ViewList_ShouldGetNotNull()
        {

        }

        //DELETE METHOD
        [TestMethod]
        public void RemoveItem_ShouldReturnTrue()
        {

        }
    }
}
