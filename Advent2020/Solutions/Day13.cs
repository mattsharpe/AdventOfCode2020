using System;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day13
    {
        public int FindFirstBus(string[] input)
        {
            var startTime = int.Parse(input[0]);
            var buses = input[1].Split(",").Where(x => x != "x").Select(int.Parse).ToList();

            Console.WriteLine(buses.Count);

            bool found = false;
            var currentTime = startTime;
            while (!found)
            {
                currentTime++;
                found = buses.Any(x => currentTime % x == 0);
            }

            var bus = buses.Single(x => currentTime % x == 0);
            return  bus * (currentTime - startTime);

        }
    }
}
