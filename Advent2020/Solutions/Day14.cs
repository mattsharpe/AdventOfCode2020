using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    class Day14
    {
        private readonly Regex _maskRegex = new Regex(@"^mask = (.*)");
        private readonly Regex _memoryRegex = new Regex(@"mem\[(\d+)\] = (\d+)");
        private readonly Regex _replace = new Regex(@"X");

        public long SumMemoryAfterProgram(string[] input)
        {
            var storage = new Dictionary<int, long>();

            string mask = "";
            foreach (var line in input)
            {
                var match = _maskRegex.Match(line);
                if (match.Success)
                {
                    mask = match.Groups[1].Value;
                    continue;
                }

                var memMatch = _memoryRegex.Match(line);
                var address = int.Parse(memMatch.Groups[1].Value);
                var value = long.Parse(memMatch.Groups[2].Value);

                var result = ApplyMask(mask, value);
                storage[address] = result;
            }

            return storage.Sum(x => x.Value);
        }

        public long ApplyMask(string mask, long value)
        {
            var result = new StringBuilder(new string('#', 36));
            var valueString = Convert.ToString(value, 2).PadLeft(36, '0');

            for (var i = 0; i < mask.Length; i++)
            {
                result[i] = mask[i] == 'X' ? valueString[i] : mask[i];
            }

            return Convert.ToInt64(result.ToString(), 2);
        }

        public long SumMemoryWithFloatingBits(string[] input)
        {
            
            var mask = "";
            var storage = new Dictionary<long, long>();

            foreach (var line in input)
            {
        
                var match = _maskRegex.Match(line);
                if (match.Success)
                {
                    mask = match.Groups[1].Value;
                    continue;
                }

                var memMatch = _memoryRegex.Match(line);
                var address = int.Parse(memMatch.Groups[1].Value);
                var value = long.Parse(memMatch.Groups[2].Value);

                var addressAsBits = Convert.ToString(address, 2).PadLeft(36, '0').ToArray();

                //Apply mask to the memory address - adding in X to generate options from next
                for (var i = 0; i < mask.Length; i++)
                {
                    addressAsBits[i] = mask[i] == '0' ? addressAsBits[i] : mask[i];
                }

                var addresses = Generate(new string(addressAsBits));

                foreach(var memAddress in addresses)
                {
                    storage[Convert.ToInt64(memAddress, 2)] = value;
                };
            }

            return storage.Sum(x => x.Value);
        }

        private IEnumerable<string> Generate(string address)
        {
            if (!address.Contains("X")) { return new [] { address }; }
            
            var result = new List<string>();
            result.AddRange(Generate(_replace.Replace(address, "0", 1)));
            result.AddRange(Generate(_replace.Replace(address, "1", 1)));

            return result;
        }
    }
}
