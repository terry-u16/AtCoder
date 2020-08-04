using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu051.Algorithms;
using Kujikatsu051.Collections;
using Kujikatsu051.Extensions;
using Kujikatsu051.Numerics;
using Kujikatsu051.Questions;

namespace Kujikatsu051.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc032/tasks/agc032_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var edges = new bool[n, n];

            if (n == 3)
            {
                yield return "2";
                yield return "1 3";
                yield return "2 3";
                yield break;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        edges[i, j] = true;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                edges[i, n - i - 1] = false;
            }

            if (n % 2 == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    edges[i, n / 2] = false;
                    edges[i, n / 2] = false;
                }
            }
        }
    }
}
