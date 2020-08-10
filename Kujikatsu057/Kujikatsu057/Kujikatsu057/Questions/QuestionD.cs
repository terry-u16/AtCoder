using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu057.Algorithms;
using Kujikatsu057.Collections;
using Kujikatsu057.Extensions;
using Kujikatsu057.Numerics;
using Kujikatsu057.Questions;

namespace Kujikatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc042/tasks/arc058_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (price, _) = inputStream.ReadValue<int, int>();
            var dislikes = inputStream.ReadIntArray().Select(i => (char)(i + '0')).ToArray();

            for (int payment = price; true; payment++)
            {
                if (!payment.ToString().Any(c => dislikes.Contains(c)))
                {
                    yield return payment;
                    yield break;
                }
            }
        }
    }
}
