using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu024.Algorithms;
using Kujikatsu024.Collections;
using Kujikatsu024.Extensions;
using Kujikatsu024.Numerics;
using Kujikatsu024.Questions;

namespace Kujikatsu024.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc018/tasks/agc018_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            var max = a.Max();

            long gcd = a[0];
            foreach (var ai in a)
            {
                gcd = NumericalAlgorithms.Gcd(gcd, ai);
            }

            yield return max >= k && k % gcd == 0 ? "POSSIBLE" : "IMPOSSIBLE";
        }
    }
}
