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
    /// https://atcoder.jp/contests/tenka1-2019-beginner/tasks/tenka1_2019_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt() - 1;
            var ch = s[k];
            yield return string.Concat(s.Select(c => c == ch ? c : '*'));
        }
    }
}
