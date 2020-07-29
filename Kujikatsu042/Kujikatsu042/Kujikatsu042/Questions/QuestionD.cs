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
    /// https://atcoder.jp/contests/abc064/tasks/abc064_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadLine();
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
                    min = Math.Min(min, current);
                }
            }

            var last = current - min;
            yield return Enumerable.Repeat('(', -min).Concat(s).Concat(Enumerable.Repeat(')', last)).Join();
        }
    }
}
