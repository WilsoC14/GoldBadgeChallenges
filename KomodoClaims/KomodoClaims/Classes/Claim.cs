using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Classes
{
    public enum ClaimType{Car   = 1, House, Theft};
    public class Claim      //An interface would be appropriate
    {
        public string ClaimID { get; set; }
        public ClaimType TypeOfClaim {get; set;}
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }


        public Claim() {}
        public Claim(string claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;


            //TimeSpan interval = dateOfClaim - dateOfIncident;
            //if (interval.Days < 30)
            //{ IsValid = true; }
            //else IsValid = false;

        }

        }


    

    
}
