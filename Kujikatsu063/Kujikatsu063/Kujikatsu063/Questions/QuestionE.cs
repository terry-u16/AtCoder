using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu063.Algorithms;
using Kujikatsu063.Collections;
using Kujikatsu063.Extensions;
using Kujikatsu063.Numerics;
using Kujikatsu063.Questions;

namespace Kujikatsu063.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var maxPairs = (n - 1) * (n - 2) / 2;

            if (k > maxPairs)
            {
                yield return -1;
            }
            else
            {
                var over = maxPairs - k;
                var results = new List<Edge>();

                for (int i = 2; i <= n; i++)
                {
                    results.Add(new Edge(1, i));
                }

                var added = 0;
                for (int from = 2; from <= n; from++)
                {
                    for (int to = from + 1; to <= n; to++)
                    {
                        if (added++ < over)
                        {
                            results.Add(new Edge(from, to));
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                yield return results.Count;
                foreach (var edge in results)
                {
                    yield return $"{edge.From} {edge.To}";
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge
        {
            public int From { get; }
            public int To { get; }

            public Edge(int from, int to)
            {
                From = from;
                To = to;
            }

            public void Deconstruct(out int from, out int to) => (from, to) = (From, To);
            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }
}
