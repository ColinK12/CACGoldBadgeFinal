using ClaimDeptPOCO;
using ClaimsDepRepository;
using System;
using System.Collections.Generic;   //Display
using System.Linq;
using System.Text;                  // Get User Input
using System.Threading.Tasks;
                                    //Evalluate User input act
namespace KomodoClaimDept
{
    public class ProgramUI
    {
        ClaimDepRepo claimDepRepo = new ClaimDepRepo();
        Claim claimDepPoco = new Claim();

        //Method that starts app./runs
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            { 

                Console.WriteLine("Welcome to Komodo Insurance Claims Department\n" +
                "What would you like to do?\n" +
                "Please make your NUMERICAL selection below.\n" +
                "1.See All Claims\n" +
                "2.Take Care Of Next Claim\n" +
                "3.Enter A New Claim\n" +
                "4. Exit\n");

            string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Add
                        SeeAllClaims();
                        break;
                    case "2": //Delete
                        TakeCareOfNextClaim();
                        break;
                    case "3": //create
                        EnterANewClaim();
                        break;

                    case "4": //Exit
                        Console.WriteLine("Thanks for using the Komodo Claims App.\n"+
                            "Thank You Goodbye.\n" +
                            "Press any KEY to Continue.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid NUMBER.");
                        break;
                }
            }
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            List<Claim> listOfAllClaimData = claimDepRepo.GetAllListClaimData();

            foreach(Claim claim in listOfAllClaimData)
            {
                Console.WriteLine($"Showing All Claim Id: {claim.ClaimId}\n" +
                    $"Showing Claim Type: {claim.ClaimsType}\n" +
                    $"Showing Claim Description: {claim.ClaimsDescription}\n" +
                    $"Showing Claim Amount: {claim.ClaimAmount}\n" +
                    $"Showing Date of Incident: {claim.DateOfIncident}\n" +
                    $"Showing Date of Claim: {claim.DateOfClaim}\n");
            }
            
        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<Claim> claimsQueue = claimDepRepo.GetQueueClaimData();
            

            bool keepLoopRunning = true;
            while (keepLoopRunning == true)
            {
                Console.WriteLine("Would you like to Take The Next Claim In Queue? y/n");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    Console.WriteLine("Claim has been removed from Queue.");
                    claimDepRepo.RemoveClaimFromList();
                    claimsQueue.Dequeue();
                }
                else
                {
                    keepLoopRunning = false;
                }
            }

        }
        private void EnterANewClaim()
        {
            Console.WriteLine("Please Enter the Claim ID Number:");
            string intAsString = Console.ReadLine();
            claimDepPoco.ClaimId = int.Parse(intAsString);

            Console.WriteLine("Please Enter the NUMBER of Type of Claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string enumAsString = Console.ReadLine();
            int enumAsInt = int.Parse(enumAsString);
            claimDepPoco.ClaimsType = (TypesOfClaims)enumAsInt;   /// Casting (type)variable to be casted into another type.

            Console.WriteLine("Please Enter the Claim's Description:");
            claimDepPoco.ClaimsDescription = Console.ReadLine();

            Console.WriteLine("Please Enter the Claim Amount:");
            string decimalAsString = Console.ReadLine();
            claimDepPoco.ClaimAmount = double.Parse(decimalAsString);

            Console.WriteLine("Please Enter the Date of Incident:dd / MM / yyyy");
            string dateOfIncident = Console.ReadLine();//check slack
            claimDepPoco.DateOfIncident = DateTime.Parse(dateOfIncident);

            Console.WriteLine("Please Enter the Date Of Claim:dd/MM/yyyy");
            string dateOfClaim = Console.ReadLine();
            claimDepPoco.DateOfClaim = DateTime.Parse(dateOfClaim);

            Console.WriteLine("Is this Claim VALID?  y/n");
            string userInput = Console.ReadLine().ToLower();

            if(userInput == "y")
            {
                Console.WriteLine("The Claim is Valid.");
                claimDepPoco.IsValid = true;
            }
            else
            {
                Console.WriteLine("The Claim is NOT Valid.");
                claimDepPoco.IsValid = false;

            }
            claimDepRepo.AddToListOfAllClaimData(claimDepPoco);
            claimDepRepo.AddToQueueOfAllClaimData(claimDepPoco);
        }

    }
}
