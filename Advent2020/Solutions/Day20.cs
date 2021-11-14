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
            Console.WriteLine(tiles.Count());
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


            //loop through the tiles and fine one that has only one edge at teh top and left
            Tile topLeft = null;
            foreach(var tile in tiles)
            {
                for(int i=0; i< 8; i++)
                {
                    if(matches[tile.Top].Count == 1 && matches[tile.Left].Count == 1)
                    {
                        topLeft = tile;
                        break;
                    }

                    tile.ChangePosition();
                }
            }
            Console.WriteLine(topLeft.Id);
            return null;
            
        }

        internal long CountCorners(string input)
        {
            var tiles = ParseInput(input);
            var map = BuildMap(tiles);

            
            return 0L;
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
        public int Id { get; set; } 
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
            switch (Position)
            {
                case 0:
                    return Image;
                case 1:
                    return Rotate90(Image);
                case 2:
                    return Rotate90(Rotate90(Image));
                case 3:
                    return Rotate90(Rotate90(Rotate90(Image)));
                case 4:
                    return Flip(Image);
                case 5:
                    return Flip(Rotate90(Image));
                case 6:
                    return Flip(Rotate90(Rotate90(Image)));
                case 7:
                    return Flip(Rotate90(Rotate90(Rotate90(Image))));
                default:
                    throw new ArgumentOutOfRangeException(nameof(Position));
            }
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
