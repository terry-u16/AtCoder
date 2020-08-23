using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu070.Algorithms;
using Kujikatsu070.Collections;
using Kujikatsu070.Extensions;
using Kujikatsu070.Numerics;
using Kujikatsu070.Questions;

namespace Kujikatsu070.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc171/tasks/abc171_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var prices = inputStream.ReadIntArray();

            yield return prices.OrderBy(p => p).Take(k).Sum();
        }
    }
}
