using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day08Tests
    {
        private Day08 _day08;
        private string[] Input => File.ReadAllLines("Input/Day08.txt");

        [TestInitialize]
        public void Initialize()
        {
            _day08 = new Day08();
        }

        [TestMethod]
        public void Sample()
        {
            var input = new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            var completed = _day08.RunProgramUntilLoopStarts(input);
            Assert.IsFalse(completed);
            Assert.AreEqual(5, _day08.Accumulator);
        }

        [TestMethod]
        public void Part1()
        {
            var completed = _day08.RunProgramUntilLoopStarts(Input);
            Assert.IsFalse(completed);
            Assert.AreEqual(1594, _day08.Accumulator);
        }

        [TestMethod]
        public void AlterInstructionsSample()
        {
            var input = new[]
            {
                "nop +0 ",
                "acc +1 ",
                "jmp +4 ",
                "acc +3 ",
                "jmp -3 ",
                "acc -99",
                "acc +1 ",
                "jmp -4 ",
                "acc +6 ",
            };

            var result = _day08.AlterProgramToCorrectLoop(input);
            Assert.AreEqual(8, result);
        }

        
        [TestMethod]
        public void AlterInstructionsToFixProgram()
        {
            var result = _day08.AlterProgramToCorrectLoop(Input);
            Assert.AreEqual(758, result);
        }
    }
}