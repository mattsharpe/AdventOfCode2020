using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private Day02 _day02;
        private string[] _sample;
        private string[] _input;

        [TestInitialize]
        public void Initialize()
        {
            _day02 = new Day02();
            _sample = new []
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
                "12-15 h: hhhhhrhcxhhhhhhhhb"
            };
            _input = File.ReadAllLines("Input/Day02.txt");
        }

        [TestMethod]
        public void Sample()
        {
            var result = _day02.CountValidPasswords(_sample);
            Assert.AreEqual(3, result);
        }

        [DataTestMethod]
        [DataRow("1-3 a: abcde", true)]
        [DataRow("1-3 b: cdefg", false)]
        [DataRow("2-9 c: ccccccccc", true)]
        [DataRow("12-15 h: hhhhhrhcxhhhhhhhhb", true)]
        public void ValidatePasswords(string line, bool expected)
        {
            Assert.AreEqual(expected, _day02.IsValid(line));
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day02.CountValidPasswords(_input);
            Assert.AreEqual(454, result);
        }

        [DataTestMethod]
        [DataRow("1-3 a: abcde", true)]
        [DataRow("1-3 b: cdefg", false)]
        [DataRow("2-9 c: ccccccccc", false)]
        public void ValidatePasswordsWithProperPolicy(string line, bool expected)
        {
            Assert.AreEqual(expected, _day02.ValidatePasswordAgainstOfficialTobogganCorporatePolicy(line));
        }

        [TestMethod]
        public void Part2Sample()
        {
            var result = _day02.CountValidPasswords(_sample, true);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day02.CountValidPasswords(_input, true);
            Assert.AreEqual(649, result);
        }
    }
}