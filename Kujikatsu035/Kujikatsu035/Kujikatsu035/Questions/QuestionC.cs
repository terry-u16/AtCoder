using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu035.Algorithms;
using Kujikatsu035.Collections;
using Kujikatsu035.Extensions;
using Kujikatsu035.Numerics;
using Kujikatsu035.Questions;

namespace Kujikatsu035.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc116/tasks/abc116_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();

            var last = 0;
            var total = 0;
            foreach (var hi in h)
            {
                total += Math.Max(hi - last, 0);
                last = hi;
            }

            yield return total;
        }
    }
}
