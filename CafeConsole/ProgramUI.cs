using MenuItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole
{
    public class ProgramUI
    {
        MenuItemsRepo menuItemsRepo = new MenuItemsRepo();
        MenuItemPOCO menuItemPOCO = new MenuItemPOCO(); //Pos. Problem Future?
        public void Run()
        {
            Menu();
            Console.WriteLine("Welcome to Komodo Insurance Cafe\n" +
                "What would you like to do? Please make your selection below.");
            Console.Clear();
        }
        //Menu Method
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display input Evaluate u input
                Console.WriteLine("Welcome to Komodo Insurance Cafe\n" +
                 "What would you like to do? Please make your NUMBER selection below:\n" +
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
            menuItemPOCO. = Console.ReadLine();



            Console.WriteLine("Enter the Name of the Menu Item you'd like to Add.");
            menuItemPOCO.MealName = Console.ReadLine();



            Console.WriteLine("Enter a DESCRIPTION of the Menu Item you'd like to Add.");
            menuItemPOCO.MealDescription = Console.ReadLine();



            Console.WriteLine("Enter the Price of the Menu Item you'd like to Add.");
            string priceAsString = Console.ReadLine();
            menuItemPOCO.CostOfMeal = double.Parse(priceAsString);





        }   
            
        private void DeleteAMenuItem()
        {

        }

        private void SeeAllMenuItems()
    {

    }



    }
}
