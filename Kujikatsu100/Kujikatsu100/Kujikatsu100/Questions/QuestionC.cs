using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu100.Algorithms;
using Kujikatsu100.Collections;
using Kujikatsu100.Numerics;
using Kujikatsu100.Questions;

namespace Kujikatsu100.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var b = a.Select(Div2).ToArray();

            var four = b.Count(bi => bi >= 2);
            var two = b.Count(bi => bi == 1);

            var covered = 0;

            if (four > 0 && two > 0)
            {
                covered = four * 2 + two;
            }
            else if (four > 0)
            {
                covered = four * 2 + 1;
            }
            else
            {
                covered = two;
            }

            if (covered >= n)
            {
                io.WriteLine("Yes");
            }
            else
            {
                io.WriteLine("No");
            }
        }

        int Div2(int n)
        {
            var count = 0;
            while (n > 0 && (n & 1) == 0)
            {
                count++;
                n >>= 1;
            }
            return count;
        }
    }
}
