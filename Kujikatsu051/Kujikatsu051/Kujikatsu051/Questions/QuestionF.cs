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
    /// https://atcoder.jp/contests/agc025/tasks/agc025_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 998244353;
            Modular.InitializeCombinationTable();
            var (n, a, b, k) = inputStream.ReadValue<int, int, int, long>();
            var count = Modular.Zero;

            for (int x = 0; x <= n; x++)
            {
                var remain = k - (long)a * x;
                if (remain >= 0 && remain % b == 0)
                {
                    var y = remain / b;
                    if (y <= n)
                    {
                        count += Modular.Combination(n, x) * Modular.Combination(n, (int)y);
                    }
                }
            }

            yield return count;
        }
    }
}
