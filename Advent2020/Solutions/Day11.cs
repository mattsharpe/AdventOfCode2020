using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day11
    {
        public int OccupiedSeats => _map.Cast<char>().Count(seat => seat == '#');

        private char[,] _map;

        public void Stabilise(string[] input, bool part2 = false)
        {
            ParseInput(input);
            //PrintMap();
            var previous = OccupiedSeats;

            while (true)
            {
                if (part2)
                {
                    TakeTurn(CountVisibleOccupiedSeats, 5);
                    //PrintMap();
                }
                else
                {
                    TakeTurn(CountAdjacentOccupiedSeats, 4);
                }
                
                if (OccupiedSeats == previous)
                    break;

                previous = OccupiedSeats;
            }
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

        int CountVisibleOccupiedSeats(int x, int y)
        {
            var offsets = new List<(int x, int y)>
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };

            var result = offsets.Count(offset =>
            {
                var newX = offset.x + x;
                var newY = offset.y + y;
                if (newX < _map.GetLowerBound(0) || newX > _map.GetUpperBound(0) ||
                    newY < _map.GetLowerBound(1) || newY > _map.GetUpperBound(1)) return false;

                while (_map[newX, newY] == '.')
                {
                    newX += offset.x;
                    newY += offset.y;

                    if (newX < _map.GetLowerBound(0) || newX > _map.GetUpperBound(0) ||
                        newY < _map.GetLowerBound(1) || newY > _map.GetUpperBound(1)) 
                        return false;
                }


                return _map[newX, newY] == '#';
            });

            return result;
        }

        private void TakeTurn(Func<int, int, int> countOccupiedSeats, int tolerance)
        {
            var newSeats = new char[_map.GetUpperBound(0)+1, _map.GetUpperBound(1)+1];
            for (var y = 0; y <= _map.GetUpperBound(1); y++)
            {
                for (var x = 0; x <= _map.GetUpperBound(0); x++)
                {
                    var current = _map[x, y];
                    var occupiedSeats = countOccupiedSeats(x, y);
                    switch (current)
                    {
                        case 'L' when occupiedSeats == 0:
                            newSeats[x, y] = '#';
                            continue;
                        case '#' when occupiedSeats >= tolerance:
                            newSeats[x, y] = 'L';
                            continue;
                        default:
                            newSeats[x, y] = _map[x,y];
                            break;
                    }
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
            Console.WriteLine($"-- {OccupiedSeats} --------------------------------");
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
