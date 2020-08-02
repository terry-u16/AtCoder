using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu048.Algorithms;
using Kujikatsu048.Collections;
using Kujikatsu048.Extensions;
using Kujikatsu048.Numerics;
using Kujikatsu048.Questions;

namespace Kujikatsu048.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc112/tasks/abc112_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, sum) = inputStream.ReadValue<int, int>();
            var max = 1;

            foreach (var div in GetDivisiors(sum))
            {
                if ((long)div * n <= sum && div > max)
                {
                    max = div;
                }
            }

            yield return max;
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    yield return n / i;
                }
            }
        }
    }
}
