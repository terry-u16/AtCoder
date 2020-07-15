using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu031.Algorithms;
using Kujikatsu031.Collections;
using Kujikatsu031.Extensions;
using Kujikatsu031.Numerics;
using Kujikatsu031.Questions;

namespace Kujikatsu031.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc161/tasks/abc161_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k, c) = inputStream.ReadValue<int, int, int>();
            var s = inputStream.ReadLine();
            var greedy = new Queue<int>();
            var nonGreedy = new Stack<int>();

            var day = 0;
            var last = -(1 << 28);
            while (greedy.Count < k)
            {
                if (s[day] == 'o' && day - last > c)
                {
                    greedy.Enqueue(day);
                    last = day;
                }
                day++;
            }

            day = n - 1;
            last = 1 << 28;
            while (nonGreedy.Count < k)
            {
                if (s[day] == 'o' && last - day > c)
                {
                    nonGreedy.Push(day);
                    last = day;
                }
                day--;
            }

            var mustWorkDay = new Queue<int>();
            for (int i = 0; i < k; i++)
            {
                var earliest = greedy.Dequeue();
                var latest = nonGreedy.Pop();
                if (earliest == latest)
                {
                    mustWorkDay.Enqueue(earliest + 1);
                }
            }

            return mustWorkDay.Cast<object>();
        }
    }
}
