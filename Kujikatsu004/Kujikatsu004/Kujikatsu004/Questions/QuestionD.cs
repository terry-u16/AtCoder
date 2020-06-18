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
    /// https://atcoder.jp/contests/abc140/tasks/abc140_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine();

            var happiness = s.Zip(s.Skip(1)).Count(p => p.First == p.Second);
            yield return Math.Min(happiness + 2 * k, s.Length - 1);
        }
    }
}
