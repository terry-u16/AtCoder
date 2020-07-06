using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc054/tasks/arc054_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var p = inputStream.ReadDouble();
            double left = 0;
            double right = p;

            const int iterations = 10000;

            for (int i = 0; i < iterations; i++)
            {
                var span = right - left;
                var x1 = left + span / 3;
                var x2 = left + span / 3 * 2;

                if (CalculateTime(x1, p) < CalculateTime(x2, p))
                {
                    right = x2;
                }
                else
                {
                    left = x1;
                }
            }

            yield return CalculateTime((left + right) / 2, p);
        }

        double CalculateTime(double startTime, double p)
        {
            var speedFactor = Math.Pow(2, startTime / 1.5);
            return startTime + p / speedFactor;
        }
    }
}
