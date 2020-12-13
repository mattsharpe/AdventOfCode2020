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

            var found = false;
            var currentTime = startTime;
            while (!found)
            {
                currentTime++;
                found = buses.Any(x => currentTime % x == 0);
            }

            var bus = buses.Single(x => currentTime % x == 0);
            return  bus * (currentTime - startTime);

        }

        public long EarliestTimestampForLinedUpDepartures(string timetable)
        {
            var buses = timetable.Split(",");
            var time = 0L;
            var busTime = long.Parse(buses[0]);

            //loop through the bus times and increment he current time in jumps
            for (var i = 1; i < buses.Length; i++)
            {
                if (buses[i].Equals("x")) continue;

                var nextBusDeparture = int.Parse(buses[i]);
                while ((time + i) % nextBusDeparture != 0)
                {
                    //jump the time up in increments until we hit a valid bus time (mod 0)
                    time += busTime;
                }
                //big jump to prevent counting all the numbers in the universe
                busTime *= nextBusDeparture;
            }
            return time;
        }

    }
}
