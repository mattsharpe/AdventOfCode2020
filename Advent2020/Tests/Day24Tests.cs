using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2020.Solutions;
using System.IO;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day24Tests
    {
        private Day24 _day24 = new();
        string[] Input => File.ReadAllLines(@"Input\Day24.txt");

        private string[] Sample => new []
        {
            "sesenwnenenewseeswwswswwnenewsewsw",
            "neeenesenwnwwswnenewnwwsewnenwseswesw",
            "seswneswswsenwwnwse",
            "nwnwneseeswswnenewneswwnewseswneseene",
            "swweswneswnenwsewnwneneseenw",
            "eesenwseswswnenwswnwnwsewwnwsene",
            "sewnenenenesenwsewnenwwwse",
            "wenwwweseeeweswwwnwwe",
            "wsweesenenewnwwnwsenewsenwwsesesenwne",
            "neeswseenwwswnwswswnw",
            "nenwswwsewswnenenewsenwsenwnesesenew",
            "enewnwewneswsewnwswenweswnenwsenwsw",
            "sweneswneswneneenwnewenewwneswswnese",
            "swwesenesewenwneswnwwneseswwne",
            "enesenwswwswneneswsenwnewswseenwsese",
            "wnwnesenesenenwwnenwsewesewsesesew",
            "nenewswnwewswnenesenwnesewesw",
            "eneswnwswnwsenenwnwnwwseeswneewsenese",
            "neswnwewnwnwseenwseesewsenwsweewe",
            "wseweeenwnesenwwwswnew"
        };

        [TestInitialize]
        public void Initialize()
        {
            _day24 = new Day24();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            Assert.AreEqual(10, _day24.Part1(Sample)); 
        }

        [TestMethod]
        public void Part1()
        {
            //223 too low
            Assert.AreEqual(277, _day24.Part1(Input));
        }

        [TestMethod]
        public void Part2_Sample()
        {
            Assert.AreEqual(2208, _day24.Part2(Sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(3531, _day24.Part2(Input));
        }
    }
}
