using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu064.Algorithms;
using Kujikatsu064.Collections;
using Kujikatsu064.Extensions;
using Kujikatsu064.Numerics;
using Kujikatsu064.Questions;

namespace Kujikatsu064.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/aising2020/tasks/aising2020_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 1 && i % 2 == 0)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
