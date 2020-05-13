using Yorukatsu038.Questions;
using Yorukatsu038.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu038.Questions
{
    /// <summary>
    /// ABC096 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];

            var canvas = new char[h][];
            for (int i = 0; i < h; i++)
            {
                canvas[i] = inputStream.ReadLine().ToCharArray();
            }

            for (int row = 0; row < h; row++)
            {
                for (int column = 0; column < w; column++)
                {
                    if (canvas[row][column] == '#')
                    {
                        var isOk = (row > 0 && canvas[row - 1][column] == '#') ||
                            (row < h - 1 && canvas[row + 1][column] == '#') ||
                            (column > 0 && canvas[row][column - 1] == '#') ||
                            (column < w - 1 && canvas[row][column + 1] == '#');
                        if (!isOk)
                        {
                            yield return "No";
                            yield break;
                        }
                    }
                }
            }

            yield return "Yes";
        }
    }
}
