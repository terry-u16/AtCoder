using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200902.Algorithms;
using Training20200902.Collections;
using Training20200902.Extensions;
using Training20200902.Numerics;
using Training20200902.Questions;

namespace Training20200902.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc040/tasks/agc040_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var a = new long[s.Length + 1];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '<')
                {
                    a[i + 1] = a[i] + 1;
                }
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '>')
                {
                    a[i] = Math.Max(a[i], a[i + 1] + 1);
                }
            }

            yield return a.Sum();
        }
    }
}
