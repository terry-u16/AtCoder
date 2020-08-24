using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200824.Algorithms;
using Training20200824.Collections;
using Training20200824.Extensions;
using Training20200824.Numerics;
using Training20200824.Questions;

namespace Training20200824.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc011/tasks/abc011_3
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var ngs = new int[3];
            for (int i = 0; i < ngs.Length; i++)
            {
                ngs[i] = inputStream.ReadInt();
            }

            if (ngs.Any(ng => ng == n))
            {
                yield return "NO";
                yield break;
            }

            const int Inf = 1 << 28;

            var operations = Enumerable.Repeat(Inf, n + 1).ToArray();
            operations[n] = 0;
            for (int i = n; i > 0; i--)
            {
                for (int diff = 1; diff <= 3; diff++)
                {
                    if (i - diff >= 0 && !ngs.Any(ng => ng == i - diff))
                    {
                        operations[i - diff] = Math.Min(operations[i - diff], operations[i] + 1);
                    }
                }
            }

            yield return operations[0] <= 100 ? "YES" : "NO";
        }
    }
}
