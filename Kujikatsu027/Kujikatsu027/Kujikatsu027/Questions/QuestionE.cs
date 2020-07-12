using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu027.Algorithms;
using Kujikatsu027.Collections;
using Kujikatsu027.Extensions;
using Kujikatsu027.Numerics;
using Kujikatsu027.Questions;

namespace Kujikatsu027.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc025/tasks/agc025_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var sections = new Section[n];

            for (int i = 0; i < sections.Length; i++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                sections[i] = new Section(l, r, i);
            }

            long max = 0;
            const int Plus = 0;
            const int Minus = 1;

            for (int begin = 0; begin < 2; begin++)
            {
                var queues = new Queue<Section>[] { new Queue<Section>(sections.OrderByDescending(s => s.Left)), new Queue<Section>(sections.OrderBy(s => s.Right)) };
                var selected = new HashSet<int>(n);
                long sum = 0;
                int current = 0;

                for (int i = 0; i < n; i++)
                {
                    var leftRight = begin + i;
                    if (leftRight % 2 == Plus)
                    {
                        Section section;
                        while (true)
                        {
                            section = queues[Plus].Dequeue();
                            if (selected.Add(section.Index))
                            {
                                break;
                            }
                        }

                        if (current < section.Left)
                        {
                            sum += Math.Abs(current - section.Left);
                            current = section.Left;
                        }
                    }
                    else
                    {
                        Section section;
                        while (true)
                        {
                            section = queues[Minus].Dequeue();
                            if (selected.Add(section.Index))
                            {
                                break;
                            }
                        }

                        if (current > section.Right)
                        {
                            sum += Math.Abs(current - section.Right);
                            current = section.Right;
                        }
                    }
                }

                sum += Math.Abs(current);
                max = Math.Max(max, sum);
            }

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Section : IEquatable<Section>
        {
            public int Left { get; }
            public int Right { get; }
            public int Index { get; }
            public bool IncludeZero => Math.Sign(Left) * Math.Sign(Right) <= 0;

            public Section(int left, int right, int index)
            {
                Left = left;
                Right = right;
                Index = index;
            }

            public void Deconstruct(out int left, out int right) => (left, right) = (Left, Right);
            public override string ToString() => $"{nameof(Left)}: {Left}, {nameof(Right)}: {Right}";

            public override bool Equals(object obj)
            {
                return obj is Section section && Equals(section);
            }

            public bool Equals(Section other)
            {
                return Left == other.Left &&
                       Right == other.Right &&
                       Index == other.Index;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Left, Right, Index);
            }

            public static bool operator ==(Section left, Section right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Section left, Section right)
            {
                return !(left == right);
            }
        }
    }
}
