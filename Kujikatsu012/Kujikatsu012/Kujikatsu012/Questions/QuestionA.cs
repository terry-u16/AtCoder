using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu012.Algorithms;
using Kujikatsu012.Collections;
using Kujikatsu012.Extensions;
using Kujikatsu012.Numerics;
using Kujikatsu012.Questions;

namespace Kujikatsu012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc142/tasks/abc142_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var h = inputStream.ReadIntArray();
            yield return h.Count(hi => hi >= k);
        }
    }
}
