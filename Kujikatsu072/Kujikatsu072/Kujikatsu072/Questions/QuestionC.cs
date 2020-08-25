using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc068/tasks/arc068_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadLong();
            var count = x / 11 * 2;
            var mod = x % 11;
            if (mod > 6)
            {
                count += 2;
            }
            else if (mod > 0)
            {
                count += 1;
            }

            yield return count;
        }
    }
}
