using Yorukatsu040.Questions;
using Yorukatsu040.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu040.Questions
{
    /// <summary>
    /// ABC088 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var grid = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                grid[i] = inputStream.ReadIntArray();
            }

            var valid = true;
            for (int row = 0; row < 2; row++)
            {
                var diff = new int[3];
                for (int column = 0; column < 3; column++)
                {
                    diff[column] = grid[row + 1][column] - grid[row][column];
                }
                valid &= diff[0] == diff[1];
                valid &= diff[1] == diff[2];
            }

            for (int column = 0; column < 2; column++)
            {
                var diff = new int[3];
                for (int row = 0; row < 3; row++)
                {
                    diff[row] = grid[row][column + 1] - grid[row][column];
                }
                valid &= diff[0] == diff[1];
                valid &= diff[1] == diff[2];
            }

            yield return valid ? "Yes" : "No";
        }
    }
}
