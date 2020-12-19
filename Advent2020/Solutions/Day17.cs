using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Advent2020.Solutions
{
    class Day17
    {
        public int ActiveCubesAfterIterations(string[] input, int generations, bool fourDimensions = false)
        {
            var active = ParseInput(input);
            
            for (var i = 0; i < generations; i++)
            {
                active =  ProcessCycle(active, fourDimensions);
            }

            Console.WriteLine("Active cells in hashset: " + active.Count);

            return active.Count;
        }

        private void PrintMap(Dictionary<Vector4, bool> map)
        {
            
            for (var z = map.Min(x => x.Key.Z); z <= map.Max(x => x.Key.Z); z++){
                Console.WriteLine($"z={z}");
                for (var y = map.Min(x => x.Key.Y); y <= map.Max(x => x.Key.Y); y++)
                {
                    for (var x = map.Min(a => a.Key.X); x <= map.Max(a => a.Key.X); x++)
                    {
                        Console.Write(map[new Vector4(x, y, z, 0)] ? '#' : '.');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public IEnumerable<Vector4> NeighboursOf3D(Vector4 point)
        {
            return from x in Enumerable.Range(-1, 3)
                from y in Enumerable.Range(-1, 3)
                from z in Enumerable.Range(-1, 3)
                let result = new Vector4(point.X + x, point.Y + y, point.Z + z, 0)
                where result != point
                select result;
        }

        public IEnumerable<Vector4> NeighboursOf4D(Vector4 point)
        {
            return from x in Enumerable.Range(-1, 3)
                from y in Enumerable.Range(-1, 3)
                from z in Enumerable.Range(-1, 3)
                from w in Enumerable.Range(-1, 3)
                let result = new Vector4(point.X + x, point.Y + y, point.Z + z, point.W + w)
                where result != point
                select result;
        }

        public HashSet<Vector4> ProcessCycle(HashSet<Vector4> active, bool fourDimensions)
        {
            var getNeighbours = fourDimensions ? (Func<Vector4, IEnumerable<Vector4>>) NeighboursOf4D : NeighboursOf3D;

            var nextActive = new HashSet<Vector4>();
            var inactive = new Dictionary<Vector4, int>();

            foreach (var point in active) 
            {
                var currentActiveNeighbours = 0;

                foreach (var neighbour in getNeighbours(point))
                {
                    if (active.Contains(neighbour))
                    {
                        currentActiveNeighbours++;
                    }
                    else
                    {
                        inactive[neighbour] = inactive.GetValueOrDefault(neighbour) + 1;
                    }
                }

                if (currentActiveNeighbours == 2 || currentActiveNeighbours == 3) 
                {
                    nextActive.Add(point);
                }
            }

            foreach (var x in inactive.Where(x => x.Value == 3))
            {
                nextActive.Add(x.Key);
            }

            return nextActive;
        }

        private HashSet<Vector4> ParseInput(string[] input)
        {
            var active = new HashSet<Vector4>();

            var currentPoint = new Vector4(0,0,0,0);
            foreach (var line in input)
            {
                foreach (var character in line)
                {
                    if (character == '#')
                    {
                        active.Add(currentPoint);
                    }
                    currentPoint.X++;
                }
                currentPoint.X = 0;
                currentPoint.Y++;
            }

            return active;
        }
    }
}
