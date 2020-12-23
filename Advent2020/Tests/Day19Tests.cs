using System.IO;
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
        private string[] Sample2 => File.ReadAllLines("Input/Day19Sample.txt");

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
        public void MessagesMatchingRule()
        {
            var result = _day19.MessagesMatchingRule(Input);
            Assert.AreEqual(173, result);
        }

        [TestMethod]
        public void MessagesMatchingRuleWithLoops()
        {
            var result = _day19.MessagesMatchingRule(Sample2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void MessagesMatchingRuleWithLoopsUpdatedRulesSample()
        {
            var result = _day19.MessagesMatchingRulePatchRules(Sample2);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void MessagesMatchingRuleWithLoopsUpdatedRules()
        {
            var result = _day19.MessagesMatchingRulePatchRules(Input);
            Assert.AreEqual(367, result);
        }
    }
}
