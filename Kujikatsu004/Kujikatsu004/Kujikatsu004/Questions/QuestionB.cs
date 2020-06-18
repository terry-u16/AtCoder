using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu004.Algorithms;
using Kujikatsu004.Collections;
using Kujikatsu004.Extensions;
using Kujikatsu004.Numerics;
using Kujikatsu004.Questions;

namespace Kujikatsu004.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc138/tasks/abc138_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var _ = inputStream.ReadInt();
            var v = inputStream.ReadIntArray();
            Array.Sort(v);

            double sum = v[0];

            foreach (var vi in v.Skip(1))
            {
                sum = (sum + vi) / 2;
            }

            yield return sum;
        }
    }
}
