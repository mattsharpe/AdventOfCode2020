using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day14Tests
    {
        private string[] Input => File.ReadAllLines("Input/Day14.txt");

        private string[] _sample = new[]
        {
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
            "mem[8] = 11",
            "mem[7] = 101",
            "mem[8] = 0"
        };

        private string[] _sample2 =
        {
            "mask = 000000000000000000000000000000X1001X",
            "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX",
            "mem[26] = 1"
        };

        private Day14 _day14;

        [TestInitialize]
        public void Initialize()
        {
            _day14 = new Day14();
        }

        [TestMethod]
        public void SampleProgram()
        {
            var result = _day14.SumMemoryAfterProgram(_sample);
            Assert.AreEqual(165, result);
        }

        [TestMethod]
        public void SumOfMemory()
        {
            var result = _day14.SumMemoryAfterProgram(Input);
            Assert.AreEqual(5902420735773, result);
        }

        [TestMethod]
        public void RecursiveExplosionSample()
        {
            var result = _day14.SumMemoryWithFloatingBits(_sample2);
            Assert.AreEqual(208, result);
        }

        [TestMethod]
        public void RecursiveExplosion()
        {
            var result = _day14.SumMemoryWithFloatingBits(Input);
            Assert.AreEqual(3801988250775, result);
        }
    }
}
