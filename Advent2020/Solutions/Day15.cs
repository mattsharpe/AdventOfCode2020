using System.Linq;

namespace Advent2020.Solutions
{
    public class Day15
    {
        public int RunUntilTargetNumber(int[] input, int targetNumber = 2020)
        {
            var numbers = new int[targetNumber];
            var turn = 1;
            
            foreach (var i in input)
            {
                numbers[i] = turn++;
            }

            var lastNumberSpoken = input.Last();
            turn = input.Length;

            var next = 0;

            while (turn < targetNumber)
            {
                turn++;
                lastNumberSpoken = next;

                next = numbers[lastNumberSpoken] != 0 ? 
                    turn - numbers[lastNumberSpoken] : 
                    0;

                numbers[lastNumberSpoken] = turn;
                
            }
            
            return lastNumberSpoken;
        }

    }
}
