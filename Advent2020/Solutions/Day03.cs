using System.Linq;

namespace Advent2020.Solutions
{
    class Day03
    {
        public long CountTrees(string[] input, int dx, int dy)
        {
            var length = input.Length;
            var width = input[0].Length;

            return Enumerable.Range(0, length / dy).Count(i => input[i * dy][i * dx % width] == '#');
        }
        
        public long ProductOfAllSlopes(string[] input)
        {
            var result = CountTrees(input, 1, 1);
            result *= CountTrees(input, 3, 1);
            result *= CountTrees(input, 5, 1);
            result *= CountTrees(input, 7, 1);
            result *= CountTrees(input, 1, 2);
            
            return result;
        }
    }
}
