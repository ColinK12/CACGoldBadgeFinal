using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesPOCO
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> ListOfDoors { get; set; } = new List<string>();
        public Badge() { }
        public Badge(int badgeId, List<string> listOfDoors)
        {
            BadgeId = badgeId;
            ListOfDoors = listOfDoors;
        }
    }
}
