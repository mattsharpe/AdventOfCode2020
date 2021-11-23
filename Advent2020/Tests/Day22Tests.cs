using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2020.Solutions;

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
    }
}
