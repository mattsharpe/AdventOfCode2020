using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day10Tests
    {
        private Day10 _day10;
        private string[] Input => File.ReadAllLines("Input/Day10.txt");
        private readonly string[] _shortSample = 
        {
               "16", "10", "15", "5", "1", "11", "7", "19", "6", "12", "4"
        };

        private readonly string[] _longSample =
        {
            "28", "33", "18", "42", "31", "14", "46", "20", "48", "47", "24", "23", "49", "45", "19", 
            "38", "39", "11", "1", "32", "25", "35", "8", "17", "7", "9", "4", "2", "34", "10", "3",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day10 = new Day10();
        }

        [TestMethod]
        public void ProductOf1JoltAnd3JoltDifferencesSample()
        {
            var result  = _day10.ProductOfDifferences(_longSample);
            Assert.AreEqual(220, result);
        }

        [TestMethod]
        public void ProductOf1JoltAnd3JoltDifferences()
        {
            var result  = _day10.ProductOfDifferences(Input);
            Assert.AreEqual(2210, result);
        }

        [TestMethod]
        public void NumberOfCombinationsShortSample()
        {
            var result = _day10.NumberOfCombinations(_shortSample);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void NumberOfCombinationsLongSample()
        {
            var result = _day10.NumberOfCombinations(_longSample);
            Assert.AreEqual(19208, result);
        }

        [TestMethod]
        public void NumberOfCombinations()
        {
            var result = _day10.NumberOfCombinations(Input);
            Assert.AreEqual(7086739046912, result);
        }
    }
}
