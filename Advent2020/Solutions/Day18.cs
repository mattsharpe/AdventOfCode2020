using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    class Day18
    {

        public long EvaluateEquation(string equation, bool additionHasPriority = false)
        {
            var solver = additionHasPriority ? (Func<string, long>) AdditionPriority : SameOperatorPrecedence;

            while (true)
            {
                var brackets = new Regex(@"\(([\d+* ]*)\)");
                if (!brackets.IsMatch(equation)) return solver(equation);

                foreach (Match match in brackets.Matches(equation))
                {
                    var subPart = EvaluateEquation(match.Groups[1].Value, additionHasPriority);
                    equation = equation.Replace(match.Value, subPart.ToString());
                }
            }
        }

        public long SumAllEquations(string[] input, bool additionHasPrecedence = false)
        {
            return input.Select(x=> EvaluateEquation(x, additionHasPrecedence)).Sum();
        }

        private long AdditionPriority(string input)
        {
            //process all additions then multiply to results
            while (input.Contains("+"))
            {
                var sum = Regex.Match(input, @"(\d+) \+ (\d+)");
                var a = Convert.ToInt64(sum.Groups[1].Value);
                var b = Convert.ToInt64(sum.Groups[2].Value);
                input = new Regex(@"\d+ \+ \d+").Replace(input, $"{a + b}", 1);
            }
            return input.Split("*")
                .Select(long.Parse)
                .Aggregate(1L, (a, b) => a * b);
        }

        private long SameOperatorPrecedence(string input)
        {
            var split = input.Split(' ');
            var result = long.Parse(split[0]);
            var operation = "+";

            foreach (var instruction in split.Skip(1))
            {
                if (instruction == "+" || instruction == "*")
                {
                    operation = instruction;
                }
                else
                {
                    var value = long.Parse(instruction);
                    result = operation == "+" ? result + value : result * value;
                }
            }
            return result;
        }

        
    }
}
