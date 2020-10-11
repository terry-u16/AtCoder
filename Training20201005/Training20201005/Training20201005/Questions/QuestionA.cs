using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201005.Algorithms;
using Training20201005.Collections;
using Training20201005.Numerics;
using Training20201005.Questions;

namespace Training20201005.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var d = new int[n];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = io.ReadInt();
            }

            var sum = d.Sum();
            var max = d.Max();

            io.WriteLine(sum);
            io.WriteLine(Math.Max(max - (sum - max), 0));
        }
    }
}
