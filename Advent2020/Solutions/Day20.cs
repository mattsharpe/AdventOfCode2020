using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    public class Day20
    {
        public Tile[] ParseInput(string input)
        {
            var tiles = input.Split($"{Environment.NewLine}{Environment.NewLine}").Select(x =>
            {
                var id = Regex.Match(x, "\\d+").Value;

                return new Tile
                {
                    Id = int.Parse(id),
                    Image = x.Split(Environment.NewLine).Skip(1).ToArray()
                };
            }).ToArray();

            return tiles;

        }

        public Tile[][] MatchTiles(Tile[] tiles)
        {
            Dictionary<string, List<Tile>> matches = new();

            //for every tile, record each of the 8 possible options for the edges 


            foreach (var tile in tiles)
            {
                
                var edge = tile.Top;
                if (matches.ContainsKey(edge))
                {
                    matches[edge].Add(tile);
                } else
                {
                    matches[edge] = new List<Tile> { tile };
                }
            }

            return null;
            
        }

        internal long CountCorners(string input)
        {
            var tiles = ParseInput(input);
            var map = MatchTiles(tiles);
            return 0L;
        }

   
    }

    public class Tile
    {
        public int Id { get; set; } 
        public string[] Image { get; set; } 

        public int Orientation { get; set; }

        public string Top 
        { 
            get { return Image.First(); } 
        }

        public string Bottom 
        { 
            get { return Image.Last(); } 
        }

        public string Left 
        { 
            get { return string.Join("", Image.Select(x => x.First())); } 
        }

        public string Right
        {
            get { return string.Join("", Image.Select(x => x.Last())); }
        }
    }
}
