using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2020.Solutions;
using System.IO;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day21Tests
    {

        private Day21 _day21;
        private string[] _sample = new[] {
            "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
            "trh fvjkl sbzzf mxmxvkd(contains dairy)",
            "sqjhc fvjkl(contains soy)",
            "sqjhc mxmxvkd sbzzf(contains fish)" 
        };

        [TestInitialize]
        public void Initialize()
        {
            _day21 = new Day21();
        }

        [TestMethod]
        public void Part1_Sample()
        {
            var result = _day21.CountSafeIngredients(_sample);

            Assert.AreEqual(5, result);
        }


        [TestMethod]
        public void Part1()
        {
            var result = _day21.CountSafeIngredients(File.ReadAllLines("Input/Day21.txt"));

            Assert.AreEqual(2265, result);
        }

        [TestMethod]
        public void Part2_Sample()
        {
            var result = _day21.DangerousIngredientList(_sample);

            Assert.AreEqual("mxmxvkd,sqjhc,fvjkl", result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = _day21.DangerousIngredientList(File.ReadAllLines("Input/Day21.txt"));

            Assert.AreEqual("dtb,zgk,pxr,cqnl,xkclg,xtzh,jpnv,lsvlx", result);
        }
    }
}
