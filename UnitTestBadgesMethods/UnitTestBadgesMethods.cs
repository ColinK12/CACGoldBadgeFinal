using BadgesPOCO;
using BadgesRepositiroy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestBadgesMethods
{
    [TestClass]
    public class UnitTestBadgesMethods
    {
        Badge badge = new Badge();
        BadgesRepo badgesRepo = new BadgesRepo();

        [TestMethod]
        public void AddBadgeToListWorking()
        {
            Badge badgeToAdd = new Badge(1, null);
            int FirstNumberOfBadges = badgesRepo.listOfBadges.Count;

            badgesRepo.AddBadge(badgeToAdd);

            Assert.AreNotEqual(FirstNumberOfBadges, badgesRepo.listOfBadges);
        }

        [TestMethod]

        public void RemoveDoorsFromExistingBadgeNotWorking()
        {
            Badge doorToRemove = new Badge(1, new List<string> { "A1", "B2"});
            int initialCountOfDoors = doorToRemove.ListOfDoors.Count;
            doorToRemove.ListOfDoors.Clear();
            int afterCountOfDoors = doorToRemove.ListOfDoors.Count;

            Assert.AreNotEqual(initialCountOfDoors, afterCountOfDoors);
        }
    }
}
