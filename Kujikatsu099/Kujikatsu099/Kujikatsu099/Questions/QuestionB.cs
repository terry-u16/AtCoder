using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu099.Algorithms;
using Kujikatsu099.Collections;
using Kujikatsu099.Numerics;
using Kujikatsu099.Questions;

namespace Kujikatsu099.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var cards = io.ReadInt();
            var gates = io.ReadInt();

            var counts = new int[cards + 1];

            for (int i = 0; i < gates; i++)
            {
                var l = io.ReadInt();
                var r = io.ReadInt();
                counts[l - 1]++;
                counts[r]--;
            }

            for (int i = 0; i + 1 < counts.Length; i++)
            {
                counts[i + 1] += counts[i];
            }

            var result = 0;

            for (int i = 0; i + 1 < counts.Length; i++)
            {
                if (counts[i] == gates)
                {
                    result++;
                }
            }

            io.WriteLine(result);
        }
    }
}
