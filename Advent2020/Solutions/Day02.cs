using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    class Day02
    {
        public bool IsValid(string line)
        {
            var regex = new Regex(@"(\d*)-(\d*) ([a-z]): (\w*)");
            var match = regex.Match(line);
            var min = Convert.ToInt32(match.Groups[1].Value);
            var max = Convert.ToInt32(match.Groups[2].Value);
            var character = match.Groups[3].Value[0];
            var password = match.Groups[4].Value;

            var instances = password.Count(x => x.Equals(character));
            return instances >= min && instances <= max;
        }

        public int CountValidPasswords(string[] sample)
        {
            return sample.Count(IsValid);
        }
    }
}
