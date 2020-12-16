using System;
using System.IO;
using Advent2020.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2020.Tests
{
    [TestClass]
    public class Day16Tests
    {
        private Day16 _day16;

        private readonly string[] _sample =
        {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50",
            "",
            "your ticket:",
            "7,1,14",
            "",
            "nearby tickets:",
            "7,3,47",
            "40,4,50",
            "55,2,20",
            "38,6,12"
        };

        private string[] Input => File.ReadAllLines("Input/Day16.txt");

        [TestInitialize]
        public void Initialize()
        {
            _day16 = new Day16();
        }

        [TestMethod]
        public void SumOfInvalidSampleTicketNumbers()
        {
            var result = _day16.CountInvalidTickets(_sample);
            Assert.AreEqual(71, result);
        }

        [TestMethod]
        public void SumOfInvalidTicketNumbers()
        {
            var result = _day16.CountInvalidTickets(Input);
            Assert.AreEqual(24110, result);
        }

        [TestMethod]
        public void ProductOfDepartureFields()
        {
            var result = _day16.ProductOfDepartureFields(Input);
            Assert.AreEqual(6766503490793, result);
        }
    }
}