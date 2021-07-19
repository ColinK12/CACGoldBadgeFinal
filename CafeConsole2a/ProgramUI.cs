using MenuItemPOCO;
using MenuItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole2a
{
    public class ProgramUI
    {
        MenuItemsRepo menuItemsRepo = new MenuItemsRepo();
        MenuItems menuItemPOCO = new MenuItems(); 
        public void Run()
        {
            Menu();
        }
        //Menu Method
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display input Evaluate user input
                Console.WriteLine("Welcome to Komodo Insurance Cafe\n" +
                 "What would you like to do?\n"+
                 "Please make your NUMBER selection below:\n" +
                "1. Add A new Menu Item\n" +
                "2. Delete A Menu Item\n" +
                "3. See ALL Menu Items\n" +
                "4. EXIT");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Add
                        AddANewMenuItem();
                        break;
                    case "2": //Delete
                        DeleteAMenuItem();
                        break;
                    case "3": //See All
                        SeeAllMenuItems();
                        break;
                    case "4": //Exit
                        Console.WriteLine("Thanks for using the Komodo Cafe App. Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid NUMBER.");
                        break;
                }

                Console.WriteLine("Please Press Enter To Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddANewMenuItem()//Create
        {
            Console.WriteLine("Enter the NUMBER of the Menu Item you'd like to Add.");
            string numberAsString = Console.ReadLine();
            menuItemPOCO.MealNumber = int.Parse(numberAsString);

            Console.WriteLine("Enter the Name of the Menu Item you'd like to Add.");
            menuItemPOCO.MealName = Console.ReadLine();

            Console.WriteLine("Enter a DESCRIPTION of the Menu Item you'd like to Add.");
            menuItemPOCO.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the Price of the Menu Item you'd like to Add.");
            string priceAsString = Console.ReadLine();
            menuItemPOCO.CostOfMeal = double.Parse(priceAsString);

            Console.WriteLine("Enter an ingredient to ADD to your list.");
            string ingredient1 = Console.ReadLine();
            menuItemPOCO._Ingredients.Add(ingredient1);


            bool ingredientToAdd = true;
            while (ingredientToAdd == true)
            {
                Console.WriteLine("Do you want to enter more ingredients? (y/n)");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    Console.WriteLine("Enter the ingredient.");
                    string addIngredient = Console.ReadLine();
                    menuItemPOCO._Ingredients.Add(addIngredient);
                }
                else
                {
                    ingredientToAdd = false;
                }

            }
            menuItemsRepo.AddMenuItemToList(menuItemPOCO);
        }

        private void DeleteAMenuItem()
        {

            SeeAllMenuItems();

            Console.WriteLine("\nEnter Menu Item Number you wouldlike to Remove?");
            string userInputAsString = Console.ReadLine();
            int userInput = int.Parse(userInputAsString);


            bool wasDeleted = menuItemsRepo.RemoveMenuItemFromListById(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("The Menu Item was successfully taken off.");
            }
            else
            {
                Console.WriteLine("The Menu Item could not be deleted.");
            }
        }

        private void SeeAllMenuItems()
        {
            Console.Clear();

            List<MenuItems> listOfAllMenuItems = menuItemsRepo.GetMenuItems();
      
            foreach (MenuItems _wholeMenu in listOfAllMenuItems )
            {
                Console.WriteLine($"Showing Meal Name: {_wholeMenu.MealName}\n" +
                    $"Showing Meal Number: {_wholeMenu.MealNumber}\n" +
                    $"Showing Meal Description: {_wholeMenu.MealDescription}\n" +
                    $"Showing Price Of Meal: {_wholeMenu.CostOfMeal}\n");
                DisplayIngredientsList();
            }
        }

        public void DisplayIngredientsList()//Study
        {
            foreach(string ingredient in menuItemPOCO._Ingredients)
            {
                Console.WriteLine($"List of ingredients: {ingredient}");
            }
        }

    }
}
