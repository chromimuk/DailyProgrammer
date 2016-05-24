using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyProgrammer.Tests
{
    
    [TestClass]
    public class e254_Tests : ITest
    {
        private IChallenge<string> challenge;
            
        [TestInitialize()]
        public void Initialize()
        {
            challenge = new e254_Atbash_Cipher();
        }

        [TestCategory("e254"), TestMethod]
        public void Example1()
        {
            var expected = "ullyzi";
            var actual = challenge.GetResult("foobar");
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e254"), TestMethod]
        public void Example2()
        {
            var expected = "draziw";
            var actual = challenge.GetResult("wizard");
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e254"), TestMethod]
        public void Example3()
        {
            var expected = "/i/wzrobkiltiznnvi";
            var actual = challenge.GetResult("/r/dailyprogrammer");
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("e254"), TestMethod]
        public void Example4()
        {
            var expected = "this is an example of the atbash cipher";
            var actual = challenge.GetResult("gsrh rh zm vcznkov lu gsv zgyzhs xrksvi");
            Assert.AreEqual(expected, actual);
        }

    }
}
