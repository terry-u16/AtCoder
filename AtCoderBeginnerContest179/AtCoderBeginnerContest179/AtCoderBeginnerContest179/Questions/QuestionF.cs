using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest179.Algorithms;
using AtCoderBeginnerContest179.Collections;
using AtCoderBeginnerContest179.Numerics;
using AtCoderBeginnerContest179.Questions;

namespace AtCoderBeginnerContest179.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();
            long total = (long)(n - 2) * (n - 2);

            var xSegTree = new LazySegmentTree<MinInt, Updater>(Enumerable.Repeat(new MinInt(n), n).ToArray());
            var ySegTree = new LazySegmentTree<MinInt, Updater>(Enumerable.Repeat(new MinInt(n), n).ToArray());

            for (int q = 0; q < queries; q++)
            {
                var kind = io.ReadInt();
                var position = io.ReadInt();

                if (kind == 1)
                {
                    var max = xSegTree.Query(position, position + 1).X;
                    total -= max - 2;
                    ySegTree.Update(0, max, new Updater(position));
                }
                else
                {
                    var max = ySegTree.Query(position, position + 1).X;
                    total -= max - 2;
                    xSegTree.Update(0, max, new Updater(position));
                }
            }

            io.WriteLine(total);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct MinInt : IMonoid<MinInt>
        {
            public int X { get; }

            public MinInt Identity => new MinInt(int.MaxValue);

            public MinInt(int x)
            {
                X = x;
            }

            public override string ToString() => $"{nameof(X)}: {X}";

            public MinInt Merge(MinInt other) => X < other.X ? this : other;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Updater : IMonoidWithAct<MinInt, Updater>, IEquatable<Updater>
        {
            public int X { get; }

            public Updater Identity => new Updater(int.MaxValue);

            public Updater(int x)
            {
                X = x;
            }

            public override string ToString() => X.ToString();

            public override bool Equals(object obj)
            {
                return obj is Updater updater && Equals(updater);
            }

            public bool Equals(Updater other)
            {
                return X == other.X;
            }

            public MinInt Act(MinInt monoid) => new MinInt(Math.Min(monoid.X, X));

            public Updater Merge(Updater other) => X < other.X ? this : other;
        }
    }
}
