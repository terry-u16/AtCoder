using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu016.Algorithms;
using Kujikatsu016.Collections;
using Kujikatsu016.Extensions;
using Kujikatsu016.Numerics;
using Kujikatsu016.Questions;

namespace Kujikatsu016.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc144/tasks/abc144_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, x) = inputStream.ReadValue<double, double, double>();
            var h = x / (a * a);

            double radian;
            if (h >= b / 2)
            {
                radian = Math.Atan(2 * (b - h) / a);
            }
            else
            {
                radian = Math.Atan(a * b * b / (2 * x));
            }
            yield return radian * 360 / (2 * Math.PI);
        }
    }
}
