using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2020.Solutions;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day23Tests
    {
        private Day23 _day23;


        [TestInitialize]
        public void Initialize()
        {
            _day23 = new Day23();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            var result = _day23.OrderAfterCup1("389125467");

            Assert.AreEqual("67384529", result); 
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day23.OrderAfterCup1("463528179");

            Assert.AreEqual("52937846", result);
        }

        [TestMethod]
        public void Part2_Sample()
        {
            long result = _day23.Part2("389125467");
            Assert.AreEqual(149245887792, result);
        }


        [TestMethod]
        public void Part2()
        {
            long result = _day23.Part2("463528179");
            Assert.AreEqual(8456532414, result);
        }
    }
}
