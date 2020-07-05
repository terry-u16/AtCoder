using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu020.Algorithms;
using Kujikatsu020.Collections;
using Kujikatsu020.Extensions;
using Kujikatsu020.Numerics;
using Kujikatsu020.Questions;

namespace Kujikatsu020.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc002/tasks/agc002_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (boxCount, operationCount) = inputStream.ReadValue<int, int>();
            var balls = Enumerable.Repeat(1, boxCount).ToArray();
            var mayHasRedBall = new bool[boxCount];
            mayHasRedBall[0] = true;

            for (int op = 0; op < operationCount; op++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;

                if (mayHasRedBall[from])
                {
                    mayHasRedBall[to] = true;
                    if (balls[from] == 1)
                    {
                        mayHasRedBall[from] = false;
                    }
                }

                balls[from]--;
                balls[to]++;
            }

            yield return mayHasRedBall.Count(b => b);
        }
    }
}
