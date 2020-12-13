using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day13Tests
    {
        private Day13 _day13;
        private string[] Input => File.ReadAllLines("Input/Day13.txt");
        private readonly string[] _sample =
        {
            "939",
            "7,13,x,x,59,x,31,19"
        };


        [TestInitialize]
        public void TestInitialize()
        {
            _day13 = new Day13();
        }

        [TestMethod]
        public void FirstBusSample()
        {
            var result = _day13.FindFirstBus(_sample);
            Assert.AreEqual(295, result);
        }

        [TestMethod]
        public void FindFirstBus()
        {
            var result = _day13.FindFirstBus(Input);
            Assert.AreEqual(3789, result);
        }
    }
}
