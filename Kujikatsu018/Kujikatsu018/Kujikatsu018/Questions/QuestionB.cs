using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu018.Algorithms;
using Kujikatsu018.Collections;
using Kujikatsu018.Extensions;
using Kujikatsu018.Numerics;
using Kujikatsu018.Questions;

namespace Kujikatsu018.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc063/tasks/abc063_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var distinct = s.Distinct();
            yield return s.Length == distinct.Count() ? "yes" : "no";
        }
    }
}
