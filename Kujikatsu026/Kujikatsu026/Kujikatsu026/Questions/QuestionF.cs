using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu026.Algorithms;
using Kujikatsu026.Collections;
using Kujikatsu026.Extensions;
using Kujikatsu026.Numerics;
using Kujikatsu026.Questions;

namespace Kujikatsu026.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc088/tasks/arc088_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var diff = new bool[s.Length - 1];
            for (int i = 0; i + 1 < s.Length; i++)
            {
                if (s[i] != s[i + 1])
                {
                    diff[i] = true;
                }
            }

            var fromLeft = s.Length;
            for (int i = diff.Length / 2; i < diff.Length; i++)
            {
                if (diff[i])
                {
                    fromLeft = i + 1;
                    break;
                }
            }

            var fromRight = s.Length;
            for (int i = diff.Length / 2; i < diff.Length; i++)
            {
                if (diff[^(i + 1)])
                {
                    fromRight = i + 1;
                    break;
                }
            }

            yield return Math.Min(fromLeft, fromRight);
        }
    }
}
