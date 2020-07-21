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
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b) = inputStream.ReadValue<int, int, int>();
            var v = inputStream.ReadLongArray();
            Array.Sort(v);
            Array.Reverse(v);

            var average = v.Take(a).Average();
            var last = v[a - 1];
            var lastCount = v.Count(vi => vi == last);
            var overCount = v.Count(vi => vi > last);

            long total = NumericalAlgorithms.Combination(lastCount, a - overCount);

            if (v[0] == last)
            {
                for (int take = a + 1; take <= Math.Min(overCount + lastCount, b); take++)
                {
                    total += NumericalAlgorithms.Combination(lastCount, take - overCount);
                }
            }

            yield return average;
            yield return total;
        }
    }
}
