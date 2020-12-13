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

        [TestMethod]
        public void FirstTimestampSingleSample()
        {
            var result = _day13.EarliestTimestampForLinedUpDepartures(_sample[1]);

            Assert.AreEqual(1068781, result);
        }

        [DataTestMethod]
        [DataRow("17,x,13,19", 3417)]
        [DataRow("67,7,59,61", 754018)]
        [DataRow("67,x,7,59,61", 779210)]
        [DataRow("67,7,x,59,61", 1261476)]
        [DataRow("1789,37,47,1889", 1202161486)]
        public void FirstTimestampSample(string timetable, long expected)
        {
            var result = _day13.EarliestTimestampForLinedUpDepartures(timetable);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FirstTimestamp()
        {
            var result = _day13.EarliestTimestampForLinedUpDepartures(Input[1]);

            Assert.AreEqual(667437230788118, result);
        }
    }
}
