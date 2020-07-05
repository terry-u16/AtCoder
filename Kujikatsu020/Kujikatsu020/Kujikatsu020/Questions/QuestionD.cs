using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu020.Algorithms;
using Kujikatsu020.Collections;
using Kujikatsu020.Extensions;
using Kujikatsu020.Numerics;
using Kujikatsu020.Questions;

namespace Kujikatsu020.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc064/tasks/abc064_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var min = 0;
            var current = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    current++;
                }
                else
                {
                    current--;
                }

                min = Math.Min(min, current);
            }

            yield return string.Concat(Enumerable.Repeat('(', -min).Concat(s).Concat(Enumerable.Repeat(')', current - min)));
        }
    }
}
