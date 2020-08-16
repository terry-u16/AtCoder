using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;
using Training20200727.Graphs;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_r
    /// </summary>
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, length) = inputStream.ReadValue<int, long>();

            var counts = new Modular[60, n];
            var nexts = new List<int>[60, n];

            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadIntArray();
                var currentNexts = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if (a[j] == 1)
                    {
                        currentNexts.Add(j);
                    }
                }
                nexts[0, i] = currentNexts;
                counts[0, i] = currentNexts.Count;
            }

            for (int pow = 1; pow < 60; pow++)
            {
                for (int start = 0; start < n; start++)
                {
                    var currentNexts = nexts[pow - 1, start];
                    var doubleNexts = Enumerable.Empty<int>();
                    var c = Modular.Zero;

                    foreach (var next in currentNexts)
                    {
                        c += counts[pow - 1, next];
                        doubleNexts = doubleNexts.Concat(nexts[pow - 1, next]);
                    }

                    counts[pow, start] = counts[pow - 1, start] * c;
                    nexts[pow, start] = doubleNexts.Distinct().ToList();
                }
            }

            var result = Modular.Zero;
            for (int start = 0; start < n; start++)
            {
                var c = Modular.One;
                for (int pow = 0; pow < 60; pow++)
                {
                    if (((1L << pow) & length) > 0)
                    {
                        c *= counts[pow, start];
                    }
                }
                result += c;
            }

            yield return result;
        }
    }
}
