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
    /// https://atcoder.jp/contests/agc005/tasks/agc005_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const string possible = "Possible";
            const string impossible = "Impossible";
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            Array.Sort(a);

            var min = a[0];
            var max = a[^1];

            var counts = new int[max + 1];

            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = a.Count(ai => ai == i);
            }

            if (counts[min] > 2)
            {
                io.WriteLine(impossible);
            }
            else if (counts[min] == 1 && (min * 2 != max))
            {
                io.WriteLine(impossible);
            }
            else if (counts[min] == 2 && (min * 2 - 1 != max))
            {
                io.WriteLine(impossible);
            }
            else
            {
                for (int i = min + 1; i < counts.Length; i++)
                {
                    if (counts[i] < 2)
                    {
                        io.WriteLine(impossible);
                        return;
                    }
                }

                io.WriteLine(possible);
            }
        }
    }
}
