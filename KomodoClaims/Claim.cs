using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class Claim
    {
        public int ClaimID { get; set;}
        public TypeClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int claimID,TypeClaim claimType,string description, double claimAmount , DateTime dateOfIncident, DateTime datOfClaim,bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = datOfClaim;
            IsValid = isValid;
        }

        public enum TypeClaim
        {
            Car,
            Home,
            Theft,
        }

    }
}
