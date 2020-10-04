using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderRegularContest104.Algorithms;
using AtCoderRegularContest104.Collections;
using AtCoderRegularContest104.Numerics;
using AtCoderRegularContest104.Questions;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AtCoder;
using AtCoder.Internal;

namespace AtCoderRegularContest104.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var s = io.ReadString();

            const int A = 0;
            const int T = 1;
            const int C = 2;
            const int G = 3;

            var counts = new int[s.Length + 1, 4];

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i] switch
                {
                    'A' => A,
                    'T' => T,
                    'C' => C,
                    'G' => G
                };
                counts[i + 1, c]++;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    counts[i + 1, j] += counts[i, j];
                }
            }

            var result = 0;

            for (int l = 0; l < s.Length; l++)
            {
                for (int r = l + 1; r <= s.Length; r++)
                {
                    var a = counts[r, A] - counts[l, A];
                    var t = counts[r, T] - counts[l, T];
                    var c = counts[r, C] - counts[l, C];
                    var g = counts[r, G] - counts[l, G];

                    if (a == t && c == g)
                    {
                        result++;
                    }
                }
            }

            io.WriteLine(result);
        }
    }
}
