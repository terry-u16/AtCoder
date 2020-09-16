using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc143/tasks/abc143_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var l = inputStream.ReadIntArray();
            Array.Sort(l);

            var counts = 0;

            for (int i = 0; i < l.Length; i++)
            {
                for (int j = i + 1; j < l.Length; j++)
                {
                    counts += SearchExtensions.GetLessThanIndex(l, l[i] + l[j]) - j;
                }
            }

            yield return counts;
        }
    }
}
