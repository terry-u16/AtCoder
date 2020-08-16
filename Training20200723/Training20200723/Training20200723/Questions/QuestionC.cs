using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;
using System.Numerics;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc030/tasks/abc030_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (wordCount, first) = inputStream.ReadValue<int, int>();
            first--;
            var totalSteps = BigInteger.Parse(inputStream.ReadLine());
            var redirects = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var firstVisited = Enumerable.Repeat(-1, wordCount).ToArray();
            var visited = new List<int>();
            var next = first;

            var steps = 0;
            while (firstVisited[next] == -1)
            {
                visited.Add(next);
                firstVisited[next] = steps++;
                next = redirects[next];
            }

            if (totalSteps <= firstVisited[next])
            {
                yield return visited[(int)totalSteps] + 1;
            }
            else
            {
                totalSteps -= firstVisited[next];
                var loop = steps - firstVisited[next];
                yield return visited[(int)(totalSteps % loop) + firstVisited[next]] + 1;
            }
        }
    }
}
