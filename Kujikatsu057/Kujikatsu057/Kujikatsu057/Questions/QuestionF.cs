using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu057.Algorithms;
using Kujikatsu057.Collections;
using Kujikatsu057.Extensions;
using Kujikatsu057.Numerics;
using Kujikatsu057.Questions;

namespace Kujikatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualb/tasks/codefestival_2016_qualB_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (width, height) = inputStream.ReadValue<int, int>();
            var horizontalQueue = new Queue<long>(Enumerable.Repeat(0, width).Select(_ => inputStream.ReadLong()).OrderBy(c => c));
            var verticalQueue = new Queue<long>(Enumerable.Repeat(0, height).Select(_ => inputStream.ReadLong()).OrderBy(c => c));

            horizontalQueue.Enqueue(long.MaxValue);
            verticalQueue.Enqueue(long.MaxValue);

            long totalCost = 0;

            while (horizontalQueue.Count > 1 || verticalQueue.Count > 1)
            {
                if (horizontalQueue.Peek() < verticalQueue.Peek())
                {
                    var horizontal = horizontalQueue.Dequeue();
                    totalCost += horizontal * verticalQueue.Count;
                }
                else
                {
                    var vertical = verticalQueue.Dequeue();
                    totalCost += vertical * horizontalQueue.Count;
                }
            }

            yield return totalCost;
        }
    }
}
