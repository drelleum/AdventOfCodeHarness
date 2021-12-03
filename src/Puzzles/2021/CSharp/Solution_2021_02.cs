using AdventOfCode.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public class Solution_2021_02 : CSharpSolution
    {
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            int pos = 0;
            int depth = 0;
            int aim = 0;
            int amplitude = 0;
            List<string> lines = input.GetLines();
            foreach (string line in lines) {
                string[] command = line.Split(" ");
                if (command.Length != 2)
                {
                    Console.WriteLine("Err invalid command");
                    break;
                }
                amplitude = int.Parse(command[1]);
                switch (command[0])
                {
                    case ("forward"):
                    {
                        pos += amplitude;
                        depth += aim * amplitude;
                        break;
                    }
                    case ("down"):
                    {
                        aim += amplitude;
                        break;
                    }
                    case ("up"):
                    {
                        aim -= amplitude;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("command unknown");
                        break;
                    }
                }
            }

            int ans1 = aim * pos;
            int ans2 = depth * pos;

            SubmitPartOne(pos.ToString() + " by " + aim.ToString() + " = " + ans1.ToString());
            SubmitPartTwo(pos.ToString() + " by " + depth.ToString() + " = " + ans2.ToString());
        }
    }
}