using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu021.Algorithms;
using Kujikatsu021.Collections;
using Kujikatsu021.Extensions;
using Kujikatsu021.Numerics;
using Kujikatsu021.Questions;

namespace Kujikatsu021.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/exawizards2019/tasks/exawizards2019_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var reds = s.Count(c => c == 'R');
            var blues = s.Count(c => c == 'B');

            yield return reds > blues ? "Yes" : "No";
        }
    }
}
