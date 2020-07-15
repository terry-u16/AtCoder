using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200715.Algorithms;
using Training20200715.Collections;
using Training20200715.Extensions;
using Training20200715.Numerics;
using Training20200715.Questions;

namespace Training20200715.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc114/tasks/abc114_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var min = int.MaxValue;
            for (int i = 0; i + 2 < s.Length; i++)
            {
                min = Math.Min(min, GetAbs(s.AsSpan(i, 3)));
            }

            yield return min;
        }

        int GetAbs(ReadOnlySpan<char> s)
        {
            var n = int.Parse(s);
            return Math.Abs(n - 753);
        }
    }
}
