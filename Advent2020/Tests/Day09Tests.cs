using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day09Tests
    {
        private Day09 _day09 = new Day09();

        private string[] Input => File.ReadAllLines("Input/Day09.txt");
        private readonly string[] _sample = 
        {
            "35",
            "20",
            "15",
            "25",
            "47",
            "40",
            "62",
            "55",
            "65",
            "95",
            "102",
            "117",
            "150",
            "182",
            "127",
            "219",
            "299",
            "277",
            "309",
            "576"
        };

        [TestInitialize]
        public void Initialize()
        {
            _day09 = new Day09();
        }

        [TestMethod]
        public void Sample()
        {
            var result = _day09.FirstNumberNotSumOfPreceding(_sample, 5);
            Assert.AreEqual(127, result);
        }

        [TestMethod]
        public void FindFirstMismatchedNumber()
        {
            var result = _day09.FirstNumberNotSumOfPreceding(Input, 25);
            Assert.AreEqual(69316178, result);
        }

        [TestMethod]
        public void FindSumOfRangeThatAddsToMismatchedNumberSample()
        {
            var result = _day09.SumOfRangeThatSumsToMismatchedNumber(_sample, 5);
            Assert.AreEqual(62, result);
        }

        [TestMethod]
        public void FindSumOfRangeThatAddsToMismatchedNumber()
        {
            var result = _day09.SumOfRangeThatSumsToMismatchedNumber(Input, 25);
            Assert.AreEqual(9351526, result);
        }
    }
}