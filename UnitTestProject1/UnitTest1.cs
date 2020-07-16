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

        [TestMethod]
        public void TestCash()
        {
            int id = 0;
            int ExpectedCash = 50;
            int ActualCash = Convert.ToInt32(Factory.GetAPunter(id).Cash);
            //Checking if Cash is 50
            Assert.AreEqual(ExpectedCash, ActualCash);
        }
    }
}