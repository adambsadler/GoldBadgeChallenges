using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claims_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        private ClaimRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(1, "Car", "Broken windshield", 527.89m, new DateTime(2021,5,16), new DateTime(2021,5,28), true);
        }
        [TestMethod]
        public void CreateNewClaim_ShouldGetNotNull()
        {
            _repo.CreateNewClaim(_claim);
            Claim claimInQueue = _repo.SeeNextClaim();

            Assert.IsNotNull(claimInQueue);
        }
    }
}
