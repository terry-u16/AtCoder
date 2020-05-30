using VirtualContest20200530.Questions;
using VirtualContest20200530.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VirtualContest20200530.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/diverta2019-2/tasks/diverta2019_2_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            if (n == 1)
            {
                yield return 1;
                yield break;
            }

            var points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                var xy = inputStream.ReadIntArray();
                points[i] = new Point(xy[0], xy[1]);
            }

            Array.Sort(points);

            var diffs = new HashSet<Diff>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    diffs.Add(points[i].GetDiff(points[j]));
                }
            }

            yield return diffs.Min(diff => GetCost(diff, points));
        }

        int GetCost(Diff diff, Point[] points)
        {
            var seen = new bool[points.Length];
            var current = points[0];
            seen[0] = true;
            var cost = 1;

            while (seen.Any(b => !b))
            {
                var next = FindNext(diff, current, points, seen);
                if (next != -1)
                {
                    current = points[next];
                    seen[next] = true;
                }
                else
                {
                    cost++;
                    for (int i = 0; i < seen.Length; i++)
                    {
                        if (!seen[i])
                        {
                            current = points[i];
                            seen[i] = true;
                            break;
                        }
                    }
                }
            }

            return cost;
        }

        int FindNext(Diff diff, Point current, Point[] points, bool[] seen)
        {
            var next = new Point(current.X + diff.DX, current.Y + diff.DY);
            for (int i = 0; i < points.Length; i++)
            {
                if (!seen[i] && points[i] == next)
                {
                    return i;
                }
            }
            return -1;
        }

        public struct Point : IComparable<Point>, IEquatable<Point>
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Diff GetDiff(Point other) => new Diff(X - other.X, Y - other.Y);

            public int CompareTo(Point other)
            {
                var comp = X.CompareTo(other.X);
                if (comp != 0)
                {
                    return comp;
                }
                return Y.CompareTo(other.Y);
            }

            public override bool Equals(object obj)
            {
                return obj is Point && Equals((Point)obj);
            }

            public bool Equals(Point other)
            {
                return X == other.X &&
                       Y == other.Y;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 1861411795;
                    hashCode = hashCode * -1521134295 + X.GetHashCode();
                    hashCode = hashCode * -1521134295 + Y.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(Point left, Point right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Point left, Point right)
            {
                return !(left == right);
            }
        }

        public struct Diff : IEquatable<Diff>
        {
            public int DX { get; }
            public int DY { get; }

            public Diff(int dx, int dy)
            {
                if (dx < 0)
                {
                    dx = -dx;
                    dy = -dy;
                }
                else if (dx == 0 && dy < 0)
                {
                    dy = -dy;
                }

                DX = dx;
                DY = dy;
            }

            public override bool Equals(object obj)
            {
                return obj is Diff && Equals((Diff)obj);
            }

            public bool Equals(Diff other)
            {
                return DX == other.DX &&
                       DY == other.DY;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 1633967671;
                    hashCode = hashCode * -1521134295 + DX.GetHashCode();
                    hashCode = hashCode * -1521134295 + DY.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(Diff left, Diff right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Diff left, Diff right)
            {
                return !(left == right);
            }
        }
    }
}
