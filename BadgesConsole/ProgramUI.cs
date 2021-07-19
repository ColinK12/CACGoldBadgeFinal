using BadgesPOCO;
using BadgesRepositiroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsole
{
    public class ProgramUI
    {
        BadgesRepo badgesRepo = new BadgesRepo();
        Badge badgesPoco = new Badge();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.Clear();
                Console.WriteLine("Welcome to Komodo Security *Where Doors Matter!*\n" +
                    "What would you like to do? Please make your Numeric selection below.\n" +
                    "\n1. I would like to Create a New Badge:" +
                    "2. I would like to Update A Badge:\n" +
                    "3. I would like to Delete All Doors from a Badge:\n" +
                    "4. I would Like to see a List with all Badge Numbers and Door Access:\n" +
                    "\n5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": //Add
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateABadge();//
                        break;
                    case "3":
                        ViewListOfAllBagesAndAccess();
                        break;
                    case "4":
                        Console.WriteLine("Thanks for using the Komodo Security App.\n" +
                            "Goodbye.\n" +
                            "Press any key to continue.\n");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid NUMBER Choice.");
                        break;
                }
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the NUMBER of the New Id Badge:.");
            string numberAsString = Console.ReadLine();
            badgesPoco.BadgeId = int.Parse(numberAsString);

            Console.WriteLine("Enter the Door Number that this Id Badge can Access:");
            string doorToAdd = Console.ReadLine();
            badgesPoco.ListOfDoors.Add(doorToAdd);

            bool keepLoopRunnin = true;
            while (keepLoopRunnin == true)
            {
                Console.WriteLine("Do you want to enter more Door(y/n)");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    Console.WriteLine("Enter the NUMBER of the New Door:");
                    string newDoorToAdd = Console.ReadLine();
                    badgesPoco.ListOfDoors.Add(newDoorToAdd);
                }
                else
                {
                    keepLoopRunnin = false;
                }

            }
            badgesRepo.AddBadge(badgesPoco);
        }
        private void UpdateABadge()
        {
            Console.Clear();
            Console.WriteLine("Enter the Badge Id Number that you would like to UPDATE:");
            string badgeIdAsString = Console.ReadLine();
            int badgeId = int.Parse(badgeIdAsString);
            Badge badgeToGet = badgesRepo.GetDoorsByBadgeIdNumber(badgeId);

            Console.WriteLine("To Update Doors please ENTER the Number of what you'd like to do:\n" +
                "1. Add A Door\n" +
                "2. Remove a Door\n" +
                "3. Return to MAIN Menu\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Which Door would you Like to Add?");
                    string doorToAddToBadge = Console.ReadLine();
                    badgeToGet.ListOfDoors.Add(doorToAddToBadge);
                    badgesRepo.allBadgesDictionary.Add(badgeToGet.BadgeId, badgeToGet.ListOfDoors);
                    badgesRepo.UpdateAllDoorsForExistingBadge(badgeToGet.BadgeId, badgeToGet);
                    break;

                case "2":
                    Console.WriteLine("Which Door would you like to Remove?");
                    string doorToRemoveFromBadge = Console.ReadLine();
                    badgeToGet.ListOfDoors.Remove(doorToRemoveFromBadge);
                   // badgesRepo.allBadgesDictionary.Remove(badgeToGet.BadgeId, badgeToGet.ListOfDoors);
                    break;

                case "3":
                    Menu();
                    break;
            }


        }
        private void ViewListOfAllBagesAndAccess()
        {
            Console.Clear();
            List<Badge> allBadgesAccess = badgesRepo.GetAllBadgeIdDoorsList();


            foreach (Badge badge in allBadgesAccess)
            {
                Console.WriteLine($"Showing All Badges and Associated Doors by Badge Id Number:\n" +
                    $"Showing Badge ID#: {badge.BadgeId}\n");
                DisplayListOfAllDoors();
            }
        }
        public void DisplayListOfAllDoors()
        {
            foreach (string door in badgesPoco.ListOfDoors)
            {
                Console.WriteLine($"Show Door Access: {door}");
            }
        }
    }
}
