using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day11Tests
    {
        private Day11 _day11;

        private string[] Input => File.ReadAllLines("Input/Day10.txt");
        private readonly string[] _shortSample =
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        [TestInitialize]
        public void Initialize()
        {
            _day11 = new Day11();
        }

        [TestMethod]
        public void TakenSeatsWithSample()
        {
            _day11.Stabilise(_shortSample);
            _day11.PrintMap();

            var result = _day11.OccupiedSeats;

            Assert.AreEqual(37, result);
        }
    }
}
