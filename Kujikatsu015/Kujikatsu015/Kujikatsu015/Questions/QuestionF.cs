using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu015.Algorithms;
using Kujikatsu015.Collections;
using Kujikatsu015.Extensions;
using Kujikatsu015.Numerics;
using Kujikatsu015.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu015.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc128/tasks/abc128_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, people) = inputStream.ReadValue<int, int>();

            var events = new Event[n * 2];
            for (int i = 0; i < n; i++)
            {
                var (s, t, x) = inputStream.ReadValue<int, int, int>();
                events[2 * i] = new Event(s - x, true, x);
                events[2 * i + 1] = new Event(t - x, false, x);
            }

            var sortedEvents = new Queue<Event>(events.OrderBy(e => e));

            var startTimes = new int[people];
            for (int i = 0; i < startTimes.Length; i++)
            {
                startTimes[i] = inputStream.ReadInt();
            }

            var inConstructionCoordinates = new SortedSet<int>();

            foreach (var time in startTimes)
            {
                while (sortedEvents.Count > 0 && sortedEvents.Peek().Time <= time)
                {
                    var newEvent = sortedEvents.Dequeue();
                    if (newEvent.IsAdd)
                    {
                        inConstructionCoordinates.Add(newEvent.Coordinate);
                    }
                    else
                    {
                        inConstructionCoordinates.Remove(newEvent.Coordinate);
                    }
                }

                if (inConstructionCoordinates.Count > 0)
                {
                    yield return inConstructionCoordinates.Min;
                }
                else
                {
                    yield return -1;
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Event : IComparable<Event>
        {
            public int Time { get; }
            public bool IsAdd { get; }
            public int Coordinate { get; }

            public Event(int time, bool isAdd, int coordinate)
            {
                Time = time;
                IsAdd = isAdd;
                Coordinate = coordinate;
            }

            public override string ToString() => $"{nameof(Time)}: {Time}, {nameof(IsAdd)}: {IsAdd}, {nameof(Coordinate)}: {Coordinate}";

            public int CompareTo([AllowNull] Event other)
            {
                var comp = Time - other.Time;
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    if (IsAdd && !other.IsAdd)
                    {
                        return 1;
                    }
                    else if (!IsAdd && other.IsAdd)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
