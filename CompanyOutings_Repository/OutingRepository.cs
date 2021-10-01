using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public class OutingRepository
    {
        private List<Outing> _outingRepo = new List<Outing>();

        // Create
        public void CreateNewOuting(Outing newOuting)
        {
            _outingRepo.Add(newOuting);
        }

        // Read
        public List<Outing> GetAllOutings()
        {
            return _outingRepo;
        }

        // Method to get the total combined cost for all outings
        public decimal TotalOutingCost(List<Outing> allOutings)
        {
            decimal cost = 0m;
            foreach(Outing outing in allOutings)
            {
                cost += outing.TotalCost;
            }
            return cost;
        }
    }
}
