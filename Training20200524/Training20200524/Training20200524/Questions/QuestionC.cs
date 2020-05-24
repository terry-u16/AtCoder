using Training20200524.Questions;
using Training20200524.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200524.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2007ho/tasks/joi2007ho_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var pillarCount = inputStream.ReadInt();
            var pillars = new Pillar[pillarCount];
            for (int i = 0; i < pillarCount; i++)
            {
                var xy = inputStream.ReadIntArray();
                pillars[i] = new Pillar(xy[0], xy[1]);
            }

            Array.Sort(pillars);

            int max = 0;
            for (int i = 0; i < pillars.Length; i++)
            {
                for (int j = i + 1; j < pillars.Length; j++)
                {
                    var dx = pillars[i].Y - pillars[j].Y;
                    var dy = pillars[j].X - pillars[i].X;
                    var p = new Pillar(pillars[j].X + dx, pillars[j].Y + dy);
                    var q = new Pillar(pillars[i].X + dx, pillars[i].Y + dy);
                    if (Array.BinarySearch(pillars, p) >= 0 && Array.BinarySearch(pillars, q) >= 0)
                    {
                        var square = dx * dx + dy * dy;
                        max = Math.Max(max, square);
                    }
                }
            }

            yield return max;
        }

        struct Pillar : IEquatable<Pillar>, IComparable<Pillar>
        {
            public int X { get; }
            public int Y { get; }

            public Pillar(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                return obj is Pillar && Equals((Pillar)obj);
            }

            public bool Equals(Pillar other)
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

            public int CompareTo(Pillar other)
            {
                var comp = X.CompareTo(other.X);
                if (comp != 0)
                {
                    return comp;
                }
                return Y.CompareTo(other.Y);
            }

            public static bool operator ==(Pillar left, Pillar right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Pillar left, Pillar right)
            {
                return !(left == right);
            }
        }
    }
}
