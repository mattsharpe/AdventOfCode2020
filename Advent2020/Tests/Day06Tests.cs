using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day06Tests
    {
        private Day06 _day06;
        private string _sample = @"abc

a
b
c

ab
ac

a
a
a
a

b";
        [TestInitialize]
        public void Initialize()
        {
            _day06 = new Day06();
        }

        [TestMethod]
        public void CountQuestionsAnsweredSample()
        {
            var result = _day06.CountPositiveAnswersWhereAnyoneSaysYes(_sample);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void CountQuestionsAnswered()
        {
            var result = _day06.CountPositiveAnswersWhereAnyoneSaysYes(File.ReadAllText("Input/Day06.txt"));
            Assert.AreEqual(6387, result);
        }

        [TestMethod]
        public void QuestionsThatAllGroupSayYesToSample()
        {
            var result = _day06.CountPositiveAnswersWhereEveryoneSaysYes(_sample);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void QuestionsThatAllGroupSayYesTo()
        {
            var result = _day06.CountPositiveAnswersWhereEveryoneSaysYes(File.ReadAllText("Input/Day06.txt"));
            Assert.AreEqual(3039, result);
        }
    }
}
