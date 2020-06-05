using Yorukatsu057.Questions;
using Yorukatsu057.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc088/tasks/abc088_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var grid = new int[3][];

            for (int row = 0; row < grid.Length; row++)
            {
                grid[row] = inputStream.ReadIntArray();
            }

            yield return Check(grid) ? "Yes" : "No";
        }

        bool Check(int[][] grid)
        {
            for (int row = 0; row + 1 < 3; row++)
            {
                var diff = Enumerable.Range(0, 3).Select(column => grid[row + 1][column] - grid[row][column]).ToArray();

                if (!diff.All(d => d == diff[0]))
                {
                    return false;
                }
            }

            for (int column = 0; column + 1 < 3; column++)
            {
                var diff = Enumerable.Range(0, 3).Select(row => grid[row][column + 1] - grid[row][column]).ToArray();

                if (!diff.All(d => d == diff[0]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
