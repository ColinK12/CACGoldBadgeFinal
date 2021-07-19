using ClaimDeptPOCO;
using ClaimsDepRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestClaimDepMethod
{
    [TestClass]
    public class UnitTestClaimDepMethods
    {
        ClaimDepRepo claimDepRepo = new ClaimDepRepo();
        Claim claim = new Claim();


        [TestMethod]
        public void AddToQueueOFClaimsWorking()
        {
            Claim addToAllQueue = new Claim(1, TypesOfClaims.Home, "Home", 2000.00, Convert.ToDateTime("2021/12/12"), Convert.ToDateTime("2021 12/14"), true);
            int queueCount = claimDepRepo.queueOfAllClaimData.Count;

            claimDepRepo.AddToQueueOfAllClaimData(addToAllQueue);

            Assert.AreNotEqual(queueCount, claimDepRepo.queueOfAllClaimData.Count);
        }
        [TestMethod]

        public void AddtoListofClaimsWorking()
        {
            Claim addToAllList = new Claim(1, TypesOfClaims.Home, "Home", 2000.00, Convert.ToDateTime("2021/12/12"), Convert.ToDateTime("2021 12/14"), true);
            int listCount = claimDepRepo.listOfAllClaimData.Count;

            claimDepRepo.AddToListOfAllClaimData(addToAllList);

            Assert.AreNotEqual(listCount, claimDepRepo.listOfAllClaimData.Count);
        }

        [TestMethod]

        public void RemoveFromListofClaimsWorking()
        {
            Claim removeFromAllList = new Claim(1, TypesOfClaims.Home, "Home", 2000.00, Convert.ToDateTime("2021/12/12"), Convert.ToDateTime("2021 12/14"), false);
            int listCount = claimDepRepo.listOfAllClaimData.Count;

            claimDepRepo.AddToListOfAllClaimData(removeFromAllList);

            Assert.AreEqual(listCount, claimDepRepo.listOfAllClaimData.Count);
        }

    }
}
