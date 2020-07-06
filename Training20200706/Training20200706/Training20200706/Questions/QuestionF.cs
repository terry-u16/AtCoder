using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2012yo/tasks/joi2012yo_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 10000;
            var (totalDays, k) = inputStream.ReadValue<int, int>();

            var queue = Load(k, inputStream);
            var counts = new Modular[totalDays, 3, 3];
            var all = new[] { 0, 1, 2 };

            {
                IEnumerable<int> today;
                if (queue.Count > 0 && queue.Peek().Day == 0)
                {
                    today = new[] { queue.Dequeue().Pasta };
                }
                else
                {
                    today = all;
                }

                foreach (var pasta in today)
                {
                    counts[0, pasta, 0] = 1;
                }
            }

            {
                IEnumerable<int> today;
                if (queue.Count > 0 && queue.Peek().Day == 1)
                {
                    today = new[] { queue.Dequeue().Pasta };
                }
                else
                {
                    today = all;
                }

                foreach (var pasta in today)
                {
                    for (int yesterday = 0; yesterday < 3; yesterday++)
                    {
                        counts[1, pasta, yesterday] += counts[0, yesterday, 0];
                    }
                }
            }

            for (int day = 2; day < totalDays; day++)
            {
                IEnumerable<int> today;
                if (queue.Count > 0 && queue.Peek().Day == day)
                {
                    today = new[] { queue.Dequeue().Pasta };
                }
                else
                {
                    today = all;
                }

                foreach (var pasta in today)
                {
                    for (int yesterday = 0; yesterday < 3; yesterday++)
                    {
                        for (int dayBeforeYesterday = 0; dayBeforeYesterday < 3; dayBeforeYesterday++)
                        {
                            if (pasta != yesterday || yesterday != dayBeforeYesterday)
                            {
                                counts[day, pasta, yesterday] += counts[day - 1, yesterday, dayBeforeYesterday];
                            }
                        }
                    }
                }
            }

            var total = Modular.Zero;
            for (int yesterday = 0; yesterday < 3; yesterday++)
            {
                for (int dayBeforeYesterday = 0; dayBeforeYesterday < 3; dayBeforeYesterday++)
                {
                    total += counts[totalDays - 1, yesterday, dayBeforeYesterday];
                }
            }

            yield return total.Value;
        }

        Queue<DayAndPasta> Load(int k, TextReader inputStream)
        {
            var a = new DayAndPasta[k];
            for (int i = 0; i < k; i++)
            {
                var (day, pasta) = inputStream.ReadValue<int, int>();
                day--;
                pasta--;
                a[i] = new DayAndPasta(day, pasta);
            }

            Array.Sort(a);
            return new Queue<DayAndPasta>(a);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct DayAndPasta : IComparable<DayAndPasta>
        {
            public int Day { get; }
            public int Pasta { get; }

            public DayAndPasta(int day, int pasta)
            {
                Day = day;
                Pasta = pasta;
            }

            public void Deconstruct(out int day, out int pasta) => (day, pasta) = (Day, Pasta);
            public override string ToString() => $"{nameof(Day)}: {Day}, {nameof(Pasta)}: {Pasta}";

            public int CompareTo([AllowNull] DayAndPasta other) => Day - other.Day;
        }
    }
}
