using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyProgrammer.Tests
{
    interface ITest
    {
        [TestInitialize] void Initialize();
    }
}
