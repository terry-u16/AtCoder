using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu012.Algorithms;
using Kujikatsu012.Collections;
using Kujikatsu012.Extensions;
using Kujikatsu012.Numerics;
using Kujikatsu012.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc137/tasks/abc137_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (jobCount, lastDay) = inputStream.ReadValue<int, int>();
            var waitingJobs = new Queue<Job>(Enumerable.Repeat(0, jobCount).Select(_ =>
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                return new Job(a, b);
            }).OrderBy(j => j.Delay));

            var availableJobs = new PriorityQueue<Job>(true);
            var total = 0;

            for (int day = lastDay - 1; day >= 0; day--)
            {
                while (waitingJobs.Count > 0 && waitingJobs.Peek().Delay + day <= lastDay)
                {
                    availableJobs.Enqueue(waitingJobs.Dequeue());
                }

                if (availableJobs.Count > 0)
                {
                    total += availableJobs.Dequeue().Salary;
                }
            }

            yield return total;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Job : IComparable<Job>
        {
            public int Delay { get; }
            public int Salary { get; }

            public Job(int delay, int salary)
            {
                Delay = delay;
                Salary = salary;
            }

            public override string ToString() => $"{nameof(Delay)}: {Delay}, {nameof(Salary)}: {Salary}";

            public int CompareTo([AllowNull] Job other) => Salary - other.Salary;
        }
    }
}
