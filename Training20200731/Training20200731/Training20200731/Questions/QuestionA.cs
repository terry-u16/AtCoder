using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200731.Algorithms;
using Training20200731.Collections;
using Training20200731.Extensions;
using Training20200731.Numerics;
using Training20200731.Questions;

namespace Training20200731.Questions
{
    using static AlgorithmHelpers;

    /// <summary>
    /// https://atcoder.jp/contests/arc085/tasks/arc085_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, xInit, yInit) = inputStream.ReadValue<int, int, int>();
            var a = inputStream.ReadIntArray();
            const long Inf = 1L << 60;

            var abs = new long[n + 1, 2];

            for (int i = 0; i < n + 1; i++)
            {
                abs[i, 0] = -Inf;
                abs[i, 1] = Inf;
            }

            for (int i = n; i >= 0; i--)
            {
                // 先手
                var y = i > 0 ? a[i - 1] : yInit;
                UpdateWhenLarge(ref abs[i, 0], Math.Abs(y - a[^1]));
                for (int j = i + 1; j < a.Length; j++)
                {
                    UpdateWhenLarge(ref abs[i, 0], abs[j, 1]);
                }

                // 後手
                var x = i > 0 ? a[i - 1] : xInit;
                UpdateWhenSmall(ref abs[i, 1], Math.Abs(x - a[^1]));
                for (int j = i + 1; j < a.Length; j++)
                {
                    UpdateWhenSmall(ref abs[i, 1], abs[j, 0]);
                }
            }

            yield return abs[0, 0];
        }
    }
}
