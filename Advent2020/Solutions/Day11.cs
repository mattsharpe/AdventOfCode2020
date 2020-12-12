using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Advent2020.Solutions
{
    class Day11
    {
        public int OccupiedSeats { get; set; }
        private char[,] _map;

        public void Stabilise(string[] input)
        {
            ParseInput(input);

            TakeTurn();
           

            
        }

        int CountAdjacentOccupiedSeats(int x, int y)
        {
            var offsets = new List<(int a, int b)>
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };

            var result = offsets.Count(offset =>
            {
                var newX = offset.a + x;
                var newY = offset.b + y;
                if (newX < _map.GetLowerBound(0) || newX > _map.GetUpperBound(0) ||
                    newY < _map.GetLowerBound(1) || newY > _map.GetUpperBound(1)) return false;
                return _map[newX, newY] == '#';
            });

            return result;
        }

        void TakeTurn()
        {
            var newSeats = new char[_map.GetUpperBound(0), _map.GetUpperBound(1)];
            for (var y = 0; y <= _map.GetUpperBound(1); y++)
            {
                for (var x = 0; x <= _map.GetUpperBound(0); x++)
                {
                    var current = _map[x, y];
                    var occupiedSeats = CountAdjacentOccupiedSeats(x, y);
                    if (current == 'L' && occupiedSeats == 0)
                    {
                        newSeats[x, y] = 'L';
                    }

                    newSeats[x, y] = _map[x,y];
                }
            }

            _map = newSeats;
        }

        private void ParseInput(string[] input)
        {
            _map = new char[input[0].Length, input.Length];
            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    var square = input[y][x];
                    _map[x, y] = square;

                }
            }
        }

        public void PrintMap()
        {
            for (var y = 0; y <= _map.GetUpperBound(1); y++)
            {
                for (var x = 0; x <= _map.GetUpperBound(0); x++)
                {
                    Console.Write(_map[x, y]);
                }
                Console.WriteLine();
            }
        }

    }
}
