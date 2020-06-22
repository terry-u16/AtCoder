using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu008.Algorithms;
using Kujikatsu008.Collections;
using Kujikatsu008.Extensions;
using Kujikatsu008.Numerics;
using Kujikatsu008.Questions;

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc046/tasks/abc046_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c) = inputStream.ReadValue<int, int, int>();
            var bought = new HashSet<int> { a, b, c };
            yield return bought.Count;
        }
    }
}
