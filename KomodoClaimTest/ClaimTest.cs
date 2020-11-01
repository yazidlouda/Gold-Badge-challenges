using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KomodoClaims.Claim;

namespace KomodoClaimTest
{
    [TestClass]
    public class ClaimTest
    {

        [TestMethod]
        public void POCOsTest()
        {

            KomodoClaims.Claim newClaim = new KomodoClaims.Claim(1, TypeClaim.Car, "Engine issue", 1200, DateTime.Parse("05/06/2020"), DateTime.Parse("05/08/2020"), true);

                Assert.AreEqual(1, newClaim.ClaimID);
                Assert.AreEqual(TypeClaim.Car, newClaim.ClaimType);
                Assert.AreEqual("Engine issue", newClaim.Description);
                Assert.AreEqual(1200, newClaim.ClaimAmount);
                Assert.AreEqual(DateTime.Parse("05/06/2020"), newClaim.DateOfIncident);
                Assert.AreEqual(DateTime.Parse("05/08/2020"), newClaim.DateOfClaim);
                Assert.AreEqual(true, newClaim.IsValid);
            
        }
        [TestMethod]
        public void AddClaimTest()
        {

            KomodoClaims.Claim order = new KomodoClaims.Claim();
            ClaimRepository repository = new ClaimRepository();

            repository.AddClaim(order);

            int expected = 1;
            int actual = repository.ClaimList().Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetdClaimById_ShouldReturnCorrectCollection()
        {
            KomodoClaims.Claim content = new KomodoClaims.Claim();
            ClaimRepository repo = new ClaimRepository();
            repo.AddClaim(content);

            Queue<KomodoClaims.Claim> contents = repo.ClaimList();
            bool directoryHasContent = contents.Contains(content);

            Assert.IsTrue(directoryHasContent);
        }
    }
}
