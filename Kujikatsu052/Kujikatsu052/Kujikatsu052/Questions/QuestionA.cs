using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu052.Algorithms;
using Kujikatsu052.Collections;
using Kujikatsu052.Extensions;
using Kujikatsu052.Numerics;
using Kujikatsu052.Questions;

namespace Kujikatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc148/tasks/abc148_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var (s, t) = inputStream.ReadValue<string, string>();
            var result = "";

            for (int i = 0; i < s.Length; i++)
            {
                result += s[i];
                result += t[i];
            }

            yield return result;
        }
    }
}
