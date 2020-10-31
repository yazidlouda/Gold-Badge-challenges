using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimRepository
    {
        private Queue<Claim> _claims = new Queue<Claim>();
        public Queue<Claim> ClaimList()
        {
            return _claims;
        }


        public void AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        public Claim GetdClaimById(int claimNumber)
        {
            foreach (Claim claimIcontent in _claims)
            {
                if (claimIcontent.ClaimID == claimNumber)
                {
                    return claimIcontent;
                }
            }
            return null;
        }
       
    }
}
