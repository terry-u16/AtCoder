using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu063.Algorithms;
using Kujikatsu063.Collections;
using Kujikatsu063.Extensions;
using Kujikatsu063.Numerics;
using Kujikatsu063.Questions;

namespace Kujikatsu063.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc145/tasks/abc145_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            if (s.Length % 2 == 0 && s.Substring(0, s.Length / 2) == s.Substring(s.Length / 2, s.Length / 2))
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
