using Yorukatsu017.Questions;
using Yorukatsu017.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu017.Questions
{
    /// <summary>
    /// ABC099 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        int[][] d;
        int[][] color;
        long[][] cost;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nc = inputStream.ReadIntArray();
            var n = nc[0];
            var c = nc[1];

            d = new int[c][];
            color = new int[n][];
            cost = new long[3][];

            for (int i = 0; i < c; i++)
            {
                d[i] = inputStream.ReadIntArray();
            }

            for (int i = 0; i < n; i++)
            {
                color[i] = inputStream.ReadIntArray().Select(m => m - 1).ToArray(); // 1-indexed -> 0-indexed
            }

            for (int i = 0; i < 3; i++)
            {
                cost[i] = new long[c];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int repaintColor = 0; repaintColor < c; repaintColor++)
                    {
                        cost[(i + j) % 3][repaintColor] += d[color[i][j]][repaintColor];
                    }
                }
            }

            var min = long.MaxValue;

            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < c; k++)
                        {
                            if (i != k && j != k)
                            {

                                min = Math.Min(min, cost[0][i] + cost[1][j] + cost[2][k]);
                            }
                        }
                    }
                }
            }

            yield return min;
        }
    }
}
