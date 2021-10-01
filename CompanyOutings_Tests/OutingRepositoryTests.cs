using CompanyOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompanyOutings_Tests
{
    [TestClass]
    public class OutingRepositoryTests
    {
        private OutingRepository _outingRepo;
        private Outing _outing;

        [TestInitialize]
        public void Arrange()
        {
            _outingRepo = new OutingRepository();

            var firstOutingDate = new DateTime(2021, 3, 17);
            _outing = new Outing(TypeOfEvent.Bowling, 6, firstOutingDate, 12m, 72m);
        }
        [TestMethod]
        public void CreateNewOuting_ShouldNotGetNull()
        {
            var secondOutingDate = new DateTime(2021, 6, 21);
            Outing secondOuting = new Outing(TypeOfEvent.Cookout, 18, secondOutingDate, 5, 90m);

            _outingRepo.CreateNewOuting(secondOuting);

            Assert.IsNotNull(secondOuting);
        }
    }
}
