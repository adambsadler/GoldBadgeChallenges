using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgeRepository
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

        // Method to check if a badge exists in the dictionary
        public bool BadgeExists(int id)
        {
            bool doesExist = _badges.ContainsKey(id);

            if (doesExist)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to get the list of doors associated with a badge ID
        public List<string> GetValuesByKey(int id)
        {
            foreach (var badge in _badges)
            {
                int badgeId = badge.Key;
                List<string> doors = badge.Value;

                if (badgeId == id)
                {
                    return doors;
                }
            }
            return null;
        }

        // Method to find a door associated with a badge by name and remove it
        public bool RemoveDoor(int id, string doorName)
        {
            foreach (var badge in _badges)
            {
                int badgeId = badge.Key;
                List<string> doors = badge.Value;

                foreach (string door in doors)
                {
                    if (doorName == door && id == badge.Key)
                    {
                        doors.Remove(doorName);
                        return true;
                    }
                }
            }
            return false;
        }

        // Method to add a door to a badge
        public void AddDoor(int id, string doorName)
        {
            foreach (var badge in _badges)
            {
                int badgeId = badge.Key;
                List<string> doors = badge.Value;

                if (id == badge.Key)
                {
                    doors.Add(doorName);
                }

            }
        }
    }
}
