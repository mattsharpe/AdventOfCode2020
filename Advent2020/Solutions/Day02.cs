using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    class Day02
    {
        private (int min, int max, char character, string password) ParsePassword(string input)
        {
            var regex = new Regex(@"(\d*)-(\d*) ([a-z]): (\w*)");
            var match = regex.Match(input);

            return (Convert.ToInt32(match.Groups[1].Value), 
                Convert.ToInt32(match.Groups[2].Value), 
                match.Groups[3].Value[0], 
                match.Groups[4].Value);
        }

        public bool IsValid(string line)
        {
            var (min, max, character, password) = ParsePassword(line);

            var instances = password.Count(x => x.Equals(character));
            return instances >= min && instances <= max;
        }
        public int CountValidPasswords(string[] sample, bool corporatePolicy = false)
        {
            return corporatePolicy ? sample.Count(ValidatePasswordAgainstOfficialTobogganCorporatePolicy): sample.Count(IsValid);
        }

        public bool ValidatePasswordAgainstOfficialTobogganCorporatePolicy(string line)
        {
            var (min, max, character, password) = ParsePassword(line);

            return password[min-1] == character && password[max-1] != character ||
                   password[min-1] != character && password[max-1] == character;
        }
    }
}
