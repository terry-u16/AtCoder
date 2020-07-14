using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu030.Algorithms;
using Kujikatsu030.Collections;
using Kujikatsu030.Extensions;
using Kujikatsu030.Numerics;
using Kujikatsu030.Questions;

namespace Kujikatsu030.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/jsc2019-qual/tasks/jsc2019_qual_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            if (s[0] == 'W' || s[^1] == 'W')
            {
                yield return 0;
                yield break;
            }

            var edges = new Edge[s.Length];

            var last = s[0];

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != last)
                {
                    edges[i] = edges[i - 1];
                }
                else
                {
                    edges[i] = edges[i - 1] == Edge.Left ? Edge.Right : Edge.Left;
                }
                last = s[i];
            }


            if (edges.Count(e => e == Edge.Left) != n)
            {
                yield return 0;
                yield break;
            }

            var count = Modular.One;
            var leftCount = 0;
            foreach (var edge in edges)
            {
                if (edge == Edge.Left)
                {
                    leftCount++;
                }
                else
                {
                    count *= leftCount--;
                }
            }

            count *= Modular.Factorial(n);
            yield return count;
        }

        enum Edge
        {
            Left,
            Right
        }
    }
}
