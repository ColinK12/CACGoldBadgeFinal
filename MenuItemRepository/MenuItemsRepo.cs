using MenuItemPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItemRepository
{
    public class MenuItemsRepo
    {
        //Field
        public List<MenuItems> _WholeMenu = new List<MenuItems>();//claims

        //Create
        public void AddMenuItemToList(MenuItems meal)//claims
        {
            _WholeMenu.Add(meal);
            // _WholeMenu.Count();
        }

        //Read
        public List<MenuItems> GetMenuItems()  //claims
        {
            return _WholeMenu;
        }

        //Delete
        public bool RemoveMenuItemFromListById(int mealIdNumber)
        {
            MenuItems mealToRemove = GetMenuItemsByMealIdNumber(mealIdNumber);

            int startCount = _WholeMenu.Count;
            _WholeMenu.Remove(mealToRemove);

            if(startCount > _WholeMenu.Count)
            {
                return true;
            }
            return false;
        }

        //Helper
        private MenuItems GetMenuItemsByMealIdNumber(int mealIdNumber)
        {
            foreach (MenuItems meal in _WholeMenu)
            {
                if (mealIdNumber == meal.MealNumber)
                {
                    return meal;
                }
            }
            return null;
        }

    }
}
