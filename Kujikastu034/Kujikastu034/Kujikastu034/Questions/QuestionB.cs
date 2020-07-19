using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikastu034.Algorithms;
using Kujikastu034.Collections;
using Kujikastu034.Extensions;
using Kujikastu034.Numerics;
using Kujikastu034.Questions;

namespace Kujikastu034.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc152/tasks/abc152_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();
            var max = int.MaxValue;
            var count = 0;

            foreach (var pi in p)
            {
                if (pi <= max)
                {
                    count++;
                    max = pi;
                }
            }

            yield return count;
        }
    }
}
