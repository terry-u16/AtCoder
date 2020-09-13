using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu086.Algorithms;
using Kujikatsu086.Collections;
using Kujikatsu086.Extensions;
using Kujikatsu086.Numerics;
using Kujikatsu086.Questions;

namespace Kujikatsu086.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc084/tasks/arc084_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();
            var c = inputStream.ReadIntArray();

            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            long result = 0;

            foreach (var bi in b)
            {
                result += (long)(SearchExtensions.GetLessThanIndex(a, bi) + 1) * (c.Length - SearchExtensions.GetGreaterThanIndex(c, bi));
            }

            yield return result;
        }
    }
}
