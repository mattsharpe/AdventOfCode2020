using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day05Tests
    {
        private Day05 _day05;

        [TestInitialize]
        public void Initialize()
        {
            _day05 = new Day05();
        }

        [TestMethod]
        public void Sample()
        {
            var (row, column) = _day05.FindSeat("FBFBBFFRLR");

            Assert.AreEqual(44, row);
            Assert.AreEqual(5, column);
        }

        [TestMethod]
        public void SampleSeatNumber()
        {
            var result = _day05.FindSeatNumber("FBFBBFFRLR");

            Assert.AreEqual(357, result);
        }

        [DataTestMethod]
        [DataRow("BFFFBBFRRR", 70, 7, 567)]
        [DataRow("FFFBBBFRRR", 14, 7, 119)]
        [DataRow("BBFFBBFRLL", 102, 4, 820)]
        public void Samples(string seat, int expectedRow, int expectedColumn, int expectedSeatNumber)
        {
            var (row, column) = _day05.FindSeat(seat);
            Assert.AreEqual(expectedRow, row);
            Assert.AreEqual(expectedColumn, column);

            var seatNumber = _day05.FindSeatNumber(seat);

            Assert.AreEqual(expectedSeatNumber, seatNumber);
        }

        [TestMethod]
        public void HighestSeatNumber()
        {
            var input = File.ReadAllLines("Input/Day05.txt");

            var result = _day05.FindHighestSeatNumber(input);
            Assert.AreEqual(955, result);
        }

        [TestMethod]
        public void FindMissingSeat()
        {
            var input = File.ReadAllLines("Input/Day05.txt");
            var result = _day05.FindEmptySeat(input);
            Assert.AreEqual(569, result);
        }
    }
}