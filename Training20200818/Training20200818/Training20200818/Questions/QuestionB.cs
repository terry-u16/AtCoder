using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200818.Algorithms;
using Training20200818.Collections;
using Training20200818.Extensions;
using Training20200818.Numerics;
using Training20200818.Questions;

namespace Training20200818.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc086/tasks/arc089_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var square = k * 2;
            var blacks = new int[square, square];
            var whites = new int[square, square];

            var blackCount = 0;
            var whiteCount = 0;

            for (int i = 0; i < n; i++)
            {
                var (x, y, c) = inputStream.ReadValue<int, int, char>();
                var modX = x % square;
                var modY = y % square;
                if (c == 'B')
                {
                    blacks[modY, modX] = 1;
                    blackCount++;
                }
                else
                {
                    whites[modY, modX] = 1;
                    whiteCount++;
                }
            }

            var prefixBlacks = new int[square + 1, square + 1];
            var prefixWhites = new int[square + 1, square + 1];

            for (int row = 0; row < square; row++)
            {
                for (int column = 0; column < square; column++)
                {
                    prefixBlacks[row + 1, column + 1] = blacks[row, column] + prefixBlacks[row, column + 1] + prefixBlacks[row + 1, column] - prefixBlacks[row, column];
                    prefixWhites[row + 1, column + 1] = whites[row, column] + prefixWhites[row, column + 1] + prefixWhites[row + 1, column] - prefixWhites[row, column];
                }
            }

            var max = 0;

            for (int rowShift = 0; rowShift <= k; rowShift++)
            {
                for (int columnShift = 0; columnShift <= k; columnShift++)
                {
                    var ichimatsuBlacks = Count(prefixBlacks, k, rowShift, columnShift);
                    var ichimatsuWhites = Count(prefixWhites, k, rowShift, columnShift);

                    max = Math.Max(max, ichimatsuBlacks + whiteCount - ichimatsuWhites);
                    max = Math.Max(max, ichimatsuWhites + blackCount - ichimatsuBlacks);
                }
            }

            yield return max;
        }

        int Count(int[,] prefixSum, int k, int rowShift, int columnShift)
        {
            var square = k * 2;
            var row1 = rowShift;
            var row2 = k + rowShift;
            var column1 = columnShift;
            var column2 = k + columnShift;

            var up = Count(prefixSum, row2, square, column1, column2);
            var down = Count(prefixSum, 0, row1, column1, column2);
            var left = Count(prefixSum, row1, row2, 0, column1);
            var right = Count(prefixSum, row1, row2, column2, square);

            return up + down + left + right;
        }

        int Count(int[,] prefixSum, int rowBegin, int rowEnd, int columnBegin, int columnEnd)
        {
            return prefixSum[rowEnd, columnEnd] - prefixSum[rowEnd, columnBegin] - prefixSum[rowBegin, columnEnd] + prefixSum[rowBegin, columnBegin];
        }
    }
}
