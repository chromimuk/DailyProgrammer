using DailyProgrammer;
using DailyProgrammer.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dailyprogrammer.Tests
{
    [TestClass]
    public class e272_Tests : ITest
    {
        private IChallenge<Dictionary<char, int>> challenge;

        [TestInitialize]
        public void Initialize()
        {
            challenge = new e272_Scrabble();
        }


        [TestMethod, TestCategory("e272")]
        public void Example1()
        {
            string input = "PQAREIOURSTHGWIOAE_";

            Dictionary<char, int> expected = new Dictionary<char, int>()
            {
                {'E', 10},
                {'A', 7},
                {'I', 7},
                {'N', 6},
                {'O', 6},
                {'T', 5},
                {'D', 4},
                {'L', 4},
                {'R', 4},
                {'S', 3},
                {'U', 3},
                {'B', 2},
                {'C', 2},
                {'F', 2},
                {'G', 2},
                {'M', 2},
                {'V', 2},
                {'Y', 2},
                {'H', 1},
                {'J', 1},
                {'K', 1},
                {'P', 1},
                {'W', 1},
                {'X', 1},
                {'Z', 1},
                {'_', 1},
                {'Q', 0}
            };
            var orderedExpected = expected.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Dictionary<char, int> actual = challenge.GetResult(input);
            CollectionAssert.AreEqual(orderedExpected, actual);
        }
        
        [TestMethod, TestCategory("e272")]
        public void Example2()
        {
            string input = "LQTOONOEFFJZT";

            Dictionary<char, int> expected = new Dictionary<char, int>()
            {
                {'E', 11},
                {'A', 9},
                {'I', 9},
                {'R', 6},
                {'N', 5},
                {'O', 5},
                {'D', 4},
                {'S', 4},
                {'T', 4},
                {'U', 4},
                {'G', 3},
                {'L', 3},
                {'B', 2},
                {'C', 2},
                {'H', 2},
                {'M', 2},
                {'P', 2},
                {'V', 2},
                {'W', 2},
                {'Y', 2},
                {'_', 2},
                {'K', 1},
                {'X', 1},
                {'F', 0},
                {'J', 0},
                {'Q', 0},
                {'Z', 0}
            };
            var orderedExpected = expected.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Dictionary<char, int> actual = challenge.GetResult(input);
            CollectionAssert.AreEqual(orderedExpected, actual);
        }

        [TestMethod, TestCategory("e272")]
        [ExpectedException(typeof(ArgumentException), "Invalid input. More Q's have been taken from the bag than possible.")]
        public void Example3()
        {
            string input = "AXHDRUIOR_XHJZUQEE";
            Dictionary<char, int> actual = challenge.GetResult(input);
        }

    }
}
