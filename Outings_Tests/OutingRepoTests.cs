using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repository;
using System;

namespace Outings_Tests
{
    [TestClass]
    public class OutingRepoTests
    {
        [TestMethod]
        public void AddOuting_OutingNotNull()
        {
            Outings outing = new Outings();
            outing.Name = "Nipsey's";
            OutingsRepo outingRepo = new OutingsRepo();

            outingRepo.AddOuting(outing);
            Outings outingFromDirectory = outingRepo.ViewOutingByName("Nipsey's");

            Assert.IsNotNull(outingFromDirectory);
        }

        [TestMethod]
        public void ViewOutingByName_OutingDoesNotExist_ReturnsNull()
        {
            Outings outings = new Outings("Bird's Eye View", 150, new DateTime(2022, 6, 8, 10, 30, 0), 1680.00, 11.20, EventType.Golf);
            OutingsRepo outingsRepo = new OutingsRepo();
            outingsRepo.AddOuting(outings);
            string name = "Nipsey";

            Outings result = outingsRepo.ViewOutingByName(name);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ViewOutingByName_OutingDoesExist_ReturnsIsNotNull()
        {
            Outings outings = new Outings("Bird's Eye View", 150, new DateTime(2022, 6, 8, 10, 30, 0), 1680.00, 11.20, EventType.Golf);
            OutingsRepo outingsRepo = new OutingsRepo();
            outingsRepo.AddOuting(outings);
            string name = "Bird's Eye View";

            Outings result = outingsRepo.ViewOutingByName(name);

            Assert.IsNotNull(result);
        }
    }
}
