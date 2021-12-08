using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions
{
    public class Solution_2021_07 : CSharpSolution
    {
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            List<int> crabPos = input.GetInts(",");
            int left = crabPos.Min();
            int right = crabPos.Max();
            int middle = (left + right) / 2;
            int ave = (int)Math.Round(crabPos.Average());
            long sum = crabPos.Sum();
            Console.WriteLine((sum - crabPos.Count())/(crabPos.Count()-1));
            Console.WriteLine(ave);
            Console.WriteLine(CalcAdvancedFuel(466, crabPos));

            long mFuel = 0;
            long lFuel = 0;
            long rFuel = 0;

            while (left != middle && right != middle)
            {
                mFuel = CalcBasicFuel(middle, crabPos);
                lFuel = CalcBasicFuel(left, crabPos);
                rFuel = CalcBasicFuel(right, crabPos);
                //Console.WriteLine(left + "=" + lFuel + "\t" + middle + "=" + mFuel + "\t" + right + "=" + rFuel);
                if (lFuel < mFuel || lFuel < rFuel)
                {
                    right = middle;
                }
                else if (rFuel < mFuel || rFuel < lFuel)
                {
                    left = middle;
                }
                middle = (left + right) / 2;
                //break;
            }

            //int minPos = lFuel < mFuel? left: rFuel < mFuel? right: middle;
            long minFuel = lFuel < mFuel? lFuel: rFuel < mFuel? rFuel: mFuel;
            
            // foreach (int pos in crabPos)
            // {
            //     Console.WriteLine(pos);
            // }

            SubmitPartOne(minFuel);

            left = crabPos.Min();
            right = crabPos.Max();
            middle = (left + right) / 2;

            while (left != middle && right != middle)
            {
                mFuel = CalcAdvancedFuel(middle, crabPos);
                lFuel = CalcAdvancedFuel(left, crabPos);
                rFuel = CalcAdvancedFuel(right, crabPos);
                //Console.WriteLine(left + "=" + lFuel + "\t" + middle + "=" + mFuel + "\t" + right + "=" + rFuel);
                if (lFuel < mFuel || lFuel < rFuel)
                {
                    right = middle;
                }
                else if (rFuel < mFuel || rFuel < lFuel)
                {
                    left = middle;
                }
                middle = (left + right) / 2;
                //break;
            }
            minFuel = lFuel < mFuel? lFuel: rFuel < mFuel? rFuel: mFuel;
            SubmitPartTwo(minFuel);
        }

        public long CalcBasicFuel(int pos, List<int> crabPos)
        {
            long fuel = 0;
            foreach (int crab in crabPos)
                fuel += crab > pos? crab - pos: pos - crab;
            return fuel;
        }
        public long CalcAdvancedFuel(int pos, List<int> crabPos)
        {
            long fuel = 0;
            int move = 0;
            foreach (int crab in crabPos)
            {
                move = crab > pos? crab - pos: pos - crab;
                fuel += (move * (move+1))/2;
            }
            return fuel;
        }
    }
}