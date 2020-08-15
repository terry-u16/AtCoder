using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest175.Algorithms;
using AtCoderBeginnerContest175.Collections;
using AtCoderBeginnerContest175.Extensions;
using AtCoderBeginnerContest175.Numerics;
using AtCoderBeginnerContest175.Questions;

namespace AtCoderBeginnerContest175.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, itemCount) = inputStream.ReadValue<int, int, int>();
            var items = new long[height, width];
            const int MaxPick = 3;

            for (int i = 0; i < itemCount; i++)
            {
                var (r, c, v) = inputStream.ReadValue<int, int, int>();
                r--;
                c--;
                items[r, c] = v;
            }

            var dp = new long[height, width, 4];
            dp[0, 0, 1] = items[0, 0];

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (row + 1 < height)
                    {
                        for (int currentPicked = 0; currentPicked <= MaxPick; currentPicked++)
                        {
                            for (int nextPicked = 0; nextPicked <= 1; nextPicked++)
                            {
                                AlgorithmHelpers.UpdateWhenLarge(ref dp[row + 1, column, nextPicked], dp[row, column, currentPicked] + items[row + 1, column] * nextPicked);
                            }
                        }
                    }

                    if (column + 1 < width)
                    {
                        for (int currentPicked = 0; currentPicked <= MaxPick; currentPicked++)
                        {
                            AlgorithmHelpers.UpdateWhenLarge(ref dp[row, column + 1, currentPicked], dp[row, column, currentPicked]);

                            if (currentPicked < MaxPick)
                            {
                                AlgorithmHelpers.UpdateWhenLarge(ref dp[row, column + 1, currentPicked + 1], dp[row, column, currentPicked] + items[row, column + 1]);
                            }
                        }
                    }
                }
            }

            long max = 0;
            for (int picked = 0; picked <= MaxPick; picked++)
            {
                AlgorithmHelpers.UpdateWhenLarge(ref max, dp[height - 1, width - 1, picked]);
            }

            yield return max;
        }
    }
}
