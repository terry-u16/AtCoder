using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu085.Algorithms;
using Kujikatsu085.Collections;
using Kujikatsu085.Extensions;
using Kujikatsu085.Numerics;
using Kujikatsu085.Questions;

namespace Kujikatsu085.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc076/tasks/abc076_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var k = inputStream.ReadInt();

            var current = 1;
            for (int i = 0; i < n; i++)
            {
                current = Math.Min(current * 2, current + k);
            }

            yield return current;
        }
    }
}
