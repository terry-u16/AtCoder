using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu115.Algorithms;
using Kujikatsu115.Collections;
using Kujikatsu115.Numerics;
using Kujikatsu115.Questions;

namespace Kujikatsu115.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2019-beginner/tasks/tenka1_2019_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var s = io.ReadString();

            const int White = 0;
            const int Black = 1;
            var counts = new int[n, 2].Fill(1 << 28);
            counts[0, White] = s[0] == '.' ? 0 : 1;
            counts[0, Black] = s[0] == '#' ? 0 : 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    // 白
                    counts[i, White].ChangeMin(counts[i - 1, White]);
                    counts[i, Black].ChangeMin(counts[i - 1, White] + 1);
                    counts[i, Black].ChangeMin(counts[i - 1, Black] + 1);
                }
                else
                {
                    // 黒
                    counts[i, White].ChangeMin(counts[i - 1, White] + 1);
                    counts[i, Black].ChangeMin(counts[i - 1, White]);
                    counts[i, Black].ChangeMin(counts[i - 1, Black]);
                }
            }

            io.WriteLine(Math.Min(counts[n - 1, White], counts[n - 1, Black]));
        }
    }
}
