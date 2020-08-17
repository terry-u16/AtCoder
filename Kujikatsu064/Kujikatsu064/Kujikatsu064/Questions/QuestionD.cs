using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu064.Algorithms;
using Kujikatsu064.Collections;
using Kujikatsu064.Extensions;
using Kujikatsu064.Numerics;
using Kujikatsu064.Questions;

namespace Kujikatsu064.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc091/tasks/arc091_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();

            long result = 0;

            for (int b = 1; b <= n; b++)
            {
                if (k > 0)
                {
                    var modCount = b - k;
                    if (modCount > 0)
                    {
                        result += modCount * (n / b);
                        var mod = n % b;
                        var remain = n % b - k + 1;
                        if (remain > 0)
                        {
                            result += remain;
                        }
                    }
                }
                else
                {
                    result += n;
                }
            }

            yield return result;
        }
    }
}
