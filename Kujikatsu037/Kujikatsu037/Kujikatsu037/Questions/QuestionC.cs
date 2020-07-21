using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu037.Algorithms;
using Kujikatsu037.Collections;
using Kujikatsu037.Extensions;
using Kujikatsu037.Numerics;
using Kujikatsu037.Questions;

namespace Kujikatsu037.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc015/tasks/agc015_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, min, max) = inputStream.ReadValue<int, long, long>();

            if (min > max || (n == 1 && min != max))
            {
                yield return 0;
                yield break;
            }

            var minSum = (n - 1) * min + max;
            var maxSum = min + (n - 1) * max;
            yield return maxSum - minSum + 1;
        }
    }
}
