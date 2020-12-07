using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day07Tests
    {
        private Day07 _day07;

        private string[] Input => File.ReadAllLines("Input/Day07.txt");

        private string[] _sample =
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.", "dotted black bags contain no other bags."
        };

        [TestInitialize]
        public void Initialize()
        {
            _day07 = new Day07();
        }

        [TestMethod]
        public void CountBagColoursReverseTree()
        {
            var result = _day07.CountBagColoursReversed(_sample);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day07.CountBagColoursReversed(Input);
            Assert.AreEqual(372, result);
        }

        [TestMethod]
        public void BagCountSample()
        {
            var input = new[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            };

            var result = _day07.CountOfBagsNeeded(input);
            Assert.AreEqual(126, result);
        }

        [TestMethod]
        public void CountOfAllBags()
        {
            var result = _day07.CountOfBagsNeeded(Input);
            Assert.AreEqual(8015, result);
        }
    }
}