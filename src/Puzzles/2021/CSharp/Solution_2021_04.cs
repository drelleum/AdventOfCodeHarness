using AdventOfCode.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions
{
    public class Solution_2021_04 : CSharpSolution
    {
        public override void Solve(PuzzleInput input)
        {
            // Write your puzzle solution here!
            List<string> lines = input.GetLines();
            int[] drawnNumbers = Array.ConvertAll(lines[0].Split(",", StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
            int i = 2;
            List<Board> bingoBoards = new List<Board>();
            int numBoards = 0;
            while(i < lines.Count)
            {
                // Add/Create a new Board to the set
                bingoBoards.Add(new Board(5));
                //Parse lines that make up the board
                for (int j = 0; j < 5; j++)
                {
                    List<string> nums = new List<string>(lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries));

                    for (int k = 0; k < 5; k++)
                    {
                        bingoBoards[numBoards].numbers[j,k].value = int.Parse(nums[k]);
                        //Console.Write(bingoBoards[numBoards].numbers[j,k].value.ToString() + " ");
                    }
                    //Console.WriteLine();
                    i++;
                }
                
                numBoards++;
                //Console.WriteLine("Board #" + bingoBoards.Count + "\n");
                i++;
            }

            i = 0;
            
            int lastWin = -1;
            int lastNum = -1;
            int firstWin = -1;
            int firstNum = -1;
            while (i < drawnNumbers.Length)
            {
                foreach (Board currentBoard in bingoBoards)
                {
                    if (!currentBoard.won && MarkAndCheckBoard(currentBoard, drawnNumbers[i]))
                    {
                        if (firstWin == -1)
                        {
                            firstWin = bingoBoards.IndexOf(currentBoard);
                            firstNum = drawnNumbers[i];
                        }
                        lastWin = bingoBoards.IndexOf(currentBoard);
                        lastNum = drawnNumbers[i];
                        numBoards--;
                        //Console.WriteLine(numBoards.ToString() + " Board #" +  bingoBoards.IndexOf(currentBoard).ToString());
                        if (numBoards == 0) break;
                    }
                }
                //if (firstNum != -1) break;
                if (numBoards == 0) break;
                i++;
            }

            // for (int j = 0; j < 5; j++)
            // {
            //     for (int k = 0; k < 5; k++)
            //     {
            //         Console.Write(bingoBoards[firstWin].numbers[j,k].value.ToString());
            //         if (bingoBoards[firstWin].numbers[j,k].marked)
            //             Console.Write("*");
            //         Console.Write("\t");
            //     }
            //     Console.WriteLine();
            // }

            int sum1 = SumUnmarked(bingoBoards[firstWin]);
            int ans1 = sum1 * firstNum;

            int sum2 = SumUnmarked(bingoBoards[lastWin]);
            int ans2 = sum2 * lastNum;

            //Console.WriteLine(sum.ToString() + " * " + drawnNumbers[i].ToString() + " = " + ans1.ToString());

            SubmitPartOne(sum1.ToString() + " * " + firstNum.ToString() + " = " + ans1.ToString());
            SubmitPartTwo(sum2.ToString() + " * " + lastNum.ToString() + " = " + ans2.ToString());
        }

        private bool MarkAndCheckBoard(Board b, int num)
        {
            int i = 0;
            int j = 0;
            while (i < b.numbers.GetLength(0))
            {
                j = 0;
                while (j < b.numbers.GetLength(1))
                {
                    if (b.numbers[i,j].value == num)
                    {
                        b.numbers[i,j].marked = true;
                        // Check if this board just won
                        bool hor = true;
                        bool ver = true;
                        for (int k = 0; k < b.numbers.GetLength(0); k++)
                        {
                            hor = hor && b.numbers[i,k].marked;
                            ver = ver && b.numbers[k,j].marked;
                        }
                        b.won = hor || ver;
                        if (b.won) break;
                    }
                    j++;
                }
                i++;
            }
            return b.won;
        }

        private int SumUnmarked(Board b)
        {
            int sum = 0;
            foreach (Cell c in b.numbers)
            {
                sum += c.marked ? 0 : c.value;
                //Console.WriteLine(sum.ToString());
            }
            return sum;
        }
    }

    class Board
    {
        public Cell[,] numbers;
        public bool won;

        public Board(int size)
        {
            numbers = new Cell[size, size];
            won = false;
        }
    }

    struct Cell
    {
        public int value;
        public bool marked;
        public Cell(int v, bool m)
        {
            value = v;
            marked = m;
        }
    }
}