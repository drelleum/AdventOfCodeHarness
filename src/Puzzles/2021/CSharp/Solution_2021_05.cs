using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
namespace AdventOfCode.Solutions
{
    public class Solution_2021_05 : CSharpSolution
    {
        public const int X = 0;
        public const int Y = 1;
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            Dictionary<(int x, int y), int> straightVents = new Dictionary<(int x, int y), int>();
            Dictionary<(int x, int y), int> allVents = new Dictionary<(int x, int y), int>();
            List<string> lines = input.GetLines();
            foreach (string line in lines)
            {
                (List<(int x, int y)> points, bool diagonal) vents = GetVents(line);
                foreach((int x, int y) point in vents.points)
                {
                    if (!vents.diagonal)
                    {
                        if (straightVents.ContainsKey(point))
                            straightVents[point]++;
                        else
                            straightVents.Add(point, 1);
                    }
                    if (allVents.ContainsKey(point))
                        allVents[point]++;
                    else
                        allVents.Add(point, 1);
                }
                //break;
            }

            // for (int i = 0; i < 1000; i++)
            // {
            //     for (int j = 0; j < 1000; j++)
            //     {
            //         if (straightVents.ContainsKey((i,j)))
            //             Console.Write(" " + straightVents[(i,j)] + " ");
            //         else
            //             Console.Write(" . ");
            //     }
            //     Console.WriteLine();
            // }

            int ans1 = 0;
            foreach (KeyValuePair<(int x, int y), int> vent in straightVents)
            {
                //Console.WriteLine(vent.Key);
                if (vent.Value > 1)
                    ans1++;
            }

            int ans2 = 0;
            foreach (KeyValuePair<(int x, int y), int> vent in allVents)
            {
                //Console.WriteLine(vent.Key);
                if (vent.Value > 1)
                    ans2++;
            }

            SubmitPartOne(ans1.ToString());
            SubmitPartTwo(ans2.ToString());
        }

        public (List<(int x, int y)>, bool diagonal) GetVents(string line)
        {
            List<(int x, int y)> points = new List<(int x, int y)>();

            string[] corrodinates = line.Split(" -> ");
            int[] start = Array.ConvertAll(corrodinates[0].Split(","), s => int.Parse(s));
            int[] end = Array.ConvertAll(corrodinates[1].Split(","), s => int.Parse(s));

            int xDiff = end[X] - start[X];
            int yDiff = end[Y] - start[Y];

            int x = start[X];
            int y = start[Y];
            int xDir = xDiff>0? 1: xDiff==0? 0: -1;
            int yDir = yDiff>0? 1: yDiff==0? 0: -1;

            // Console.WriteLine(xDir.ToString() + " " + yDir.ToString());
            // Console.WriteLine(start[X].ToString() + " " + start[Y].ToString());
            // Console.WriteLine(end[X].ToString() + " " + end[Y].ToString());
            // Console.WriteLine(xDiff.ToString() + " " + yDiff.ToString());

            while (x != end[X] || y != end[Y])
            {
                points.Add((x,y));
                x += xDir;
                y += yDir;
                //Console.WriteLine(x.ToString() + " " + y.ToString());
            }
            points.Add((x,y));

            return (points, (xDiff != 0 && yDiff != 0));
        }
    }
}