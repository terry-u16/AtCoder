using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest179.Algorithms;
using AtCoderBeginnerContest179.Collections;
using AtCoderBeginnerContest179.Numerics;
using AtCoderBeginnerContest179.Questions;

namespace AtCoderBeginnerContest179.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var d1 = new int[n];
            var d2 = new int[n];

            for (int i = 0; i < d1.Length; i++)
            {
                d1[i] = io.ReadInt();
                d2[i] = io.ReadInt();
            }

            for (int i = 0; i + 2 < d1.Length; i++)
            {
                var ok = true;
                for (int j = 0; j < 3; j++)
                {
                    ok &= d1[i + j] == d2[i + j];
                }

                if (ok)
                {
                    io.WriteLine("Yes");
                    return;
                }
            }

            io.WriteLine("No");
        }
    }
}
