using AdventOfCode.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public class Solution_2021_08 : CSharpSolution
    {
        public static readonly List<int> easySegs = new List<int>(){1,4,7,8};
        public static readonly int[] decodeOrder = {1,4,7,8,9,0,6,3,5,2};
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!

            Dictionary<int,string> numbers;
            int displayDigits;
            int sum = 0;
            int count1478 = 0;

            foreach (string line in input.GetLines())
            {
                string[] note = line.Split("|");
                numbers = decodeDigits(note[0]);
                displayDigits = 0;
                foreach (string str in note[1].Split(" ", StringSplitOptions.RemoveEmptyEntries))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (SegmentIs(str,numbers[i]))
                        {
                            count1478 += easySegs.Contains(i)? 1: 0;
                            displayDigits = displayDigits*10 + i;
                        }
                    }
                }
                sum += displayDigits;
            }

            SubmitPartOne(count1478);
            SubmitPartTwo(sum);
        }

        public Dictionary<int,string> decodeDigits(string line)
        {
            Dictionary<int, string> decoder = new Dictionary<int, string>();
            List<string> digits = new List<string>(line.Split(" ",StringSplitOptions.RemoveEmptyEntries));

            int i;
            for (int pos = 0; pos < decodeOrder.Length; pos++)
            {
                i = 0;
                while(i < digits.Count)
                {
                    switch(decodeOrder[pos])
                    {
                        case 0:
                            if (digits[i].Length == 6 && SegmentContains(digits[i], decoder[1] , 0))
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 1:
                            if (digits[i].Length == 2)
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 2:
                            if (digits[i].Length == 5)
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 3:
                            if (digits[i].Length == 5 && SegmentContains(digits[i], decoder[1], 0))
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 4:
                            if (digits[i].Length == 4)
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 5:
                            if (digits[i].Length == 5 && SegmentContains(digits[i], decoder[6] , 1))
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 6:
                            if (digits[i].Length == 6)
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 7:
                            if (digits[i].Length == 3)
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 8:
                            if (digits[i].Length == 7)
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                        case 9:
                            if (digits[i].Length == 6 && SegmentContains(digits[i], decoder[4], 0))
                            {
                                decoder.Add(decodeOrder[pos], digits[i]);
                                digits.Remove(digits[i]);
                            }
                        break;
                    }
                    i++;
                }
            }

            return decoder;
        }

        public bool SegmentContains(string seg, string decoded, int acceptableMisses)
        {
            bool match = true;
            int c = 0;
            char[] segs = decoded.ToCharArray();
            while (c<segs.Length && match)
            {
                if (!seg.Contains(segs[c]))
                {
                    if (acceptableMisses > 0)
                        acceptableMisses--;
                    else
                        match = false;
                }
                c++;
            }
            return match;
        }

        public bool SegmentIs(string seg, string decoded)
        {
            bool match = (seg.Length == decoded.Length);
            int c = 0;
            char[] segs = decoded.ToCharArray();
            while (c<segs.Length && match)
            {
                if (!seg.Contains(segs[c]))
                {
                    match = false;
                }
                c++;
            }
            return match;
        }
    }
}