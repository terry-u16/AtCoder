using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc161/tasks/abc161_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<long, long>();
            var mod = n % k;
            yield return Math.Min(mod, k - mod);
        }
    }
}
