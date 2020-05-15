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
    /// ABC107 B
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];

            var grid = new List<List<char>>();
            for (int row = 0; row < h; row++)
            {
                grid.Add(inputStream.ReadLine().ToList());
            }

            for (int row = grid.Count - 1; row >= 0; row--)
            {
                if (grid[row].All(c => c == '.'))
                {
                    grid.RemoveAt(row);
                }
            }

            for (int column = grid[0].Count - 1; column >= 0; column--)
            {
                if (grid.All(row => row[column] == '.'))
                {
                    foreach (var row in grid)
                    {
                        row.RemoveAt(column);
                    }
                }
            }

            foreach (var row in grid)
            {
                yield return string.Concat(row);
            }
        }
    }
}
