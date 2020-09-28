using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACLBeginnerContest.Algorithms;
using ACLBeginnerContest.Collections;
using ACLBeginnerContest.Numerics;
using ACLBeginnerContest.Questions;
using AtCoder;
using AtCoder.Internal;
using ModInt = AtCoder.StaticModInt<AtCoder.Mod998244353>;

namespace ACLBeginnerContest.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        static ModInt[] pow10;
        static ModInt[] ones;

        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();
            pow10 = new ModInt[n + 1];
            pow10[0] = 1;
            ones = new ModInt[n + 1];
            ones[1] = 1;

            for (int i = 0; i + 1 < pow10.Length; i++)
            {
                pow10[i + 1] = pow10[i] * ModInt.Raw(10);
            }

            for (int i = 2; i < ones.Length; i++)
            {
                ones[i] = new ModInt((long)ones[i - 1].Value * 10 + 1);
            }

            var segtree = new LazySegmentTree<MonoidMod, Updater>(Enumerable.Repeat(new MonoidMod(1), n).ToArray());

            for (int q = 0; q < queries; q++)
            {
                var l = io.ReadInt() - 1;
                var r = io.ReadInt();
                var d = io.ReadString()[0] - '0';

                segtree.Update(l, r, new Updater(d));
                io.WriteLine(segtree.Query(0, segtree.Length).Value);
            }
        }

        readonly struct MonoidMod : IMonoid<MonoidMod>
        {
            public ModInt Value { get; }
            public int Length { get; }

            public MonoidMod Identity => new MonoidMod(new ModInt(), 0);

            public MonoidMod(ModInt value) : this(value, 1) { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MonoidMod(ModInt value, int length)
            {
                Value = value;
                Length = length;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MonoidMod Merge(MonoidMod other) => new MonoidMod(Value * pow10[other.Length] + other.Value, Length + other.Length);
            public override string ToString() => $"{Value}, {Length}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Updater : IMonoidWithAct<MonoidMod, Updater>, IEquatable<Updater>
        {
            public ModInt Value { get; }

            public Updater Identity => new Updater(0, int.MinValue);

            readonly int _generaton;
            static int Gen = 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Updater(ModInt value)
            {
                Value = value;
                _generaton = Gen++;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Updater(ModInt value, int generation)
            {
                Value = value;
                _generaton = generation;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MonoidMod Act(MonoidMod monoid)
            {
                return new MonoidMod(ones[monoid.Length] * Value, monoid.Length);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Updater Merge(Updater other) => _generaton > other._generaton ? this : other;

            public override bool Equals(object obj)
            {
                return obj is Updater updater && Equals(updater);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(Updater other)
            {
                return Value == other.Value &&
                       _generaton == other._generaton;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Value, _generaton);
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
