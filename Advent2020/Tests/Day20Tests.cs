using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void TileMethods()
        {
            var tile = _day20.ParseInput(_sample).First();

            Assert.AreEqual(2311, tile.Id);
            
            Assert.AreEqual("..##.#..#.", tile.Top);
            Assert.AreEqual("..###..###", tile.Bottom);
            Assert.AreEqual(".#####..#.", tile.Left);
            Assert.AreEqual("...#.##..#", tile.Right);
        }

        [TestMethod]
        public void Part1()
        {
            _day20.ParseInput(File.ReadAllText("Input/Day20.txt"));
        }
    }
}
