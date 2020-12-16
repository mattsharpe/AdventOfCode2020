using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    public class Day16
    {
        public int CountInvalidTickets(string input)
        {
            var regex = new Regex(@"(\d+)-(\d+)");
            var split = input.Split($"{Environment.NewLine}{Environment.NewLine}");

            var ranges = split[0].Split(Environment.NewLine).SelectMany(line =>
            {
                return regex.Matches(line).Select(x =>
                    (Lower: int.Parse(x.Groups[1].Value), Upper: int.Parse(x.Groups[2].Value)));
            }).ToList();

            var ticketNumbers = split[2].Split(':')[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(line => line.Split(',').Select(int.Parse))
                .ToList();

            return ticketNumbers.Where(number => !ranges.Any(range => range.Lower <= number && number <= range.Upper)).Sum();
        }
    }
}