using Yorukatsu043.Questions;
using Yorukatsu043.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu043.Questions
{
    /// <summary>
    /// ABC147 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];

            var a = new int[h][];
            var b = new int[h][];

            for (int i = 0; i < h; i++)
            {
                a[i] = inputStream.ReadIntArray();
            }
            for (int i = 0; i < h; i++)
            {
                b[i] = inputStream.ReadIntArray();
            }

            var enable = new bool[h, w, 80 * (h + w) + 1];
            enable[0, 0, Math.Abs(a[0][0] - b[0][0])] = true;

            for (int row = 0; row < h; row++)
            {
                for (int column = 0; column < w; column++)
                {
                    for (int unbalance = 0; unbalance <= 80 * (h + w); unbalance++)
                    {
                        if (enable[row, column, unbalance])
                        {
                            if (row + 1 < h)
                            {
                                var diff = a[row + 1][column] - b[row + 1][column];
                                enable[row + 1, column, Math.Abs(unbalance + diff)] = true;
                                enable[row + 1, column, Math.Abs(unbalance - diff)] = true;
                            }

                            if (column + 1 < w)
                            {
                                var diff = a[row][column + 1] - b[row][column + 1];
                                enable[row, column + 1, Math.Abs(unbalance + diff)] = true;
                                enable[row, column + 1, Math.Abs(unbalance - diff)] = true;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 80 * (h + w) + 1; i++)
            {
                if (enable[h - 1, w - 1, i])
                {
                    yield return i;
                    yield break;
                }
            }
        }
    }
}
