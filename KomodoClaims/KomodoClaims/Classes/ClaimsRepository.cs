using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Classes

{

    public class Claim_Repository
    {
        private readonly Queue<Claim> _queueOfClaims = new Queue<Claim>();
       
        public bool AddClaimToQueue(Claim claim)
        {

            int initialClaimCount = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(claim);

            if (_queueOfClaims.Count > initialClaimCount)
            { return true; }
            return false;
        }

        public Queue<Claim> ReturnQueuedClaims()
        {

            return _queueOfClaims;
      
        }
        // Enqueue, Dequeue, Peek                                    -- when I dequeue, I will try to add dequeue'd item to a list of claims dealt with
        public void ProcessClaim()
        {

            // Claim claim = GetClaimByID(claimID);

            //Claim claim = _queueOfClaims.Peek();
            //Console.WriteLine
            //     ($"        Claim ID: {claim.ClaimID}\n" +
            //        $"Type Of Claim:    {claim.TypeOfClaim}\n" +
            //        $"Description:      {claim.Description}\n" +
            //        $"Claim Amount:     ${claim.ClaimAmount}\n" +
            //        $"Date of Incident: {claim.DateOfIncident}\n" +
            //        $"Date of Claim:    {claim.DateOfClaim}\n" +
            //        $"Claim is Valid:   {claim.IsValid}");

            //Console.WriteLine();
            //Console.WriteLine("Would you like to deal with this claim? (Y/N)");
            //string input = Console.ReadLine().ToLower();


            //if (input == "y")
            //{
            //    Console.WriteLine("This claim has been processed");
                _queueOfClaims.Dequeue();
            //}
            //else if (input == "n")
            //{
            //    Console.WriteLine("Claim was not processed");
            //}
            //else
            //{
            //    Console.WriteLine("Please enter a valid \"Y\" or \"N\"");
            //}



        }

        public void ClaimValidity(Claim claim, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            claim.DateOfIncident = dateOfIncident;
            claim.DateOfClaim = dateOfClaim;


            TimeSpan interval = dateOfClaim - dateOfIncident;
            if (interval.Days < 30)
            { claim.IsValid = true; }
            else claim.IsValid = false;

        }















        // Might use this method to Prepend or Append claims
        //public Claim GetClaimByID(int claimID)
        //{
        //    foreach (Claim claim in _claimRepository)
        //    {
        //        if (claim.ClaimID == claimID)
        //        {
        //            return claim;
        //        }
        //    }
        //    return null;

        //}





    }
}
