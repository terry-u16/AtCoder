using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu018.Algorithms;
using Kujikatsu018.Collections;
using Kujikatsu018.Extensions;
using Kujikatsu018.Numerics;
using Kujikatsu018.Questions;

namespace Kujikatsu018.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2018-beginner/tasks/tenka1_2018_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new long[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = inputStream.ReadInt();
            }

            Array.Sort(a);

            var list = new LinkedList<long>();

            long sum1 = 0;
            var smaller = new Queue<long>(a);
            var larger = new Stack<long>(a);
            var x = smaller.Peek();
            var y = smaller.Dequeue();

            while (smaller.Count + larger.Count > n)
            {
                if (smaller.Count + larger.Count > n)
                {
                    sum1 += larger.Peek() - x;
                    x = larger.Pop();
                }
                if (smaller.Count + larger.Count > n)
                {
                    sum1 += larger.Peek() - y;
                    y = larger.Pop();
                }
                if (smaller.Count + larger.Count > n)
                {
                    sum1 += x - smaller.Peek();
                    x = smaller.Dequeue();
                }
                if (smaller.Count + larger.Count > n)
                {
                    sum1 += y - smaller.Peek();
                    y = smaller.Dequeue();
                }
            }

            long sum2 = 0;
            smaller = new Queue<long>(a);
            larger = new Stack<long>(a);
            x = larger.Peek();
            y = larger.Pop();

            while (smaller.Count + larger.Count > n)
            {
                if (smaller.Count + larger.Count > n)
                {
                    sum2 += x - smaller.Peek();
                    x = smaller.Dequeue();
                }
                if (smaller.Count + larger.Count > n)
                {
                    sum2 += y - smaller.Peek();
                    y = smaller.Dequeue();
                }
                if (smaller.Count + larger.Count > n)
                {
                    sum2 += larger.Peek() - x;
                    x = larger.Pop();
                }
                if (smaller.Count + larger.Count > n)
                {
                    sum2 += larger.Peek() - y;
                    y = larger.Pop();
                }
            }

            yield return Math.Max(sum1, sum2);
        }
    }
}
