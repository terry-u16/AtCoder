using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu021.Algorithms;
using Kujikatsu021.Collections;
using Kujikatsu021.Extensions;
using Kujikatsu021.Numerics;
using Kujikatsu021.Questions;

namespace Kujikatsu021.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc059/tasks/arc059_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var min = int.MaxValue;
            for (int i = -100; i <= 100; i++)
            {
                var sum = a.Sum(ai => (ai - i) * (ai - i));
                min = Math.Min(min, sum);
            }

            yield return min;
        }
    }
}
