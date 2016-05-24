using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyProgrammer.Tests;
using DailyProgrammer;

namespace Dailyprogrammer.Tests
{
    [TestClass]
    public class e260_Tests : ITest
    {
        private IChallenge<int[]> challenge;

        [TestInitialize]
        public void Initialize()
        {
            challenge = new e260_Garage_Door();
        }

        [TestCategory("e260"), TestMethod]
        public void Example1()
        {
            e260_Garage_Door.Commands[] commands = new e260_Garage_Door.Commands[]
            {
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Wait,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Click,
                e260_Garage_Door.Commands.Wait,
            };

            int[] expected = new int[]
            {
                e260_Garage_Door.STATE_CLOSED,
                e260_Garage_Door.STATE_OPENING,
                e260_Garage_Door.STATE_OPEN,
                e260_Garage_Door.STATE_CLOSING,
                e260_Garage_Door.STATE_STOPPEDWHILECLOSING,
                e260_Garage_Door.STATE_OPENING,
                e260_Garage_Door.STATE_STOPPEDWHILEOPENING,
                e260_Garage_Door.STATE_CLOSING,
                e260_Garage_Door.STATE_CLOSED
            };
            int[] actual = challenge.GetResult(commands);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
