using Yorukatsu018.Questions;
using Yorukatsu018.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu018.Questions
{
    /// <summary>
    /// ABC107 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];
            var grid = new List<List<char>>();

            for (int i = 0; i < h; i++)
            {
                grid.Add(inputStream.ReadLine().ToList());
            }

            for (int i = grid.Count - 1; i >= 0; i--)
            {
                if (grid[i].All(c => c == '.'))
                {
                    grid.RemoveAt(i);
                }
            }

            for (int i = grid[0].Count - 1; i >= 0; i--)
            {
                bool hasBlack = false;  
                for (int j = 0; j < grid.Count; j++)
                {
                    if (grid[j][i] == '#')
                    {
                        hasBlack = true;
                        break;
                    }
                }

                if (!hasBlack)
                {
                    foreach (var row in grid)
                    {
                        row.RemoveAt(i);
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
