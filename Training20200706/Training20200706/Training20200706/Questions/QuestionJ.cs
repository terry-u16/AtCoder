using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/gigacode-2019/tasks/gigacode_2019_d
    /// </summary>
    public class QuestionJ : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k, money) = inputStream.ReadValue<int, int, long, long>();
            var prices = new long[height + 1, width + 1];

            for (int row = 0; row < height; row++)
            {
                var a = inputStream.ReadLongArray();
                for (int column = 0; column < width; column++)
                {
                    prices[row + 1, column + 1] = a[column] + k;
                }
            }

            for (int row = 0; row + 1 < height + 1; row++)
            {
                for (int column = 0; column < width + 1; column++)
                {
                    prices[row + 1, column] += prices[row, column];
                }
            }

            for (int column = 0; column + 1 < width + 1; column++)
            {
                for (int row = 0; row < height + 1; row++)
                {
                    prices[row, column + 1] += prices[row, column];
                }
            }

            int maxArea = 0;
            for (int h = 1; h <= height; h++)
            {
                for (int w = 1; w <= width; w++)
                {
                    for (int row = 0; row + h <= height; row++)
                    {
                        var endRow = row + h;
                        for (int column = 0; column + w <= width; column++)
                        {
                            var endColumn = column + w;
                            var price = prices[endRow, endColumn] - prices[endRow, column] - prices[row, endColumn] + prices[row, column];
                            if (price <= money)
                            {
                                maxArea = Math.Max(maxArea, h * w);
                            }
                        }
                    }
                }
            }

            yield return maxArea;
        }
    }
}
