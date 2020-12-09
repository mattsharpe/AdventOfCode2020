using System;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day09
    {
        public long FirstNumberNotSumOfPreceding(string[] input, int preamble)
        {
            var numbers = input.Select(long.Parse).ToList();
            for (var i = 0; i < numbers.Count-preamble; i++)
            {
                var targetNumber = numbers[i + preamble];
                var range = numbers.Skip(i).Take(preamble).ToArray();
                var added = range.SelectMany(x => range, (x, y) => x + y);

                if (!added.Contains(targetNumber))
                {
                    return targetNumber;
                }
            }

            return 0;
        }

        public long SumOfRangeThatSumsToMismatchedNumber(string[] input, int preamble)
        {
            var numbers = input.Select(long.Parse).ToList();
            var targetNumber = FirstNumberNotSumOfPreceding(input, preamble);

            for (int i = 0; i < input.Length - preamble; i++)
            {
                var sum = 0L;
                var range = numbers.Skip(i).TakeWhile(x =>
                {
                    sum += x;
                    return sum <= targetNumber;
                }).ToList();

                if (range.Sum() == targetNumber)
                    return range.Min() + range.Max();
            }
            return 0;
        }
    }
}
