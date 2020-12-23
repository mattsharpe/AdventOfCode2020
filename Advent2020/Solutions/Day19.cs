using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    class Day19
    {
        public int MessagesMatchingRule(string[] input)
        {
            var rules = CompileRules(input);
            
            var targetRule = rules["0"];
            var validRegex = new Regex($"^{targetRule}$");
            Console.WriteLine(validRegex);
            return input.Count(x => validRegex.IsMatch(x));
        }

        private Dictionary<string, string> CompileRules(string[] input)
        {
            var ruleLookup = new Dictionary<string, string[]>();

            foreach (var rule in input.TakeWhile(x=>x != string.Empty))
            {
                var split = rule.Split(':');
                var id = split[0];
                var ruleParts = split[1];
                ruleLookup.Add(id, ruleParts.Replace("\"", "").Split('|'));
            }

            var nestedRuleRegex = new Regex(@"\d+");

            var compiledRules = new Dictionary<string, string>(
                ruleLookup.Where(x => x.Value.All(value => !nestedRuleRegex.IsMatch(value)))
                    .Select(x => new KeyValuePair<string, string>(x.Key, x.Value.First().Trim()))
            );


            //while compile rule .count < ruleLookup.count pass through the list and solve what we can.
            while (compiledRules.Count != ruleLookup.Count)
            {
                foreach (var (key, rule) in ruleLookup.Where(x => x.Value.Any(rule => nestedRuleRegex.IsMatch(rule))))
                {
                    for (var i = 0; i < rule.Length; i++)
                    {
                        var updated = rule[i];
                        var matches = nestedRuleRegex.Matches(updated);

                        foreach (Match match in matches)
                        {
                            if (compiledRules.ContainsKey(match.Value))
                            {
                                var compiled = compiledRules[match.Value];

                                updated = Regex.Replace(updated, @$"\b{match.Value}\b", compiled);
                            }
                            else if (matches.Count == 1 && matches.Single().Value == key)
                            {
                                // bit of a hack this one; the puzzle gives an unusually explicit hint:
                                // "you only need to handle the rules you have"
                                // taking advantage of this and analysing the rules shows any further than this depth and the resultant
                                // regex would be longer than any puzzle input hence we stop it here.
                                updated = Enumerable.Range(0, 4).Aggregate(updated, (current, _) => 
                                    Regex.Replace(current, @$"\b{match.Value}\b", $"({string.Join("|", rule)})"));

                                updated = Regex.Replace(updated, @$"\b{match.Value}\b", "");
                            }
                        }
                        
                        
                        rule[i] = updated.Trim();
                    }

                    //if after changes all pointers to other rules are resolved we can compile this rule:
                    if (rule.Any(part => nestedRuleRegex.IsMatch(part))) continue;

                    var result = rule.Length switch
                    {
                        1 => rule[0],
                        2 => $"({string.Join("|", rule)})",
                        _ => throw new Exception("Unexpected number of arguments")
                    };
                    compiledRules[key] = result.Replace(" ", "");
                }
            }

            return compiledRules;
        }

        public int MessagesMatchingRulePatchRules(string[] input)
        {

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("8:"))
                {
                    input[i] = "8: 42 | 42 8";
                }

                if (input[i].StartsWith("11:"))
                {
                    input[i] = "11: 42 31 | 42 11 31";
                }
            }

            var rules = CompileRules(input);

            var targetRule = rules["0"];
            var validRegex = new Regex($"^{targetRule}$");
            Console.WriteLine(validRegex);
            return input.Count(x => validRegex.IsMatch(x));
        }
    }
}