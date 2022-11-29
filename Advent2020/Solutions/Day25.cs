using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Advent2020.Solutions
{
    public class Day25
    {
        public long Part1(string[] input)
        {
            var cardLoopSize = GetLoopSize(Convert.ToInt32(input.First()));

            return GetKey(Convert.ToInt32(input.Last()), cardLoopSize);
        }
        
        private int GetLoopSize(int publicKey)
        {
            var subjectNumber = 7;
            var i = 0;
            var value = 1;

            while (value != publicKey)
            {
                value = (value * subjectNumber) % 20201227;
                i++;
            }
            return i;
        }

        private long GetKey(int publicKey, int loopSize)
        {
            long value = 1;
            for (int i = 0; i < loopSize; i++)
            {
                value = value * publicKey % 20201227;
            }

            return value;
        }
    }
}
