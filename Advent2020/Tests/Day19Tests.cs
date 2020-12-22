using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day19Tests
    {
        private Day19 _day19;

        private string[] _sample = new[]
        {
           "0: 4 1 5",
           "1: 2 3 | 3 2",
           "2: 4 4 | 5 5",
           "3: 4 5 | 5 4",
           "4: \"a\"",
           "5: \"b\"",
           "",
           "ababbb",
           "bababa",
           "abbbab",
           "aaabbb",
           "aaaabbb",
        };


        private string[] Input => File.ReadAllLines("Input/Day19.txt");

        [TestInitialize]
        public void Initialize()
        {
            _day19 = new Day19();
        }

        [TestMethod]
        public void Sample()
        {
            var result = _day19.MessagesMatchingRule(_sample);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MessagesMatchingRule0()
        {
            var result = _day19.MessagesMatchingRule(Input);
            Assert.AreEqual(173, result);
        }
    }
}
