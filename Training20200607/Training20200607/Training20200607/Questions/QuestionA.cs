using Training20200607.Questions;
using Training20200607.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200607.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2018-beginner/tasks/tenka1_2018_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = inputStream.ReadInt();
            }

            Array.Sort(a);
            var ascendingQueue = new Queue<int>(a);
            Array.Reverse(a);
            var descendingQueue = new Queue<int>(a);

            long sum = 0;
            var list = new LinkedList<int>();
            list.AddLast(ascendingQueue.Dequeue());

            while (ascendingQueue.Count + descendingQueue.Count > n)
            {
                var smallFirst = Math.Abs(ascendingQueue.Peek() - list.First.Value);
                var smallLast = Math.Abs(ascendingQueue.Peek() - list.Last.Value);
                var largeFirst = Math.Abs(descendingQueue.Peek() - list.First.Value);
                var largeLast = Math.Abs(descendingQueue.Peek() - list.Last.Value);

                if (smallFirst > smallLast && smallFirst > largeFirst && smallFirst > largeLast)
                {
                    var value = ascendingQueue.Dequeue();
                    sum += Math.Abs(value - list.First.Value);
                    list.AddFirst(value);
                }
                else if (smallLast > largeFirst && smallLast > largeLast)
                {
                    var value = ascendingQueue.Dequeue();
                    sum += Math.Abs(value - list.Last.Value);
                    list.AddLast(value);
                }
                else if (largeFirst > largeLast)
                {
                    var value = descendingQueue.Dequeue();
                    sum += Math.Abs(value - list.First.Value);
                    list.AddFirst(value);
                }
                else
                {
                    var value = descendingQueue.Dequeue();
                    sum += Math.Abs(value - list.Last.Value);
                    list.AddLast(value);
                }
            }

            yield return sum;
        }
    }
}
