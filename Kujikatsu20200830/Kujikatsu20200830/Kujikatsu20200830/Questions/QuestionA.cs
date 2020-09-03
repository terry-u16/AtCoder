using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu20200830.Algorithms;
using Kujikatsu20200830.Collections;
using Kujikatsu20200830.Extensions;
using Kujikatsu20200830.Numerics;
using Kujikatsu20200830.Questions;

namespace Kujikatsu20200830.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc156/tasks/abc156_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, rating) = inputStream.ReadValue<int, int>();
            if (n >= 10)
            {
                yield return rating;
            }
            else
            {
                yield return rating + 100 * (10 - n);
            }
        }
    }
}
