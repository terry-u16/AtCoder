using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu025.Algorithms;
using Kujikatsu025.Collections;
using Kujikatsu025.Extensions;
using Kujikatsu025.Numerics;
using Kujikatsu025.Questions;

namespace Kujikatsu025.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc016/tasks/agc016_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var distinct = a.Distinct().ToArray();

            if (distinct.Length > 2 || (distinct.Length == 2 && Math.Abs(distinct[0] - distinct[1]) > 1))
            {
                yield return "No";
            }
            else if (distinct.Length == 1)
            {
                if (a.Length >= a[0] * 2 || a.Length == a[0] + 1)
                {
                    yield return "Yes";
                }
                else
                {
                    yield return "No";
                }
            }
            else
            {
                Array.Sort(distinct);
                var small = distinct[0];
                var large = distinct[1];
                var smallCount = a.Count(ai => ai == small);
                var largeCount = a.Count(ai => ai == large);
                var remainColor = large - smallCount;
                yield return remainColor > 0 && largeCount >= remainColor * 2 ? "Yes" : "No";
            }
        }
    }
}
