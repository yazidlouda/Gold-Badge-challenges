using System;
using System.Collections.Generic;
using KomodoBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBadge_test
{
    [TestClass]
    public class BadgeTest
    {
        [TestMethod]
        public void AddBadgeTest()
        {
            Dictionary<int, List<string>> testdoors = new Dictionary<int, List<string>>();
            List<string> _testdoor = new List<string>();
            KomodoBadgesRepo repo = new KomodoBadgesRepo();
            Badges badge = new Badges();

            repo.AddBadge(badge);

            int expected = 1;
            int actual = repo.GetDictionary().Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void POCOsTest()
        {
           
            
            Badges newBadge = new Badges(22345, new List<string> { "A1" });

            Assert.AreEqual(22345, newBadge.BadgeID);
           



        }
    }
}
