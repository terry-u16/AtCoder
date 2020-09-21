using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu095.Algorithms;
using Kujikatsu095.Collections;
using Kujikatsu095.Extensions;
using Kujikatsu095.Numerics;
using Kujikatsu095.Questions;

namespace Kujikatsu095.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc069/tasks/arc069_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (s, c) = inputStream.ReadValue<long, long>();
            var scc = Math.Min(s, c / 2);
            c -= scc * 2;

            if (c > 0)
            {
                scc += c / 4;
            }

            yield return scc;
        }
    }
}
