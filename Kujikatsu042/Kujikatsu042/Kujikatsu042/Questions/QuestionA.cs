using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu042.Algorithms;
using Kujikatsu042.Collections;
using Kujikatsu042.Extensions;
using Kujikatsu042.Numerics;
using Kujikatsu042.Questions;

namespace Kujikatsu042.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc048/tasks/abc048_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadStringArray();
            yield return s.Select(si => si[0]).Join();
        }
    }
}
