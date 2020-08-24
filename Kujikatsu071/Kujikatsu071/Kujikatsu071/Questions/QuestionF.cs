using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu071.Algorithms;
using Kujikatsu071.Collections;
using Kujikatsu071.Extensions;
using Kujikatsu071.Numerics;
using Kujikatsu071.Questions;

namespace Kujikatsu071.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc104/tasks/abc104_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var counts = new Modular[s.Length + 1, 4];
            const int None = 0;
            const int A = 1;
            const int AB = 2;
            const int ABC = 3;
            counts[0, None] = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '?')
                {
                    var c = s[i] - 'A';
                    for (int j = None; j <= ABC; j++)
                    {
                        counts[i + 1, j] = counts[i, j];
                    }
                    counts[i + 1, c + 1] += counts[i, c];
                }
                else
                {
                    for (int j = None; j <= ABC; j++)
                    {
                        counts[i + 1, j] = counts[i, j] * 3;
                    }

                    for (int j = A; j <= ABC; j++)
                    {
                        counts[i + 1, j] += counts[i, j - 1];
                    }
                }
            }

            yield return counts[s.Length, ABC];
        }
    }
}
