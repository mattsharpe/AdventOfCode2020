using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2020.Solutions;
using System.IO;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day22Tests
    {
        private Day22 _day22;

        private string[] _sample = new string[]
        {
            "Player 1:",
            "9",
            "2",
            "6",
            "3",
            "1",
            "",
            "Player 2:",
            "5",
            "8",
            "4",
            "7",
            "10",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day22 = new Day22();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            var result = _day22.CalculateWinningScore(_sample);

            Assert.AreEqual(306, result); 
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day22.CalculateWinningScore(File.ReadAllLines("Input/Day22.txt"));

            Assert.AreEqual(35818, result);
        }

        [TestMethod]
        public void LoopExits()
        {
            var input = new[]
            {
                "Player 1:",
                "43",
                "19",
                "",
                "Player 2:",
                "2",
                "29",
                "14",
            };

            var result = _day22.CalculateWinningScoreOfRecursiveGame(input);

            Assert.AreEqual(105, result);
        }

        [TestMethod]
        public void RecursiveGameSample()
        {
            int result = _day22.CalculateWinningScoreOfRecursiveGame(_sample);

            Assert.AreEqual(291, result);
        }

        [TestMethod]
        public void RecursiveGame()
        {
            int result = _day22.CalculateWinningScoreOfRecursiveGame(File.ReadAllLines("Input/Day22.txt"));

            Assert.AreEqual(34771, result);
        }
    }
}
