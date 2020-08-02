using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu048.Algorithms;
using Kujikatsu048.Collections;
using Kujikatsu048.Extensions;
using Kujikatsu048.Numerics;
using Kujikatsu048.Questions;

namespace Kujikatsu048.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc103/tasks/abc103_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            for (int shift = 0; shift < s.Length; shift++)
            {
                var ok = true;
                for (int i = 0; i < t.Length; i++)
                {
                    if (s[(i + shift) % s.Length] != t[i])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    yield return "Yes";
                    yield break;
                }
            }

            yield return "No";
        }
    }
}
