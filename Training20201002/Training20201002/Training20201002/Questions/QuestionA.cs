using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201002.Algorithms;
using Training20201002.Collections;
using Training20201002.Numerics;
using Training20201002.Questions;

namespace Training20201002.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc084/tasks/arc084_b?lang=ja
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var k = io.ReadLong();
            var result = int.MaxValue;
            const int Max = 100000;

            for (int mul = 1; mul < Max; mul++)
            {
                result.ChangeMin(GetDigitSum(k * mul));
            }

            io.WriteLine(result);
        }

        int GetDigitSum(long n)
        {
            var sum = 0;

            while (n > 0)
            {
                var div = n / 10;
                var mod = n - div * 10;
                n = div;
                sum += (int)mod;
            }

            return sum;
        }
    }
}
