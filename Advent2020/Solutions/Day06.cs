
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day06
    {
        public List<string[]> ParseGroups(string input)
        {
            var groups = input.Split(new[] {"\r\n\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] {" ", "\r\n"}, StringSplitOptions.RemoveEmptyEntries)).ToList();

            return groups;
        }

        public int CountPositiveAnswersWhereAnyoneSaysYes(string input)
        {
            var groups = ParseGroups(input);
            return groups.Sum(x => x.SelectMany(y => y.ToCharArray()).Distinct().Count());
        }

        public int CountPositiveAnswersWhereEveryoneSaysYes(string input)
        {
            var groups = ParseGroups(input);

            return groups.Sum(group =>  group.SelectMany(x => x.ToCharArray())
                .GroupBy(x => x)
                .Select(x => new {Answer = x, Count = x.Count()})
                .Count(x => x.Count == group.Length));
        }
    }
}
