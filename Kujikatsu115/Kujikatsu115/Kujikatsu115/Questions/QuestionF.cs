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
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadInt();
            var a = new int[n];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = (io.ReadInt() - 1) % k;
            }

            var dp = new int[n + 1];
            var counter = new Counter<int>();
            counter[0] = 1;
            long result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                var current = (dp[i] + a[i]) % k;
                dp[i + 1] = current;
                counter[current]++;
                if (i - k + 1 >= 0)
                {
                    counter[dp[i - k + 1]]--;
                }

                result += counter[current] - 1;
            }

            io.WriteLine(result);
        }
    }
}
