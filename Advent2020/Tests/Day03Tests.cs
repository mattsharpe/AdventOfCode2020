using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day03Tests
    {
        private Day03 _day03;
        private string[] _sample;
        private string[] _input;

        [TestInitialize]
        public void Initialize()
        {
            _day03 = new Day03();
            _sample = new []
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
            _input = File.ReadAllLines("Input/Day03.txt");
        }

        [TestMethod]
        public void Sample()
        {
            var result = _day03.CountTrees(_sample, 3, 1);
            Assert.AreEqual(7, result);
        }
     
        [TestMethod]
        public void Part1()
        {
            var result = _day03.CountTrees(_input, 3, 1);
            Assert.AreEqual(242, result);
        }
        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(3, 1, 7)]
        [DataRow(5, 1, 3)]
        [DataRow(7, 1, 4)]
        [DataRow(1, 2, 2)]
        public void Part2SlopeCount(int dx, int dy, int expected)
        {
            var result = _day03.CountTrees(_sample, dx, dy);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(336, _day03.ProductOfAllSlopes(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(2265549792, _day03.ProductOfAllSlopes(_input));
        }
    }
}
