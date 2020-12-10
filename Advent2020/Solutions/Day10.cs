using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day10
    {
        public int ProductOfDifferences(string[] input)
        {
            //wrap the adapter collection with 0 (the terminal) and +3 for the device itself
            var jolts = ParseToJolts(input);

            var chain = jolts.Skip(1).Zip(jolts).Select(p => (a: p.First, b: p.Second)).ToList();

            var ones = chain.Count(pair => pair.a - pair.b == 1);
            var threes = chain.Count(pair => pair.a - pair.b == 3);

            return ones * threes;
        }

        private List<int> ParseToJolts(string[] input)
        {
            var jolts = new List<int> {0};
            jolts.AddRange(input.Select(int.Parse).OrderBy(x => x).ToList());
            jolts.Add(jolts.Last() + 3);

            return jolts;
        }

        public long NumberOfCombinations(string[] input)
        {
            var jolts = ParseToJolts(input);
            //populate the cache with things we know, laptop is the end device
            var cache = new Dictionary<int, long>
            {
                [jolts.Count - 1] = 0, 
                [jolts.Count - 2] = 1
            };

            long BuildCache(int adapterIndex)
            {
                //memoization is key to performance here
                if (cache.ContainsKey(adapterIndex))
                    return cache[adapterIndex];

                //work out all following combinations from here
                var value = new[] {1, 2, 3}.Where(x =>
                        adapterIndex + x < jolts.Count && jolts[adapterIndex + x] - jolts[adapterIndex] <= 3)
                    .Sum(x => BuildCache(adapterIndex + x));

                cache[adapterIndex] = value;
                return value;
            }

            BuildCache(0);
            return cache[0];
        }
    }
}