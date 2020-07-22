using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu038.Algorithms;
using Kujikatsu038.Collections;
using Kujikatsu038.Extensions;
using Kujikatsu038.Numerics;
using Kujikatsu038.Questions;

namespace Kujikatsu038.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc124/tasks/abc124_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();

            var max = int.MinValue;
            var count = 0;
            for (int i = 0; i < h.Length; i++)
            {
                if (max <= h[i])
                {
                    max = h[i];
                    count++;
                }
            }

            yield return count;
        }
    }
}
