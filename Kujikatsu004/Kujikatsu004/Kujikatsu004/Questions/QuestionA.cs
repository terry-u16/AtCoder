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
    /// https://atcoder.jp/contests/abc089/tasks/abc089_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return n / 3;
        }
    }
}
