using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc137/tasks/abc137_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (k, x) = inputStream.ReadValue<int, int>();

            var results = new List<int>();

            for (int i = x - k + 1; i <= x + k - 1; i++)
            {
                results.Add(i);
            }

            yield return results.Join(' ');
        }
    }
}
