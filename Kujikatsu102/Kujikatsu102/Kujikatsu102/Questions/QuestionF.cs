using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc179/tasks/abc179_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();
            var blacks = (long)(n - 2) * (n - 2);

            var xSegTree = new LazySegmentTree<MinInt, Updater>(Enumerable.Repeat(new MinInt(n), n).ToArray());
            var ySegTree = new LazySegmentTree<MinInt, Updater>(Enumerable.Repeat(new MinInt(n), n).ToArray());

            for (int q = 0; q < queries; q++)
            {
                var xy = io.ReadInt();
                var coordinate = io.ReadInt();

                if (xy == 1)
                {
                    var white = xSegTree.Query(coordinate, coordinate + 1).Value;
                    blacks -= white - 2;
                    ySegTree.Update(0, white, new Updater(coordinate));
                }
                else
                {
                    var white = ySegTree.Query(coordinate, coordinate + 1).Value;
                    blacks -= white - 2;
                    xSegTree.Update(0, white, new Updater(coordinate));
                }
            }

            io.WriteLine(blacks);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct MinInt : IMonoid<MinInt>
        {
            public int Value { get; }

            public MinInt Identity => new MinInt(int.MaxValue);

            public MinInt(int value)
            {
                Value = value;
            }

            public override string ToString() => Value.ToString();

            public MinInt Merge(MinInt other) => Value < other.Value ? this : other;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Updater : IMonoidWithAct<MinInt, Updater>, IEquatable<Updater>
        {
            public int Value { get; }

            public Updater Identity => new Updater(int.MaxValue);

            public Updater(int value)
            {
                Value = value;
            }

            public override string ToString() => Value.ToString();

            public MinInt Act(MinInt monoid) => new MinInt(Math.Min(monoid.Value, Value));

            public Updater Merge(Updater other) => Value < other.Value ? this : other;

            public override bool Equals(object obj)
            {
                return obj is Updater updater && Equals(updater);
            }

            public bool Equals(Updater other)
            {
                return Value == other.Value;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Value);
            }

            public static bool operator ==(Updater left, Updater right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Updater left, Updater right)
            {
                return !(left == right);
            }
        }
    }
}
