using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu060.Algorithms;
using Kujikatsu060.Collections;
using Kujikatsu060.Extensions;
using Kujikatsu060.Numerics;
using Kujikatsu060.Questions;

namespace Kujikatsu060.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tokiomarine2020/tasks/tokiomarine2020_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (xa, va) = inputStream.ReadValue<long, long>();
            var (xb, vb) = inputStream.ReadValue<long, long>();
            var timeLimit = inputStream.ReadInt();

            var distance = Math.Abs(xa - xb);
            var velocity = va - vb;

            if (velocity * timeLimit >= distance)
            {
                yield return "YES";
            }
            else
            {
                yield return "NO";
            }
        }
    }
}
