using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200918.Algorithms;
using Training20200918.Collections;
using Training20200918.Extensions;
using Training20200918.Numerics;
using Training20200918.Questions;

namespace Training20200918.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc068/tasks/arc068_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var bucket = new int[100001];

            foreach (var ai in a)
            {
                bucket[ai]++;
            }

            var count = bucket.Where(b => b > 1).Select(b => b - 1).Sum();
            yield return n - (count + 1) / 2 * 2;
        }
    }
}
