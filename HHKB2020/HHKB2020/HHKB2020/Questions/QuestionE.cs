using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HHKB2020.Algorithms;
using HHKB2020.Collections;
using HHKB2020.Numerics;
using HHKB2020.Questions;

namespace HHKB2020.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var height = io.ReadInt();
            var width = io.ReadInt();

            var isTidy = new bool[height][];
            var allTidy = 0;

            for (int row = 0; row < height; row++)
            {
                isTidy[row] = io.ReadString().Select(c => c == '.').ToArray();

                for (int column = 0; column < isTidy[row].Length; column++)
                {
                    if (isTidy[row][column])
                    {
                        allTidy++;
                    }
                }
            }

            var all = Modular.Pow(2, allTidy);
            var result = all * allTidy;

            var counts = GetCounts(height, width, isTidy);

            var pows = new Dictionary<int, Modular>();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (!pows.ContainsKey(counts[row, column]))
                    {
                        pows[counts[row, column]] = Modular.Pow(2, allTidy - counts[row, column]);
                    }
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (isTidy[row][column])
                    {
                        result -= pows[counts[row, column]];
                    }
                }
            }

            io.WriteLine(result);
        }

        private static int[,] GetCounts(int height, int width, bool[][] isTidy)
        {
            var counts = new int[height, width];

            for (int row = 0; row < height; row++)
            {
                var streak = 0;

                for (int column = 0; column < width; column++)
                {
                    if (isTidy[row][column])
                    {
                        streak++;
                    }
                    else
                    {
                        streak = 0;
                    }
                    counts[row, column] += streak;
                }

                streak = 0;

                for (int column = width - 1; column >= 0; column--)
                {
                    if (isTidy[row][column])
                    {
                        streak++;
                    }
                    else
                    {
                        streak = 0;
                    }
                    counts[row, column] += streak;
                }
            }

            for (int column = 0; column < width; column++)
            {
                var streak = 0;

                for (int row = 0; row < height; row++)
                {
                    if (isTidy[row][column])
                    {
                        streak++;
                    }
                    else
                    {
                        streak = 0;
                    }
                    counts[row, column] += streak;
                }

                streak = 0;

                for (int row = height - 1; row >= 0; row--)
                {
                    if (isTidy[row][column])
                    {
                        streak++;
                    }
                    else
                    {
                        streak = 0;
                    }
                    counts[row, column] += streak;
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (isTidy[row][column])
                    {
                        counts[row, column] -= 3;
                    }
                }
            }

            return counts;
        }
    }
}
