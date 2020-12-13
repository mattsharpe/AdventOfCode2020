using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day12Tests
    {
        private Day12 _day12;

        private string[] Input => File.ReadAllLines("Input/Day12.txt");
        private readonly string[] _sample =
        {
           "F10",
           "N3",
           "F7",
           "R90",
           "F11",
        };

        [TestInitialize]
        public void Initialize()
        {
            _day12 = new Day12();
        }

        [TestMethod]
        public void DistanceFromStartSample()
        {
            var result = _day12.ManhattanDistance(_sample);
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void DistanceFromStartPoint()
        {
            var result = _day12.ManhattanDistance(Input);
            Assert.AreEqual(820, result);
        }

        [TestMethod]
        public void MovingWayPointSample()
        {
            var result = _day12.MovingWayPoint(_sample);
            Assert.AreEqual(286, result);
        }

        [TestMethod]
        public void MovingWayPoint()
        {
            var result = _day12.MovingWayPoint(Input);
            Assert.AreEqual(820, result);
        }
    }
}
