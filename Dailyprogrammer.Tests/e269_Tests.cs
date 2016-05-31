using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyProgrammer.Tests;
using DailyProgrammer;

namespace Dailyprogrammer.Tests
{
    [TestClass]
    public class e269_Tests : ITest
    {
        private IChallenge<string[]> challenge;

        [TestInitialize]
        public void Initialize()
        {
            challenge = new e269_BASIC_Formatting();
        }

        [TestMethod, TestCategory("e269")]
        public void Example1()
        {
            string[] lines = new string[]
            {
                "    ",
                "VAR I",
                " FOR I=1 TO 31",
                "               IF !(I MOD 3) THEN",
                "  PRINT \"FIZZ\"",
                "       ENDIF",
                "                   IF !(I MOD 5) THEN",
                "                 PRINT \"BUZZ\"",
                "                   ENDIF",
                "               IF(I MOD 3) && (I MOD 5) THEN",
                "      PRINT \"FIZZBUZZ\"",
                "       ENDIF",
                "                NEXT",
            };

            string[] expected = new string[]
            {
                "VAR I",
                "FOR I=1 TO 31",
                "    IF !(I MOD 3) THEN",
                "        PRINT \"FIZZ\"",
                "    ENDIF",
                "    IF !(I MOD 5) THEN",
                "        PRINT \"BUZZ\"",
                "    ENDIF",
                "    IF(I MOD 3) && (I MOD 5) THEN",
                "        PRINT \"FIZZBUZZ\"",
                "    ENDIF",
                "NEXT",
            };

            string[] actual = challenge.GetResult(lines);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod, TestCategory("e269")]
        public void Bonus0()
        {
            e269_BASIC_Formatting c = (e269_BASIC_Formatting)challenge;

            string[] lines = new string[]
            {
                "VAR I",
                "FOR I=1 TO 31",
                "    IF !(I MOD 3) THEN",
                "        PRINT \"FIZZ\"",
                "    ENDIF",
                "    IF !(I MOD 5) THEN",
                "        PRINT \"BUZZ\"",
                "    ENDIF",
                "    IF(I MOD 3) && (I MOD 5) THEN",
                "        PRINT \"FIZZBUZZ\"",
                "    ENDIF",
                "NEXT",
            };

            string[] expected = new string[0];
            string[] actual = c.CheckForErrors(lines);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("e269")]
        public void Bonus1()
        {
            e269_BASIC_Formatting c = (e269_BASIC_Formatting)challenge;

            string[] lines = new string[]
            {
                "FOR I=0 TO 10",
                "    IF I MOD 2 THEN",
                "        PRINT I",
                "NEXT"
            };

            string[] expected = new string[] { "MISSING ENDIF" };
            string[] actual = c.CheckForErrors(lines);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("e269")]
        public void Bonus2()
        {
            e269_BASIC_Formatting c = (e269_BASIC_Formatting)challenge;

            string[] lines = new string[]
            {
                "FOR I=0 TO 10",
                "    IF I MOD 2 THEN",
                "        PRINT I"
            };

            string[] expected = new string[] { "MISSING ENDIF", "MISSING NEXT" };
            string[] actual = c.CheckForErrors(lines);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod, TestCategory("e269")]
        public void Bonus3()
        {
            e269_BASIC_Formatting c = (e269_BASIC_Formatting)challenge;

            string[] lines = new string[]
            {
                "FOR I=0 TO 10",
                "    PRINT I",
                "ENDIF"
            };

            string[] expected = new string[] { "EXTRA IF", "MISSING NEXT" };
            string[] actual = c.CheckForErrors(lines);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod, TestCategory("e269")]
        public void Bonus4()
        {
            e269_BASIC_Formatting c = (e269_BASIC_Formatting)challenge;

            string[] lines = new string[]
            {
                "FOR I=0 TO 10",
                "    PRINT I",
                "NEXT",
                "ENDIF"
            };

            string[] expected = new string[] { "EXTRA ENDIF" };
            string[] actual = c.CheckForErrors(lines);

            CollectionAssert.AreEqual(expected, actual);
        }


    }
}
