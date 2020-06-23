using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc077/tasks/abc077_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var upper = inputStream.ReadLine();
            var lower = inputStream.ReadLine();

            if (upper.SequenceEqual(lower.Reverse()))
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
