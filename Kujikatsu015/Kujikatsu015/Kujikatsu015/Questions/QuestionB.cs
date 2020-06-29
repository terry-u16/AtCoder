using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu015.Algorithms;
using Kujikatsu015.Collections;
using Kujikatsu015.Extensions;
using Kujikatsu015.Numerics;
using Kujikatsu015.Questions;

namespace Kujikatsu015.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc006/tasks/agc006_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            for (int i = n; true; i--)
            {
                if (t.StartsWith(s.Substring(s.Length - i, i)))
                {
                    yield return i + 2 * (n - i);
                    yield break;
                }
            }
        }
    }
}
