using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day15Tests
    {
        private Day15 _day15;

        private readonly int[] _sample = {0, 3, 6};
        private readonly int[] _input = {8, 13, 1, 0, 18, 9};

        [TestInitialize]
        public void Initialize()
        {
            _day15 = new Day15();
        }

        [TestMethod]
        public void RunGameSample()
        {
            var result = _day15.RunUntilTargetNumber(_sample);
            Assert.AreEqual(436, result);
        }

        [DataTestMethod]
        [DataRow(new[] {1, 3, 2}, 1)]
        [DataRow(new[] {2, 1, 3}, 10)]
        [DataRow(new[] {1, 2, 3}, 27)]
        [DataRow(new[] {2, 3, 1}, 78)]
        [DataRow(new[] {3, 2, 1}, 438)]
        [DataRow(new[] {3, 1, 2}, 1836)]
        public void RunToTwentyTwentyTestCases(int[] numbers, int expected)
        {
            var result = _day15.RunUntilTargetNumber(numbers);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RunGame()
        {
            var result = _day15.RunUntilTargetNumber(_input);
            Assert.AreEqual(755, result);
        }

        [DataTestMethod]
        [DataRow(new[] {0, 3, 6}, 175594)]
        [DataRow(new[] { 1, 3, 2 }, 2578)]
        [DataRow(new[] { 2, 1, 3 }, 3544142)]
        [DataRow(new[] { 2, 3, 1 }, 6895259)]
        [DataRow(new[] { 3, 2, 1 }, 18)]
        [DataRow(new[] { 3, 1, 2 }, 362)]
        private void RunToThirtyMillionTestCases(int[] numbers, int expected)
        {
            var result = _day15.RunUntilTargetNumber(numbers, 30_000_000);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RunGameToThirtyMillion()
        {
            var result = _day15.RunUntilTargetNumber(_input, 30_000_000);
            Assert.AreEqual(11962, result);
        }
    }
}