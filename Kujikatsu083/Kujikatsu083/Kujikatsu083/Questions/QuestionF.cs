using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu083.Algorithms;
using Kujikatsu083.Collections;
using Kujikatsu083.Extensions;
using Kujikatsu083.Numerics;
using Kujikatsu083.Questions;

namespace Kujikatsu083.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc071/tasks/arc071_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            var sA = new int[s.Length + 1];
            var tA = new int[t.Length + 1];

            for (int i = 0; i < s.Length; i++)
            {
                sA[i + 1] = sA[i] + (s[i] == 'A' ? 1 : 2);
            }

            for (int i = 0; i < t.Length; i++)
            {
                tA[i + 1] = tA[i] + (t[i] == 'A' ? 1 : 2);
            }

            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var (a, b, c, d) = inputStream.ReadValue<int, int, int, int>();
                a--;
                c--;

                if ((sA[b] - sA[a]) % 3 == (tA[d] - tA[c]) % 3)
                {
                    yield return "YES";
                }
                else
                {
                    yield return "NO";
                }
            }
        }
    }
}
