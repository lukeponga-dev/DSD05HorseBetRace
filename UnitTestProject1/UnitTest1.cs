using HorseBetRace.Data.AllPunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HorseBetRace;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
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
