using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();

        // Create
        public void CreateNewClaim(Claim newClaim)
        {
            _queueOfClaims.Enqueue(newClaim);
        }

        // Read
        public Queue<Claim> GetAllClaims()
        {
            return _queueOfClaims;
        }

        // Remove claim from queue
        public void ProcessClaim(Claim claim)
        {
            _queueOfClaims.Dequeue();
        }

        // Helper Method
        public Claim SeeNextClaim()
        {
            return _queueOfClaims.Peek();
        }
    }
}
