using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day20Tests
    {
        private Day20 _day20;

        private string _sample =
@"Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...";

        [TestInitialize]
        public void Initialize()
        {
            _day20 = new Day20();
        }

        [TestMethod]
        public void ParseInput()
        {
            var tiles = _day20.ParseInput(_sample);
            Assert.IsNotNull(tiles);
            Assert.AreEqual(9, tiles.Length);
        }

        [TestMethod]
        public void GetEdgesShouldIncludeAllCombinations()
        {
            var tile = new Tile
            {
                Image = new[]
                {
                    "1234",
                    "ABCD",
                    "6789",
                    "ZYXW"
                }
            };

            var edges = _day20.GetEdgesForTile(tile);
            
            var expected = new[]
            {
                "1234",
                "Z6A1", //rot 90
                "WXYZ", //rot 90
                "4D9W", //rot 90
                "4321", //flip
                "W9D4", //rot 90
                "ZYXW", //rot 90
                "1A6Z", //rot 90
            };

            CollectionAssert.AreEquivalent(expected, edges);
        }
        
        [TestMethod]
        public void RotateTile()
        {
            var tile = new Tile
            {
                Image = new[]
                {
                    "AAAA",
                    "BBBB",
                    "CCCC",
                    "DDDD"
                }
            };

            var rotated = tile.Rotate90(tile.Image);
            var expected = new[]
            {
                "DCBA",
                "DCBA",
                "DCBA",
                "DCBA",
            };

            CollectionAssert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void FlipTile()
        {
            var tile = new Tile
            {
                Image = new[]
               {
                    "ABCD",
                    "EFGH",
                    "IJKL",
                    "MNOP"
                }
            };

            var flipped = tile.Flip(tile.Image);
            var expected = new[]
            {
                "DCBA",
                "HGFE",
                "LKJI",
                "PONM",
            };

            CollectionAssert.AreEqual(expected, flipped);
        }

        [TestMethod]
        public void BuildMap()
        {
            var tiles = _day20.ParseInput(_sample);
            _day20.BuildMap(tiles);

        }

        [TestMethod]
        public void Part1_Sample()
        {
            var result = _day20.CountCorners(_sample);
            Assert.AreEqual(20899048083289, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day20.CountCorners(File.ReadAllText("Input/Day20.txt"));
            Assert.AreEqual(13983397496713, result);
        }


        [TestMethod]
        public void CalculateWaterRoughness_Sample()
        {
            //Nessie has 15 #
            var tiles = _day20.ParseInput(_sample);

            var map = _day20.BuildMap(tiles);

            var bigTile = _day20.CombineMap(map);
            var roughness = _day20.CalculateWaterRoughness(bigTile);

            Assert.AreEqual(273, roughness);
        }


        [TestMethod]
        public void CalculateWaterRoughness()
        {
            //Nessie has 15 #
            var real = File.ReadAllText("Input/Day20.txt");
            var tiles = _day20.ParseInput(real);

            var map = _day20.BuildMap(tiles);

            var bigTile = _day20.CombineMap(map);
            var roughness = _day20.CalculateWaterRoughness(bigTile);

            Assert.AreEqual(2424, roughness);
            
        }

    }
}
