using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day17Tests
    {
        private Day17 _day17;

        public string[] _sample = {
            ".#.",
            "..#",
            "###"
        };

        public string[] Input => File.ReadAllLines("Input/Day17.txt");

        [TestInitialize]
        public void Initialize()
        {
            _day17 = new Day17();
        }

        [TestMethod]
        public void SampleWith1Generation()
        {
            var result = _day17.ActiveCubesAfterIterations(_sample, 1);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void SampleWith6Generations()
        {
            var result = _day17.ActiveCubesAfterIterations(_sample, 6);
            Assert.AreEqual(112, result);
        }

        [TestMethod]
        public void CountActiveCubes()
        {
            var result = _day17.ActiveCubesAfterIterations(Input, 6);
            Assert.AreEqual(209, result);
        }

        [TestMethod]
        public void SampleIn4DWith6Generations()
        {
            var result = _day17.ActiveCubesAfterIterations(_sample, 6, true);
            Assert.AreEqual(848,result);
        }

        [TestMethod]
        public void RunIn4DWith6Generations()
        {
            var result = _day17.ActiveCubesAfterIterations(Input, 6, true);
            Assert.AreEqual(1492,result);
        }
    }
}
