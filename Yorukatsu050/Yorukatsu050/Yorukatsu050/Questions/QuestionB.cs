using Yorukatsu050.Questions;
using Yorukatsu050.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc087/tasks/arc090_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var width = inputStream.ReadInt();
            var candies = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                candies[i] = inputStream.ReadIntArray();
            }

            var max = 0;
            for (int downColumn = 0; downColumn < width; downColumn++)
            {
                int count = 0;
                for (int column = 0; column < width; column++)
                {
                    if (column <= downColumn)
                    {
                        count += candies[0][column];
                    }
                    if (column >= downColumn)
                    {
                        count += candies[1][column];
                    }
                }
                max = Math.Max(max, count);
            }

            yield return max;
        }
    }
}
