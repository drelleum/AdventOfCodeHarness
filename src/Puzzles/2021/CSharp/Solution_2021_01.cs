using AdventOfCode.Utils;
using System;
using System.Text;
using System.Collections.Generic;


namespace AdventOfCode.Solutions
{
    public class Solution_2021_01 : CSharpSolution
    {
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            List<int> depths = input.GetInts("\n");
            int prevDepth = int.MaxValue;
            int count = 0;
            foreach (int depth in depths) {
                if (depth > prevDepth) {
                    count++;
                }
                prevDepth = depth;
            }

            SubmitPartOne(count.ToString());
            
            count = -3;
            int i = 0;
            int[] rollingDepth = new int[3];
            foreach (int depth in depths) {
                if (count < 0) {
                    count++;
                }
                else if (depth > rollingDepth[i]) {
                    count++;    
                }
                rollingDepth[i] = depth;
                i = (i + 1) % 3;
            }
            
            SubmitPartTwo(count.ToString());
        }
    }
}