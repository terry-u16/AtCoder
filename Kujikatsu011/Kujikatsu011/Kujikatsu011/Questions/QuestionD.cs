using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu011.Algorithms;
using Kujikatsu011.Collections;
using Kujikatsu011.Extensions;
using Kujikatsu011.Numerics;
using Kujikatsu011.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu011.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/diverta2019-2/tasks/diverta2019_2_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                points[i] = new Point(x, y);
            }

            if (points.Length == 1)
            {
                yield return 1;
                yield break;
            }

            Array.Sort(points);

            var diffs = new List<Diff>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i != j)
                    {
                        diffs.Add(points[j] - points[i]);
                    }
                }
            }

            var min = long.MaxValue;
            foreach (var diff in diffs)
            {
                var before = points[0];
                var cost = 1;
                var seen = new bool[points.Length];
                seen[0] = true;

                while (true)
                {
                    var found = false;

                    for (int i = 0; i < points.Length; i++)
                    {
                        if (!seen[i] && before + diff == points[i])
                        {
                            before = points[i];
                            seen[i] = true;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        var hasNext = false;
                        for (int i = 0; i < points.Length; i++)
                        {
                            if (!seen[i])
                            {
                                hasNext = true;
                                seen[i] = true;
                                before = points[i];
                                cost++;
                                break;
                            }
                        }
                        if (!hasNext)
                        {
                            break;
                        }
                    }
                }

                min = Math.Min(min, cost);
            }

            yield return min;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Point : IEquatable<Point>, IComparable<Point>
        {
            public long X { get; }
            public long Y { get; }

            public Point(long x, long y)
            {
                X = x;
                Y = y;
            }

            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

            public override bool Equals(object obj)
            {
                return obj is Point point && Equals(point);
            }

            public bool Equals(Point other)
            {
                return X == other.X &&
                       Y == other.Y;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }

            public int CompareTo([AllowNull] Point other)
            {
                var comp = Math.Sign(X - other.X);
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return Math.Sign(Y - other.Y);
                }
            }

            public static Point operator +(Point a, Diff b) => new Point(a.X + b.DX, a.Y + b.DY);
            public static Diff operator -(Point a, Point b) => new Diff(a.X - b.X, a.Y - b.Y);

            public static bool operator ==(Point left, Point right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Point left, Point right)
            {
                return !(left == right);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Diff
        {
            public long DX { get; }
            public long DY { get; }

            public Diff(long dx, long dy)
            {
                DX = dx;
                DY = dy;
            }

            public override string ToString() => $"{nameof(DX)}: {DX}, {nameof(DY)}: {DY}";
        }
    }
}
