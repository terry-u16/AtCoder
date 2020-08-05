using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu052.Algorithms;
using Kujikatsu052.Collections;
using Kujikatsu052.Extensions;
using Kujikatsu052.Numerics;
using Kujikatsu052.Questions;

namespace Kujikatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc125/tasks/abc125_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var minuses = a.Count(ai => ai < 0);

            if (minuses % 2 == 0)
            {
                yield return a.Sum(ai => Math.Abs(ai));
            }
            else
            {
                yield return a.Sum(ai => Math.Abs(ai)) - 2 * a.Min(ai => Math.Abs(ai));
            }
        }
    }
}
