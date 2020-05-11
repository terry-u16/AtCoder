using Yorukatsu037.Questions;
using Yorukatsu037.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu037.Questions
{
    /// <summary>
    /// ARC080 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];
            var colors = inputStream.ReadInt();
            var colorsCounts = inputStream.ReadIntArray();

            var color = 0;
            var count = 0;
            var c = Enumerable.Repeat(0, h).Select(_ => new int[w]).ToArray();
            for (int row = 0; row < h; row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 0; column < w; column++)
                    {
                        c[row][column] = color + 1;
                        if (++count == colorsCounts[color])
                        {
                            color++;
                            count = 0;
                        }
                    }
                }
                else
                {
                    for (int column = w - 1; column >= 0; column--)
                    {
                        c[row][column] = color + 1;
                        if (++count == colorsCounts[color])
                        {
                            color++;
                            count = 0;
                        }
                    }
                }
            }

            foreach (var row in c)
            {
                yield return string.Join(" ", row);
            }
        }
    }
}
