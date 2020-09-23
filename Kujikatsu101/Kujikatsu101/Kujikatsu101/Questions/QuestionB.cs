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
    /// https://atcoder.jp/contests/abc131/tasks/abc131_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var l = io.ReadInt();
            var tastes = new int[n];

            for (int i = 0; i < tastes.Length; i++)
            {
                tastes[i] = l + i;
            }

            var total = tastes.Sum();

            var min = int.MaxValue;
            var result = 0;

            for (int excepted = 0; excepted < tastes.Length; excepted++)
            {
                var sum = 0;
                for (int i = 0; i < tastes.Length; i++)
                {
                    if (i != excepted)
                    {
                        sum += tastes[i];
                    }
                }

                if (Math.Abs(sum - total) < min)
                {
                    min = Math.Abs(sum - total);
                    result = sum;
                }
            }

            io.WriteLine(result);
        }
    }
}
