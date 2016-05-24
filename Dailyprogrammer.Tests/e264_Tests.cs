using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyProgrammer.Tests;
using DailyProgrammer;

namespace Dailyprogrammer.Tests
{
    [TestClass]
    public class e264_Tests : ITest
    {
        private IChallenge<bool> challenge;

        [TestInitialize]
        public void Initialize()
        {
            challenge = new e264_Magic_Square();
        }

        [TestCategory("e264"), TestMethod]
        public void Example1()
        {
            int[] input = new int[9] { 8, 1, 6, 3, 5, 7, 4, 9, 2 };

            var expected = true;
            var actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e264"), TestMethod]
        public void Example2()
        {
            int[] input = new int[9] { 2, 7, 6, 9, 5, 1, 4, 3, 8 };

            var expected = true;
            var actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e264"), TestMethod]
        public void Example3()
        {
            int[] input = new int[9] { 3, 5, 7, 8, 1, 6, 4, 9, 2 };

            var expected = false;
            var actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e264"), TestMethod]
        public void Example4()
        {
            int[] input = new int[9] { 8, 1, 6, 7, 5, 3, 4, 9, 2 };

            var expected = false;
            var actual = challenge.GetResult(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
