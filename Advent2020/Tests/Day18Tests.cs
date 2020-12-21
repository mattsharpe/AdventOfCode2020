using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day18Tests
    {
        private Day18 _day18;
        
        public string[] Input => File.ReadAllLines("Input/Day18.txt");

        [TestInitialize]
        public void Initialize()
        {
            _day18 = new Day18();
        }

        [TestMethod]
        public void BasicSample()
        {
            var equation = "1 + 2 * 3 + 4 * 5 + 6";
            Assert.AreEqual(71, _day18.EvaluateEquation(equation));
        }

        [TestMethod]
        public void BasicSampleWithBrackets()
        {
            var equation = "1 + (2 * 3) + (4 * (5 + 6))";
            Assert.AreEqual(51, _day18.EvaluateEquation(equation));
        }

        [DataTestMethod]
        [DataRow("2 * 3 + (4 * 5)", 26)]
        [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void Samples(string equation, int expected)
        {
            Assert.AreEqual(expected, _day18.EvaluateEquation(equation));
        }

        [TestMethod]
        public void SumOfAllEquations()
        {
            Assert.AreEqual(11297104473091, _day18.SumAllEquations(Input));
        }

        [TestMethod]
        public void SampleAdditionPriority()
        {
            var equation = "1 + 2 * 3 + 4 * 5 + 6";
            Assert.AreEqual(231, _day18.EvaluateEquation(equation, true));
        }

        [DataTestMethod]
        [DataRow("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [DataRow("2 * 3 + (4 * 5)", 46)]
        [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void SamplesWithAdditionPriority(string equation, int expected)
        {
            Assert.AreEqual(expected, _day18.EvaluateEquation(equation, true));
        }

        [TestMethod]
        public void SumOfAllEquationsWithAddition()
        {
            Assert.AreEqual(185348874183674, _day18.SumAllEquations(Input, true));
        }
    }
}
