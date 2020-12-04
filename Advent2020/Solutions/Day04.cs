
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Passport = System.Collections.Generic.Dictionary<string, string>;
namespace Advent2020.Solutions
{
    class Day04
    {
        private IEnumerable<Passport> Parse(string input)
        {
            return input.Split(new[] {"\r\n\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] {" ", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(entry => entry.Split(':'))
                    .ToDictionary(kvp => kvp[0], kvp => kvp[1]));
        }

        private bool PassportContainsRequiredFields(Passport passport)
        {
            var requiredFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            return requiredFields.All(passport.ContainsKey);
        }

        public int CountValidPassports(string input)
        {
            var passports = Parse(input);
            return passports.Count(PassportContainsRequiredFields);
        }
        
        private bool PassportIsValid(Passport passport)
        {
            foreach (var (key, value) in passport)
            {
                if(value==null) return false;
                _ = int.TryParse(value, out var numericalValue);
                var result = key switch
                {
                    "byr" => numericalValue >= 1920 && numericalValue <= 2002,
                    "iyr" => numericalValue >= 2010 && numericalValue <= 2020,
                    "eyr" => numericalValue >= 2020 && numericalValue <= 2030,
                    "hgt" => Regex.IsMatch(value, @"((59|6\d|7[0-6])in)|((1[5-8]\d|9[0-3])cm)"),
                    "hcl" => Regex.IsMatch(value, "#([0-9]|[a-f]){6}"),
                    "ecl" => Regex.IsMatch(value, "amb|blu|brn|gry|grn|hzl|oth"),
                    "pid" => value.Length == 9,
                    _ => true
                };

                if (!result)
                {
                    return false;
                }
            }

            return true;
        }

        public int CountOfCorrectAndValidPassports(string input)
        {
            var passports = Parse(input);
            return passports.Where(PassportContainsRequiredFields)
                .Count(PassportIsValid);
        }
    }
}
