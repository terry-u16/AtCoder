using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200713.Algorithms;
using Training20200713.Collections;
using Training20200713.Extensions;
using Training20200713.Numerics;
using Training20200713.Questions;

namespace Training20200713.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc008/tasks/abc008_3
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var coins = new int[n];
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i] = inputStream.ReadInt();
            }

            var divisibles = coins.Select(GetDivisiors).Select(d => coins.Count(c => d.Contains(c)) - 1).ToArray();

            double expected = 0;
            foreach (var divisible in divisibles)
            {
                expected += (1.0 + divisible / 2) / (1.0 + divisible);
            }

            yield return expected;
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i * i != n)
                    {
                        yield return n / i;
                    }
                }
            }
        }
    }
}
