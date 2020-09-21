using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200919.Algorithms;
using Training20200919.Collections;
using Training20200919.Numerics;
using Training20200919.Questions;

namespace Training20200919.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc113/tasks/abc113_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var t = io.ReadInt();
            var a = io.ReadInt();
            var h = io.ReadIntArray(n);

            t *= 1000;
            a *= 1000;
            var temps = h.Select(hi => t - hi * 6).ToArray();

            var nearest = 0;

            for (int i = 0; i < temps.Length; i++)
            {
                if (Math.Abs(a - temps[i]) < Math.Abs(a - temps[nearest]))
                {
                    nearest = i;
                }
            }

            io.WriteLine(nearest + 1);
        }
    }
}
