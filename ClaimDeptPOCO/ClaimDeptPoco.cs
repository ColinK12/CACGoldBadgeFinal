using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimDeptPOCO
{
    public enum TypesOfClaims
    {
        Car =1,
        Home,
        Theft,
    }
    public class Claim
    {
        //POCO
        public int ClaimId { get; set; }
        public TypesOfClaims ClaimsType { get; set; }
        public string ClaimsDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim (int claimId, TypesOfClaims claimsType, string claimsDescription,  double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimsType = claimsType;
            ClaimsDescription = claimsDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
