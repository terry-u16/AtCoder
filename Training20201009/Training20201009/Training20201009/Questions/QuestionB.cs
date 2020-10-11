using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201009.Algorithms;
using Training20201009.Collections;
using Training20201009.Numerics;
using Training20201009.Questions;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using AtCoder.Internal;
using ModInt = AtCoder.StaticModInt<AtCoder.Mod998244353>;

namespace Training20201009.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();
            var a = new SumModInt[n];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new SumModInt(ModInt.Raw(io.ReadInt()), 1);
            }

            var segtree = new LazySegmentTree<SumModInt, AffineActor>(a);

            for (int q = 0; q < queries; q++)
            {
                var kind = io.ReadInt();
                var l = io.ReadInt();
                var r = io.ReadInt();

                if (kind == 0)
                {
                    var b = ModInt.Raw(io.ReadInt());
                    var c = ModInt.Raw(io.ReadInt());
                    segtree.Apply(l..r, new AffineActor(b, c));
                }
                else
                {
                    io.WriteLine(segtree.Query(l..r).Value);
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct SumModInt : IMonoid<SumModInt>
        {
            public readonly ModInt Value;
            public readonly int Length;

            public SumModInt Identity => new SumModInt(default, 0);

            public SumModInt(ModInt value, int length)
            {
                Value = value;
                Length = length;
            }

            public SumModInt Merge(SumModInt other) => new SumModInt(Value + other.Value, Length + other.Length);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct AffineActor : IMonoidWithAct<SumModInt, AffineActor>
        {
            public readonly ModInt B;
            public readonly ModInt C;

            public AffineActor Identity => new AffineActor(ModInt.Raw(1), new ModInt());

            public AffineActor(ModInt b, ModInt c)
            {
                B = b;
                C = c;
            }

            public void Deconstruct(out ModInt b, out ModInt c) => (b, c) = (B, C);
            public override string ToString() => $"{nameof(B)}: {B}, {nameof(C)}: {C}";

            public SumModInt Act(SumModInt monoid) => new SumModInt(monoid.Value * B + ModInt.Raw(monoid.Length) * C, monoid.Length);

            public AffineActor Merge(AffineActor other) => new AffineActor(B * other.B, other.C * B + C);
        }
    }
}

