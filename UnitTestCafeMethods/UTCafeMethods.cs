using MenuItemPOCO;
using MenuItemRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCafeMethods
{
    [TestClass]
    public class UnitTestCafeMethods
    {
        MenuItemsRepo menuItemsRepo = new MenuItemsRepo();
        MenuItems menuItemsPOCO = new MenuItems();

        [TestMethod]
        public void AddMenuItemToListWorking()
        {
            MenuItems menuItem = new MenuItems(1, "Ruben, with fries and a drink.", "Ruben w/ fries and a drink.", 5.99, null);
            int menuItemCount = menuItemsRepo._WholeMenu.Count;

            menuItemsRepo.AddMenuItemToList(menuItem);

            Assert.AreNotEqual(menuItemCount, menuItemsRepo._WholeMenu.Count);

        }
        [TestMethod]
        public void RemoveMenuItemFromListByIdNotWorking()
        {
            int menuItemId = 1;

            bool result = menuItemsRepo.RemoveMenuItemFromListById(menuItemId);

            Assert.IsFalse(result);
        }
        [TestMethod]

        public void RemoveMenuItemFromListByIdWorking()
        {

            MenuItems menuItem = new MenuItems(1, "Ruben, with fries and a drink.", "Ruben w/ fries and a drink.", 5.99, null);
            menuItemsRepo.AddMenuItemToList(menuItem);


            bool result = menuItemsRepo.RemoveMenuItemFromListById(menuItem.MealNumber);

            Assert.IsTrue(result);
        }
    }
}
