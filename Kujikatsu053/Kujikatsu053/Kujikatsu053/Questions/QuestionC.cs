using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu053.Algorithms;
using Kujikatsu053.Collections;
using Kujikatsu053.Extensions;
using Kujikatsu053.Numerics;
using Kujikatsu053.Questions;

namespace Kujikatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc173/tasks/abc173_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray().OrderByDescending(ai => ai).ToArray();

            long result = 0;
            var queue = new Queue<int>();
            queue.Enqueue(a[0]);

            for (int i = 1; i < a.Length; i++)
            {
                result += queue.Dequeue();
                queue.Enqueue(a[i]);
                queue.Enqueue(a[i]);
            }

            yield return result;
        }
    }
}
