using AdventOfCode.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public class Solution_2021_03 : CSharpSolution
    {
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            List<string> lines = input.GetLines();

            int numDigits = lines[0].Length;
            
            int[] num_ones = new int[numDigits];
            int num_lines = 0;
            char[] gamma = new char[numDigits];
            char[] epsilon = new char[numDigits];
            int i = 0;
            foreach (string line in lines)
            {
                char[] diagnostic = line.ToCharArray();
                for (i = 0; i < numDigits; i++)
                {
                    num_ones[i] += int.Parse(diagnostic[i].ToString());
                }
                num_lines++;
            }

            for (i = 0; i < num_ones.Length; i++)
            {
                if (num_ones[i] > (num_lines / 2.0))
                {
                    gamma[i] = '1';
                    epsilon[i] = '0';
                }
                else
                {
                    gamma[i] = '0';
                    epsilon[i] = '1';
                }
            } 

            int gamma_int = Convert.ToInt32(string.Concat(gamma),2);
            int epsilon_int = Convert.ToInt32(string.Concat(epsilon),2);
            int ans1 = gamma_int * epsilon_int;

            SubmitPartOne(gamma_int.ToString() + " * " + epsilon_int.ToString() + " = " + ans1.ToString());

            List<string> oxygen = input.GetLines();
            i = 0;
            while (i < numDigits)
            {
                int com = GetMostCommon(i, oxygen);
                Console.WriteLine(com);
                for (int pos = oxygen.Count - 1; pos >= 0; pos--)
                {
                    if (int.Parse(oxygen[pos].Substring(i,1)) != com)
                    {
                        oxygen.RemoveAt(pos);
                    }
                }
                if (1 == oxygen.Count) break;
                i++;
            }

            Console.WriteLine(oxygen[0]);

            List<string> co2 = input.GetLines();
            i = 0;
            while (i < numDigits)
            {
                int com = 1 - GetMostCommon(i, co2);
                Console.WriteLine(com);
                for (int pos = co2.Count - 1; pos >= 0; pos--)
                {
                    if (int.Parse(co2[pos].Substring(i,1)) != com)
                    {
                        co2.RemoveAt(pos);
                    }
                }
                if (1 == co2.Count) break;
                i++;
            }

            Console.WriteLine(co2[0]);

            int oxy_int = Convert.ToInt32(oxygen[0],2);
            int co2_int = Convert.ToInt32(co2[0],2);

            int ans2 = oxy_int * co2_int;
            SubmitPartTwo(ans2.ToString());
        }

        public int GetMostCommon(int pos, List<string> lines)
        {
            int ones = 0;
            int num_lines = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    ones += int.Parse(line.Substring(pos,1));
                    num_lines++;
                }
            }
            Console.WriteLine(ones.ToString() + " / " + lines.Count.ToString());
            if (ones >= lines.Count/2.0)
                return 1;
            else
                return 0;
        }
    }
}