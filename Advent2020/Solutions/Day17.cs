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
            var parsed = ParseInput(input);
            var map = parsed.Item1;
            Console.WriteLine(parsed.Item2.Count);
            
            for (var i = 0; i < generations; i++)
            {
                map = ProcessCycle(map, fourDimensions);
            }

            Console.WriteLine(_count);
            return map.Count(x => x.Value);
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

        private static int _count = 0;
        public Dictionary<Vector4, bool> ProcessCycle(Dictionary<Vector4, bool> map, bool fourDimensions)
        {
            Func<Vector4, IEnumerable<Vector4>> getNeighbours;
            getNeighbours = fourDimensions ? (Func<Vector4, IEnumerable<Vector4>>) NeighboursOf4D : NeighboursOf3D;
            var nextState = new Dictionary<Vector4, bool>();
            var toExplore = map.SelectMany(x => getNeighbours(x.Key));

            foreach (var cell in toExplore)
            {
                var neighbours = getNeighbours(cell);
                var countOfActive = neighbours.Count(x => map.ContainsKey(x) && map[x]);
                map.TryGetValue(cell, out var value);
                nextState[cell] = value ? countOfActive == 2 || countOfActive == 3 : countOfActive == 3;
                _count++;
            }

            return nextState;
        }

        private (Dictionary<Vector4, bool>, HashSet<Vector4>) ParseInput(string[] input)
        {
            var active = new HashSet<Vector4>();
            var map = new Dictionary<Vector4, bool>();

            var currentPoint = new Vector4(0,0,0,0);
            foreach (var line in input)
            {
                foreach (var character in line)
                {
                    map.Add(currentPoint, character =='#');
                    if (character == '#')
                    {
                        active.Add(currentPoint);
                    }
                    currentPoint.X++;
                }
                currentPoint.X = 0;
                currentPoint.Y++;
            }

            return (map, active);
        }
    }
}
