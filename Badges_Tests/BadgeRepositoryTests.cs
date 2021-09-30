using Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badges_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _badgeRepo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();
            List<string> basicDoors = new List<string>();
            basicDoors.Add("Entrance");
            basicDoors.Add("First Floor");
            _badge = new Badge(1001, basicDoors, "Associate");
        }

        [TestMethod]
        public void CreateBadge_ShouldNotGetNull()
        {
            _badgeRepo.CreateBadge(_badge);
            
            Assert.IsNotNull(_badge);
        }

        [TestMethod]
        public void BadgeExists_ShouldGetTrue()
        {
            _badgeRepo.CreateBadge(_badge);
            bool doesExist = _badgeRepo.BadgeExists(1001);

            Assert.IsTrue(doesExist);
        }

        [TestMethod]
        public void BadgeExists_ShouldGetFalse()
        {
            bool doesExist = _badgeRepo.BadgeExists(1001);

            Assert.IsFalse(doesExist);
        }
    }
}
