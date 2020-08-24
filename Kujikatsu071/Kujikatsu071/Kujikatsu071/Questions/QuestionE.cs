using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu071.Algorithms;
using Kujikatsu071.Collections;
using Kujikatsu071.Extensions;
using Kujikatsu071.Numerics;
using Kujikatsu071.Questions;

namespace Kujikatsu071.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);
            var result = Modular.Zero;

            for (int i = 0; i <= n - k; i++)
            {
                result -= a[i] * Modular.Combination(n - i - 1, k - 1);
            }

            for (int i = k - 1; i < a.Length; i++)
            {
                result += a[i] * Modular.Combination(i, k - 1);
            }

            yield return result;
        }
    }
}
