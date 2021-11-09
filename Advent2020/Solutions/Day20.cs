using System;
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
            return null;
        }

        
    }

    public class Tile
    {
        public int Id { get; set; } 
        public string[] Image { get; set; } 

        public string Top { get { return Image.First(); } }
        public string Bottom { get { return Image.Last(); } }

        public string Left 
        { 
            get 
            {
                return string.Join("", Image.Select(x => x.First()));
            } 
        }

        public string Right
        {
            get
            {
                return string.Join("", Image.Select(x => x.Last()));
            }
        }

    }
}
