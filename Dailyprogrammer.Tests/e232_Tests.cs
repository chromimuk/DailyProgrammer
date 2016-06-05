using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyProgrammer.Tests;
using DailyProgrammer;

namespace Dailyprogrammer.Tests
{
    [TestClass]
    public class e232_Tests : ITest
    {
        private IChallenge<bool> challenge;

        [TestInitialize]
        public void Initialize()
        {
            challenge = new e232_Palindromes();
        }

        [TestMethod, TestCategory("e232")]
        public void Example1()
        {
            string input = "tacocat";
            bool expected = true;
            bool actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("e232")]
        public void Example2()
        {
            string input = "Amor, Roma";
            bool expected = true;
            bool actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("e232")]
        public void Example3()
        {
            string input = 
                @"Was it a car
                or a cat
                I saw ?";
            bool expected = true;
            bool actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("e232")]
        public void Example4()
        {
            string input =
                @"A man, a plan, 
                a canal, a hedgehog, 
                a podiatrist, 
                Panama!";
            bool expected = false;
            bool actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

    }
}
