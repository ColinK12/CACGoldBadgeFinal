using BadgesPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepositiroy
{
    public class BadgesRepo
    {
        public Badge badge = new Badge();
        public List<Badge> listOfBadges = new List<Badge>();

        public Dictionary<int, List<string>> allBadgesDictionary = new Dictionary<int, List<string>>();

        //Create
        public void AddBadge(Badge badges)
        {
            listOfBadges.Add(badges);
            allBadgesDictionary.Add(badges.BadgeId, badges.ListOfDoors);
        }
        //Read
        public Dictionary<int, List<string>> GetAllBadgeIdDictionaryData()
        {
            return allBadgesDictionary;
        }
        public List<Badge> GetAllBadgeIdDoorsList()
        {
            return listOfBadges;
        }

        //Update
        public void UpdateAllDoorsForExistingBadge(int badgeId, Badge updatedBadge)
        {
            Badge existingBadge = GetDoorsByBadgeIdNumber(badgeId);
            existingBadge.ListOfDoors = updatedBadge.ListOfDoors;
        }

        //Delete
        public void RemoveAllDoorsFromExistingBadge(int badgeId)
        {
            Badge badgeToRemoveDoorsFrom = GetDoorsByBadgeIdNumber(badgeId);

            badgeToRemoveDoorsFrom.ListOfDoors.Clear();
        }

        //Helper Method

        public Badge GetDoorsByBadgeIdNumber(int badgeId)
        {
            foreach (Badge badge in listOfBadges)
            {
                if (badgeId == badge.BadgeId)
                {
                    return badge;
                }
            }
            return null;
        }




    }
}
