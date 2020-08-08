using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu055.Algorithms;
using Kujikatsu055.Collections;
using Kujikatsu055.Extensions;
using Kujikatsu055.Numerics;
using Kujikatsu055.Questions;

namespace Kujikatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc028/tasks/agc028_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (_, _) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();
            var resultLength = NumericalAlgorithms.Lcm(s.Length, t.Length);
            if (s.Length > t.Length)
            {
                (s, t) = (t, s);
            }

            var sStride = resultLength / s.Length;
            var tStride = resultLength / t.Length;

            for (int i = 0; i < s.Length; i++)
            {
                var resultIndex = sStride * i;
                if (resultIndex % tStride == 0)
                {
                    var tIndex = (int)(resultIndex / tStride);
                    if (s[i] != t[tIndex])
                    {
                        yield return -1;
                        yield break;
                    }
                }
            }


            yield return resultLength;
        }
    }
}
