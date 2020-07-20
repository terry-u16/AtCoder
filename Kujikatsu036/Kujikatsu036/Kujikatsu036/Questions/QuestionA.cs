using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu036.Algorithms;
using Kujikatsu036.Collections;
using Kujikatsu036.Extensions;
using Kujikatsu036.Numerics;
using Kujikatsu036.Questions;

namespace Kujikatsu036.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc044/tasks/abc044_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var k = inputStream.ReadInt();
            var x = inputStream.ReadInt();
            var y = inputStream.ReadInt();

            var fee = x * Math.Min(k, n);

            if (n > k)
            {
                fee += y * (n - k);
            }

            yield return fee;
        }
    }
}
