using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu031.Algorithms;
using Kujikatsu031.Collections;
using Kujikatsu031.Extensions;
using Kujikatsu031.Numerics;
using Kujikatsu031.Questions;

namespace Kujikatsu031.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, duration) = inputStream.ReadValue<int, long>();
            var t = inputStream.ReadLongArray();
            long total = 0;
            long before = int.MinValue;

            foreach (var ti in t)
            {
                total += Math.Min(duration, ti - before);
                before = ti;
            }

            yield return total;
        }
    }
}
