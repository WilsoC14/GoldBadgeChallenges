using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_Claims_Classes;

namespace Komodo_Claims_Console
{
    class ProgramUI
    {
        private readonly Claim_Repository _claimRepo = new Claim_Repository();

        public void Run()
        {
            SeedQueue();
            Menu();

        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option: \n" +
                    "1. See All Claims:\n" +
                    "2. Take Care of Next Claim: \n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit...");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //See All Claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take Care of Next Claim
                        DealWithClaim();
                        break;
                    case "3":
                        //Enter a New Claim
                        CreateClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number:");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();


            }

        }

        //Menu


        private void SeeAllClaims()             //Peek All Method
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.ReturnQueuedClaims();

            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine
                    ($"        Claim ID: {claim.ClaimID}\n" +
                    $"Type Of Claim:    {claim.TypeOfClaim}\n" +
                    $"Description:      {claim.Description}\n" +
                    $"Claim Amount:     ${claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim:    {claim.DateOfClaim}\n" +
                    $"Claim is Valid:   {claim.IsValid}");
                Console.WriteLine();
                Console.WriteLine();
            }




        }

        private void PeekClaimByID()            // Get Claim by ID & Peek it's details
        {

        }

        private void CreateClaim()             // Enqueue
        {
            Claim claim = new Claim();

            Console.WriteLine("Enter an ID Number for the Claim: ");
            claim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter a Number the Type of Claim : \n" +
                "1. Car\n" +
                "2. House\n" +
                "3. Theft ");
            string typeOfClaim = Console.ReadLine();
            int typeAsInt = int.Parse(typeOfClaim);
            claim.TypeOfClaim = (ClaimType)typeAsInt;


            Console.WriteLine("Enter a Description for the Claim");
            claim.Description = Console.ReadLine();


            Console.WriteLine("Enter the Dollar Amount for the Claim: \n" +
                "(enter amount without a $)");
            claim.ClaimAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Date of Incident: yyyy,mm,dd ");
            DateTime dateofIncident = DateTime.Parse(Console.ReadLine());
            claim.DateOfIncident = dateofIncident;
            Console.WriteLine(claim.DateOfIncident);


            Console.WriteLine("Enter the Date of Claim: yyyy,mm,dd ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());
            //if (DateTime.TryParse(Console.ReadLine(), out dateOfClaim))

            claim.DateOfClaim = dateOfClaim;
            Console.WriteLine(claim.DateOfClaim);

            TimeSpan interval = dateOfClaim - dateofIncident;
            if (interval.Days < 31)
            { claim.IsValid = true; }
            else claim.IsValid = false;

            Console.WriteLine(claim.IsValid);


            _claimRepo.AddClaimToQueue(claim);

        }

        private void DealWithClaim()           // Dequeue & add to list of dealt with claims
        {
            Console.Clear();
            Queue<Claim> queuedClaims = _claimRepo.ReturnQueuedClaims();
            Claim claim = queuedClaims.Peek();
            Console.WriteLine
                 ($"        Claim ID: {claim.ClaimID}\n" +
                    $"Type Of Claim:    {claim.TypeOfClaim}\n" +
                    $"Description:      {claim.Description}\n" +
                    $"Claim Amount:     ${claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim:    {claim.DateOfClaim}\n" +
                    $"Claim is Valid:   {claim.IsValid}");

            Console.WriteLine();
            Console.WriteLine("Would you like to deal with this claim? (Y/N)");
            string dealWithClaimYorN = Console.ReadLine().ToLower();

            if (dealWithClaimYorN == "y")
            {
                _claimRepo.ProcessClaim();       //Could have some code asserting this method's success
                Console.WriteLine("This claim has been processed");
            }
            else if (dealWithClaimYorN == "n")
            {
                Console.WriteLine("Claim was not processed");
            }
            else
            {
                Console.WriteLine("Please enter a valid \"Y\" or \"N\"");
            }

        }

        private void SeedQueue()
        {
            //Claim One
            DateTime claimOneIncidentDate = new DateTime(2018, 4, 25);
            DateTime claimOneClaimDate = new DateTime(2018, 4, 27);
            Claim claimOne = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00, claimOneIncidentDate, claimOneClaimDate);
            _claimRepo.ClaimValidity(claimOne, claimOneIncidentDate, claimOneClaimDate);
            _claimRepo.AddClaimToQueue(claimOne);

            //Claim Two
            DateTime claimTwoIncidentDate = new DateTime(2018, 4, 26);
            DateTime claimTwoClaimDate = new DateTime(2018, 4, 28);
            Claim claimTwo = new Claim("2", ClaimType.House, "House fire in kitchen.", 4000.00, claimTwoIncidentDate, claimTwoClaimDate);
            _claimRepo.ClaimValidity(claimTwo, claimTwoIncidentDate, claimTwoClaimDate);
            _claimRepo.AddClaimToQueue(claimTwo);

            //Claim Three
            DateTime claimThreeIncidentDate = new DateTime(2018, 4, 27);
            DateTime claimThreeClaimDate = new DateTime(2018, 6, 01);
            Claim claimThree = new Claim("3", ClaimType.Theft, "Stolen Pancakes.", 4.00, claimThreeIncidentDate, claimThreeClaimDate);
            _claimRepo.ClaimValidity(claimThree, claimThreeIncidentDate, claimThreeClaimDate);
            _claimRepo.AddClaimToQueue(claimThree);




        }
    }
}
