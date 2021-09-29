using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    class Badge_Repository
    {
        private Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();

        // Create
        public void CreateBadge(Badge newBadge)
        {
            _badges.Add(newBadge.BadgeID, newBadge.DoorNames);
        }

        // Read
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badges;
        }

        public bool BadgeExists(int id)
        {
            bool doesExist = _badges.ContainsKey(id);

            if(doesExist)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
