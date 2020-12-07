using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    class Day07
    {

        public int CountBagColoursReversed(string[] sample)
        {
            var bags = Parse(sample).ToList();
            
            //turn into a lookup of bag to 
            var parents = bags.SelectMany(kvp => kvp.bags, (kvp, c) => (child: kvp.bag, parent: c.bag))
                .ToLookup(x=>x.parent, x=>x.child);

            var path = new HashSet<string>();

            void FindParents(string key)
            {
                path.Add(key);
                foreach (var parent in parents[key])
                {
                    FindParents(parent);
                }
            }

            FindParents("shiny gold bag");
            
            //path will include the shiny gold bag as well.
            return path.Count -1;
        }

        
        public IEnumerable<(string bag, IEnumerable<(int count, string bag)> bags)> Parse(string[] input)
        {
            foreach (var line in input)
            {
                var bag = $"{line.Split("bag", StringSplitOptions.TrimEntries)[0]} bag";

                var contents = Regex.Matches(line, @"(\d+) ([a-z]+ [a-z]+ bag)");
                var bags = contents.Select(x => (Convert.ToInt32(x.Groups[1].Value), x.Groups[2].Value));
                
                yield return (bag, bags);
            }
        }


        public int CountOfBagsNeeded(string[] input)
        {
            var bags = Parse(input).ToDictionary(x => x.bag, x => x.bags);

            int Total(string bag)
            {
                var result = 1;
                foreach (var (count, innerBag) in bags[bag])
                {
                    result += count * Total(innerBag);
                    Console.WriteLine(result);
                }

                return result;
            }

            return Total("shiny gold bag") - 1;
        }
    }
}
