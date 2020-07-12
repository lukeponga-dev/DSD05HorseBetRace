using HorseBetRace;
using HorseBetRace.Data.AllPunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //creating an instance of punter class
        private Punter[] MyPunter = new Punter[3];

        //creating an instance of horse class
        private Horse MyHorse = new Horse();

        private Horse horse;

        [TestMethod]
        public void TestCash()
        {
            int id = 0;
            int ExpectedCash = 50;
            int ActualCash = Convert.ToInt32(Factory.GetAPunter(id).Cash);
            Assert.AreEqual(ExpectedCash, ActualCash);
        }
    }
}