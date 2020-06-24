using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu010.Algorithms;
using Kujikatsu010.Collections;
using Kujikatsu010.Extensions;
using Kujikatsu010.Numerics;
using Kujikatsu010.Questions;

namespace Kujikatsu010.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc091/tasks/arc091_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<long, long>();

            if (n > m)
            {
                var temp = m;
                m = n;
                n = temp;
            }

            if (n == 1)
            {
                if (m == 1)
                {
                    yield return 1;
                }
                else
                {
                    yield return m - 2;
                }
            }
            else
            {
                yield return (n - 2) * (m - 2);
            }
        }
    }
}
