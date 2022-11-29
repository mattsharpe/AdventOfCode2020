using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day25Tests
    {
        private Day25 _day25 = new();
        string[] Input => File.ReadAllLines(@"Input\Day25.txt");

        private string[] Sample = { "5764801", "17807724" };


        [TestInitialize]
        public void Initialize()
        {
            _day25 = new Day25();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            var result = _day25.Part1(Sample);

            Assert.AreEqual(14897079, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day25.Part1(Input);

            Assert.AreEqual(11707042, result);
        }
    }
}
