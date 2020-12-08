using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day08
    {
        public int Accumulator { get; set; }
        
        public bool RunProgramUntilLoopStarts(string[] input)
        {
            var processed = new HashSet<int>();

            for (var i = 0; i < input.Length;)
            {
                if (processed.Contains(i))
                {
                    return false;
                }
                processed.Add(i);

                i += ProcessInstruction(input[i]);
            }

            return true;
        }

        public int ProcessInstruction(string command)
        {
            var split = command.Split(" ");
            var (instruction, value) = (split[0], Convert.ToInt32(split[1]));

            switch (instruction)
            {
                case "nop":
                    return 1;
                case "jmp":
                    return value;
                case "acc":
                    Accumulator += value;
                    return 1;
            }

            return 0;
        }

        public int AlterProgramToCorrectLoop(string[] input)
        {
            var programs = GeneratePrograms(input);
            
            foreach (var program in programs)
            {
                Accumulator = 0;
                var result = RunProgramUntilLoopStarts(program);
                if (result)
                {
                    return Accumulator;
                }
            }

            return -1;
        }


        //change one nop to jmp, or one jmp to nop
        public IEnumerable<string[]> GeneratePrograms(string[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var instruction = input[i];
                var result = (string[]) input.Clone();
                
                if (instruction.StartsWith("nop"))
                {
                    result[i] = instruction.Replace("nop", "jmp");
                    yield return result.ToArray();
                }
                else if (instruction.StartsWith("jmp"))
                {
                    result[i] = instruction.Replace("jmp", "nop");
                    yield return result.ToArray();
                }
            }
        }
    }
}