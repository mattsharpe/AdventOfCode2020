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

            Tile MatchTile(Tile left, Tile above)
            {
                //this is the top left corner
                if (left == null && above == null)
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

                    var tile = above != null ?
                        matches[above.Bottom].SingleOrDefault(x => x.Id != above.Id) :
                        matches[left.Right].SingleOrDefault(x => x.Id != left.Id);

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
            var size = Convert.ToInt32(Math.Sqrt(tiles.Length));

            var result = new Tile[size][];

            for (var i = 0; i < size; i++)
            {
                result[i] = new Tile[size];

                for (var j = 0; j < size; j++)
                {
                    var left = j == 0 ? null : result[i][j - 1];
                    var above = i == 0 ? null : result[i - 1][j];
                    result[i][j] = MatchTile(left, above);
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

        public Tile CombineMap(Tile[][] map)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < map.Length; i++)
            {
                for (int line = 0; line < 8; line++)
                {
                    for (int j = 0; j < map.Length; j++)
                    {
                        var tile = map[i][j];
                        sb.Append(tile.InnerContent[line]);
                    }

                    sb.AppendLine();
                }
            }

            return new Tile
            {
                Image = sb.ToString().Split(Environment.NewLine),
                Position = 0
            };

        }

        //Get all possible edges based on rotation / flip of tile
        public List<string> GetEdgesForTile(Tile tile)
        {
            var edges = new List<string> { tile.Top, tile.Left, tile.Right, tile.Bottom };

            edges.AddRange(edges.Select(x => new string(x.Reverse().ToArray())).ToList());

            return edges;
        }

        public int CountNessiesInTile(Tile bigTile)
        {
            var monster = new[]
            {
                "                  # ",
                "#    ##    ##    ###",
                " #  #  #  #  #  #   "
            };

            var width = 20;
            var height = 3;
            
            var size = bigTile.TransformedImage().Length;
            var found = 0;

            for (var y = 0; y < size - height - 1; y++)
            {
                for (var x = 0; x < size - width - 1; x++)
                {
                    var nessie = true;
                    for (var monsterY = 0; monsterY < height; monsterY++)
                    for (var monsterX = 0; monsterX < width; monsterX++)
                    {
                        //blank tiles in the monster mask can match anything
                        if (monster[monsterY][monsterX] == ' ') continue;
                        if (bigTile.Picture[monsterY + y][monsterX + x] != '#')
                        {
                            nessie = false;
                            break;
                        };
                    }

                    if (nessie)
                    {
                        found++;
                    }
                }
            }

            return found;

        }

        public int CalculateWaterRoughness(Tile tile)
        {
            var monsterCount = 0;
            for (var i = 0; i < 8; i++)
            {
                var count = CountNessiesInTile(tile);
                if(count > 0 )
                {
                    monsterCount = count;
                    break;
                }
                tile.ChangePosition();
            }

            var result = string.Join("",tile.Picture).Count(x => x == '#') - (15 * monsterCount);
            return result;
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
                for (int j = original[i].Length - 1; j >= 0; j--)
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

        public string[] TransformedImage()
        {
            string[] Rotate(int times, string[] image)
            {
                for (var i = 0; i < times; i++)
                {
                    image = Rotate90(image);
                }

                return image;
            }


            var result = Position switch
            {
                0 => Image,
                1 => Rotate(1, Image),
                2 => Rotate(2, Image),
                3 => Rotate(3, Image),
                4 => Flip(Image),
                5 => Flip(Rotate(1, Image)),
                6 => Flip(Rotate(2, Image)),
                7 => Flip(Rotate(3, Image)),
                _ => throw new ArgumentOutOfRangeException(nameof(Position)),
            };

            Picture = result;

            return result;
        }

        public string Top => TransformedImage().First();
        public string Bottom => TransformedImage().Last();

        public string Left => string.Join("", TransformedImage().Select(x => x.First()));

        public string Right => string.Join("", TransformedImage().Select(x => x.Last()));

        public string[] InnerContent => TransformedImage().Skip(1).SkipLast(1).Select(x => new string(x.Skip(1).SkipLast(1).ToArray())).ToArray();

        public string[] Picture { get; private set; }
    }

}
