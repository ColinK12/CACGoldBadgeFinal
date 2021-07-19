using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItemPOCO
{

    public class MenuItems
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double CostOfMeal { get; set; }
        public List<string> _Ingredients { get; set; } = new List<string>();

        public MenuItems() { }

        public MenuItems(int mealNumber, string mealName, string mealDescription, double costOfMeal, List<string> _ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            CostOfMeal = costOfMeal;
            _Ingredients = _ingredients;

        }
    }
}
