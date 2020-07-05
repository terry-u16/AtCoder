using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest173.Algorithms;
using AtCoderBeginnerContest173.Collections;
using AtCoderBeginnerContest173.Extensions;
using AtCoderBeginnerContest173.Numerics;
using AtCoderBeginnerContest173.Questions;

namespace AtCoderBeginnerContest173.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            Array.Sort(a);
            Array.Reverse(a);

            var total = 0L;
            var queue = new PriorityQueue<long>(true);
            queue.Enqueue(a[0]);

            for (int i = 1; i < a.Length; i++)
            {
                var next = queue.Dequeue();
                total += next;
                queue.Enqueue(a[i]);
                queue.Enqueue(a[i]);
            }

            yield return total;
        }
    }
}
