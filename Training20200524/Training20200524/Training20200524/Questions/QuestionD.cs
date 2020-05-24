using Training20200524.Questions;
using Training20200524.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200524.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/s8pc-6/tasks/s8pc_6_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var pairs = new Pair[n];
            var candidates = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0];
                var b = ab[1];
                pairs[i] = new Pair(a, b);
                candidates.Add(a);
                candidates.Add(b);
            }

            var min = long.MaxValue;
            foreach (var start in candidates)
            {
                foreach (var goal in candidates)
                {
                    var total = pairs.Sum(p => Math.Min(
                                                   Math.Abs(p.A - start) + Math.Abs(p.B - p.A) + Math.Abs(goal - p.B),
                                                   Math.Abs(p.B - start) + Math.Abs(p.B - p.A) + Math.Abs(goal - p.A)
                                                   ));
                    min = Math.Min(min, total);
                }
            }

            yield return min;
        }

        struct Pair
        {
            public long A { get; }
            public long B { get; }

            public Pair(long a, long b)
            {
                A = a;
                B = b;
            }
        }
    }
}
