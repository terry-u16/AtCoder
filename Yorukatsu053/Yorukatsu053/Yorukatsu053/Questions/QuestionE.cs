using Yorukatsu053.Questions;
using Yorukatsu053.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc092/tasks/arc092_a
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var redPoints = new List<Point>(n);
            var bluePoints = new List<Point>(n);

            for (int i = 0; i < n; i++)
            {
                var xy = inputStream.ReadIntArray();
                redPoints.Add(new Point(xy[0], xy[1]));
            }

            for (int i = 0; i < n; i++)
            {
                var xy = inputStream.ReadIntArray();
                bluePoints.Add(new Point(xy[0], xy[1]));
            }

            redPoints.Sort((p1, p2) => p2.Y - p1.Y);
            bluePoints.Sort((p1, p2) => p1.X - p2.X);

            var pairCount = 0;
            foreach (var bluePoint in bluePoints)
            {
                if (redPoints.Any(p => p.X < bluePoint.X && p.Y < bluePoint.Y))
                {
                    var removed = redPoints.First(p => p.X < bluePoint.X && p.Y < bluePoint.Y);
                    redPoints.Remove(removed);
                    pairCount++;
                }
            }

            yield return pairCount;
        }

        struct Point : IEquatable<Point>
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
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

            public override string ToString() => $"({X}, {Y})";
        }
    }
}
