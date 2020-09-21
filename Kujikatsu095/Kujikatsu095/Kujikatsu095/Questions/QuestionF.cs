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
    /// https://atcoder.jp/contests/abc048/tasks/arc064_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            if (s[0] == s[^1])
            {
                if (s.Length % 2 == 0)
                {
                    yield return "First";
                }
                else
                {
                    yield return "Second";
                }
            }
            else
            {
                var first = s.Count(c => c == s[0]);
                var last = s.Count(c => c == s[^1]);

                if (s.Length % 2 == 0)
                {
                    yield return "Second";
                }
                else
                {
                    yield return "First";
                }
            }
        }
    }
}
