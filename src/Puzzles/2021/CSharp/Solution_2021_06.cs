using AdventOfCode.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public class Solution_2021_06 : CSharpSolution
    {
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            List<int> startingFish = new List<int>(Array.ConvertAll(input.GetRaw().Split(","), s => int.Parse(s)));

            Dictionary<int,long> fish = new Dictionary<int, long>()
            {
                {0,0},
                {1,0},
                {2,0},
                {3,0},
                {4,0},
                {5,0},
                {6,0},
                {7,0},
                {8,0},
                {9,0}
            };

            foreach (int f in startingFish)
            {
                fish[f]++;
            }

            int day = 0;

            while (day < 80)
            {
                //Every fish at 0 gives birth
                fish[9] = fish[0];
                for (int i = 0; i < 9; i++)
                {
                    //Everyone decays 1
                    fish[i] = fish[i+1];
                }
                // Add all the fish that gave birth to 6
                fish[6] += fish[9];
                fish[9] = 0;

                day++;
            }

            long ans1 = 0;
            foreach(KeyValuePair<int,long> f in fish)
            {
                ans1 += f.Value;
            }

            while (day < 256)
            {
                //Every fish at 0 gives birth
                fish[9] = fish[0];
                for (int i = 0; i < 9; i++)
                {
                    //Everyone decays 1
                    fish[i] = fish[i+1];
                }
                // Add all the fish that gave birth to 6
                fish[6] += fish[9];
                fish[9] = 0;
                
                day++;
            }

            long ans2 = 0;
            foreach(KeyValuePair<int,long> f in fish)
            {
                ans2 += f.Value;
            }

            SubmitPartOne(ans1);
            SubmitPartTwo(ans2);
        }
    }
}