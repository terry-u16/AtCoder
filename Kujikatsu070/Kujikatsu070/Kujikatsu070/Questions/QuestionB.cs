using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu070.Algorithms;
using Kujikatsu070.Collections;
using Kujikatsu070.Extensions;
using Kujikatsu070.Numerics;
using Kujikatsu070.Questions;

namespace Kujikatsu070.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc106/tasks/abc106_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadLong();

            for (int i = 0; i < Math.Min(k, s.Length); i++)
            {
                if (s[i] != '1')
                {
                    yield return s[i];
                    yield break;
                }
            }

            yield return 1;
        }
    }
}
