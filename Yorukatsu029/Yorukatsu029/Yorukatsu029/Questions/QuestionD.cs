using Yorukatsu029.Questions;
using Yorukatsu029.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu029.Questions
{
    /// <summary>
    /// ABC129 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var h = hw[0];
            var w = hw[1];

            var s = new char[h + 2][];
            s[0] = Enumerable.Repeat('#', w + 2).ToArray();
            s[h + 1] = Enumerable.Repeat('#', w + 2).ToArray();

            for (int i = 1; i <= h; i++)
            {
                s[i] = ("#" + inputStream.ReadLine() + "#").ToCharArray();
            }

            var light = new int[h + 2, w + 2];
            for (int row = 0; row < s.Length; row++)
            {
                var lastWall = 0;
                var streak = 0;
                for (int column = 0; column < s[row].Length; column++)
                {
                    if (s[row][column] == '.')
                    {
                        streak++;
                    }
                    else
                    {
                        for (int repeat = lastWall + 1; repeat < column; repeat++)
                        {
                            light[row, repeat] = streak;
                        }
                        lastWall = column;
                        streak = 0;
                    }
                }
            }

            for (int column = 0; column < w + 2; column++)
            {
                var lastWall = 0;
                var streak = 0;
                for (int row = 0; row < s.Length; row++)
                {
                    if (s[row][column] == '.')
                    {
                        streak++;
                    }
                    else
                    {
                        for (int repeat = lastWall + 1; repeat < row; repeat++)
                        {
                            light[repeat, column] += streak - 1;
                        }
                        lastWall = row;
                        streak = 0;
                    }
                }
            }

            var max = 0;
            for (int row = 0; row < s.Length; row++)
            {
                for (int column = 0; column < s[row].Length; column++)
                {
                    max = Math.Max(max, light[row, column]);
                }
            }

            yield return max;
        }
    }
}
