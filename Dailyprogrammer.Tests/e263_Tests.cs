using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyProgrammer.Tests;
using DailyProgrammer;
using System;

namespace Dailyprogrammer.Tests
{
    [TestClass]
    public class e263_Tests : ITest
    {
        private int decimalPlaces = 9;
        private IChallenge<double> challenge;

        [TestInitialize]
        public void Initialize()
        {
            challenge = new e263_Shannon_Entropy();
        }

        [TestCategory("e263"), TestMethod]
        public void Example1()
        {
            double expected = 2.794208684;
            double actual = Math.Round(challenge.GetResult("122333444455555666666777777788888888"), decimalPlaces);
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e263"), TestMethod]
        public void Example2()
        {
            double expected = 2.794208684;
            double actual = Math.Round(challenge.GetResult("563881467447538846567288767728553786"), decimalPlaces);
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e263"), TestMethod]
        public void Example3()
        {
            double expected = 4.056198333;
            double actual = Math.Round(challenge.GetResult("https://www.reddit.com/r/dailyprogrammer"), decimalPlaces);
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e263"), TestMethod]
        public void Example4()
        {
            double expected = 3.866729297;
            double actual = Math.Round(challenge.GetResult("int main(int argc, char *argv[])"), decimalPlaces);
            Assert.AreEqual(expected, actual);
        }
    }
}
