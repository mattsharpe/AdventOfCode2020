using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day11Tests
    {
        private Day11 _day11;

        private string[] Input => File.ReadAllLines("Input/Day11.txt");
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

            var result = _day11.OccupiedSeats;

            Assert.AreEqual(37, result);
        }

        
        [TestMethod]
        public void TakenSeats()
        {
            _day11.Stabilise(Input);

            var result = _day11.OccupiedSeats;

            Assert.AreEqual(2265, result);
        }

        [TestMethod]
        public void VisibleSeatsSample()
        {
            _day11.Stabilise(_shortSample, true);

            var result = _day11.OccupiedSeats;

            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void VisibleSeats()
        {
            _day11.Stabilise(Input, true);

            var result = _day11.OccupiedSeats;

            Assert.AreEqual(2045, result);
        }
    }
}
