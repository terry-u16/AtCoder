using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu046.Algorithms;
using Kujikatsu046.Collections;
using Kujikatsu046.Extensions;
using Kujikatsu046.Numerics;
using Kujikatsu046.Questions;

namespace Kujikatsu046.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc169/tasks/abc169_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<decimal, decimal>();
            yield return (long)(a * b);
        }
    }
}
