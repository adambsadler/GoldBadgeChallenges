using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();
        public string Name { get; set; }

        public Badge() { }

        public Badge(int badgeId, List<string> doorNames, string name)
        {
            BadgeID = badgeId;
            DoorNames = doorNames;
            Name = name;
        }
    }
}
