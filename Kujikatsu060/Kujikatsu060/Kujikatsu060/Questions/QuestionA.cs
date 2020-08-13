using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu060.Algorithms;
using Kujikatsu060.Collections;
using Kujikatsu060.Extensions;
using Kujikatsu060.Numerics;
using Kujikatsu060.Questions;

namespace Kujikatsu060.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc147/tasks/abc147_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var count = 0;

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[^(i + 1)])
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
