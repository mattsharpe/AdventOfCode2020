using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    public class Day24
    {
        public int Part1(string[] input)
        {
            return ParseInput(input).Count;
        }

        public int Part2(string[] input)
        {
            var blackTiles = ParseInput(input);

            foreach (var _ in Enumerable.Range(0, 100))
            {
                blackTiles = FlipTiles(blackTiles);
            }
            
            return blackTiles.Count;

        }

        public HashSet<(int x, int y, int z)> ParseInput(string[] input)
        {

            var blackTiles = new HashSet<(int x, int y, int z)>();

            var targetTiles = input.Select(ParseLine)
                                .Select(x=> x.Aggregate((0, 0, 0), (current, move) => 
                                    (current.Item1 + move.x, current.Item2 + move.y, current.Item3 + move.z)));

            foreach (var tile in targetTiles)
            {
                if (blackTiles.Contains(tile))
                {
                    blackTiles.Remove(tile);
                }
                else
                {
                    blackTiles.Add(tile);
                }
            }
            return blackTiles;
        }

        public IEnumerable<(int x, int y, int z)> ParseLine(string line)
        {
            var result = new List<(int x, int y, int z)>();

            var next = line.StartsWith("e") || line.StartsWith("w")
                ? string.Concat(line.Take(1))
                : string.Concat(line.Take(2));

            result.Add(Neighbours[next]);

            if (line.Length > next.Length)
            {
                //shiny new syntax here.
                result.AddRange(ParseLine(line[next.Length..]));
            }

            return result;
        }


        HashSet<(int x, int y, int z)> FlipTiles(HashSet<(int x, int y, int z)> blackTiles)
        {
            return  blackTiles.SelectMany(Adjacent)
                .Distinct()
                .Where(t =>
                {
                    var neighborCount = Adjacent(t).Count(blackTiles.Contains);
                    return neighborCount == 2 || blackTiles.Contains(t) && neighborCount == 1;
                })
                .ToHashSet();
        }

        IEnumerable<(int x, int y, int z)> Adjacent((int x, int y, int z) tile)
        {
            var result = Neighbours.Values.Select(next => (next.x + tile.x, next.y + tile.y, next.z + tile.z)).ToList();
            return result;
        }

        //e, se, sw, w, nw, and ne
        private Dictionary<string, (int x, int y, int z)> Neighbours =>
         new()
         {
             {"e"  , (1, 0, -1) },
             {"w"  , (-1, 0, 1) },
             {"se" , (0, 1, -1) },
             {"sw" , (-1, 1, 0) },
             {"nw" , (0, -1, 1) },
             {"ne" , (1, -1, 0) }
            };
    }
}
