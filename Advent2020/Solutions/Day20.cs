using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Tile[][] BuildMap(Tile[] tiles)
        {
            Dictionary<string, List<Tile>> matches = new();

            foreach (var tile in tiles)
            {

                foreach (var edge in GetEdgesForTile(tile))
                {
                
                    if (matches.ContainsKey(edge))
                    {
                        matches[edge].Add(tile);
                    }
                    else
                    {
                        matches[edge] = new List<Tile> { tile };
                    }
                }
            }

            Tile getNeighbour(Tile tile, string edge) => matches[edge].SingleOrDefault(x => x.Id != tile.Id);

            Tile matchTile(Tile left, Tile above)
            {
                //this is the top left corner
                if(left == null && above == null)
                {
                    foreach (var tile in tiles)
                    {
                        for (var i = 0; i < 8; i++)
                        {
                            if (matches[tile.Top].Count == 1 && matches[tile.Left].Count == 1)
                            {
                                return tile;
                            }
                            tile.ChangePosition();
                        }
                    }
                } 
                else
                {
                    var tile = above != null ? getNeighbour(above, above.Bottom) : getNeighbour(left, left.Right);

                    while (true)
                    {
                        var topMatch = above == null ? matches[tile.Top].Count == 1 : tile.Top == above.Bottom;
                        var leftMatch = left == null ? matches[tile.Left].Count == 1 : tile.Left == left.Right;

                        if (topMatch && leftMatch)
                        {
                            return tile;
                        }
                        tile.ChangePosition();
                    }
                }
                throw new InvalidOperationException();
            }

            //loop through the tiles and fine one that has only one edge at the top and left
            var topLeft = matchTile(null, null);
            var next = matchTile(topLeft, null);

            var size = Convert.ToInt32(Math.Sqrt(tiles.Length));

            Tile[][] result = new Tile[size][];

            for(int i=0; i < size; i++)
            {
                result[i] = new Tile[size];

                for (int j=0; j < size; j++)
                {
                    var left = j == 0 ? null : result[i][j - 1];
                    var above = i == 0 ? null : result[i -1][j];
                    result[i][j] = matchTile(left, above);
                }
            }

            return result;
            
        }

        internal long CountCorners(string input)
        {
            var tiles = ParseInput(input);
            var map = BuildMap(tiles);

            var a = map.First().First().Id;
            var b = map.First().Last().Id;
            var c = map.Last().First().Id;
            var d = map.Last().Last().Id;

            return a * b * c * d;
        }

        //Get all possible edges based on rotation / flip of tile
        public List<string> GetEdgesForTile(Tile tile)
        {
            var edges = new List<string> { tile.Top, tile.Left, tile.Right, tile.Bottom };

            edges.AddRange(edges.Select(x => new string(x.Reverse().ToArray())).ToList());
            
            return edges;
        }
    }

    public class Tile
    {
        public long Id { get; set; } 
        public string[] Image { get; set; } 
        
        public int Position { get; set; }

        public void ChangePosition()
        {   
            Position = (Position + 1) % 8;
        }

        public string[] Rotate90(string[] original)
        {
            var result = new string[original.Length];

            for (int i = 0; i < original.Length; i++)
            {
                var sb = new StringBuilder();
                for(int j = original[i].Length - 1; j >= 0; j--)
                {
                    sb.Append(original[j][i]);
                }
                result[i] = sb.ToString();
            }

            return result;
        }

        public string[] Flip(string[] original)
        {
            return original.Select(x => new string(x.Reverse().ToArray())).ToArray();
        }

        /* TODO: Tidy up
         * If x > 3 call rotate and x-= 3
         * Call rotate x times
         */
        public string[] TransformedImage()
        {
            string[] rotateTimes(int x, string[] image)
            {
                for (int i = 0; i < x; i++)
                {
                    image = Rotate90(image);
                }

                return image;
            }
            

            return Position switch
            {
                0 => Image,
                1 => rotateTimes(1, Image),
                2 => rotateTimes(2, Image),
                3 => rotateTimes(3, Image),
                4 => Flip(Image),
                5 => Flip(rotateTimes(1, Image)),
                6 => Flip(rotateTimes(2, Image)),
                7 => Flip(rotateTimes(3, Image)),
                _ => throw new ArgumentOutOfRangeException(nameof(Position)),
            };
        }

        public string Top 
        { 
            get 
            { 
                return TransformedImage().First(); 
            } 
        }

        public string Bottom 
        { 
            get 
            { 
                return TransformedImage().Last(); 
            } 
        }

        public string Left 
        { 
            get 
            { 
                return string.Join("", TransformedImage().Select(x => x.First()).Reverse()); 
            } 
        }

        public string Right
        {
            get 
            { 
                return string.Join("", TransformedImage().Select(x => x.Last()).Reverse()); 
            }
        }
    }

}
