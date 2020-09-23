using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu101.Algorithms;
using Kujikatsu101.Collections;
using Kujikatsu101.Numerics;
using Kujikatsu101.Questions;

namespace Kujikatsu101.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc175/tasks/abc175_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var l = io.ReadIntArray(n);

            Array.Sort(l);

            var count = 0;

            for (int i = 0; i < l.Length; i++)
            {
                for (int j = i + 1; j < l.Length; j++)
                {
                    for (int k = j + 1; k < l.Length; k++)
                    {
                        if (l[i] != l[j] && l[j] != l[k] && l[i] + l[j] > l[k])
                        {
                            count++;
                        }
                    }
                }
            }

            io.WriteLine(count);
        }
    }
}
