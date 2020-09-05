using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu083.Algorithms;
using Kujikatsu083.Collections;
using Kujikatsu083.Extensions;
using Kujikatsu083.Numerics;
using Kujikatsu083.Questions;

namespace Kujikatsu083.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/aising2019/tasks/aising2019_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var isBlack = new bool[height, width];

            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();
                for (int column = 0; column < width; column++)
                {
                    isBlack[row, column] = s[column] == '#';
                }
            }

            var seen = new bool[height, width];
            var diffs = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            (long blacks, long whites) Dfs(int row, int column)
            {
                var blacks = isBlack[row, column] ? 1L : 0L;
                var whites = isBlack[row, column] ? 0L : 1L;
                seen[row, column] = true;
                foreach (var (dr, dc) in diffs)
                {
                    var nextRow = row + dr;
                    var nextColumn = column + dc;
                    if (unchecked((uint)nextRow < height && (uint)nextColumn < width) 
                        && !seen[nextRow, nextColumn] 
                        && (isBlack[row, column] ^ isBlack[nextRow, nextColumn]))
                    {
                        var (b, w) = Dfs(nextRow, nextColumn);
                        blacks += b;
                        whites += w;
                    }
                }
                return (blacks, whites);
            }

            var result = 0L;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (!seen[row, column])
                    {
                        var (b, w) = Dfs(row, column);
                        result += b * w;
                    }
                }
            }

            yield return result;
        }
    }
}
