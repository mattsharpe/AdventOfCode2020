using System.Linq;

namespace Advent2020.Solutions
{
    public class Day15
    {
        public int RunUntilTargetNumber(int[] input, int targetNumber = 2020)
        {
            int turn = 1;
            //dictionary of number -> turn first spoken
            var numbers = input.ToDictionary(x => x, x => turn++);
            var lastNumberSpoken = input.Last();

            turn = input.Length;
            var next = 0;
            while (turn < targetNumber)
            {
                turn++;
                lastNumberSpoken = next;

                next = numbers.ContainsKey(lastNumberSpoken) ? 
                    turn - numbers[lastNumberSpoken] : 
                    0;

                numbers[lastNumberSpoken] = turn;
                
            }
            
            return lastNumberSpoken;
        }

    }
}
