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

namespace Training20201009.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();
            var a = new MaxInt[n];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new MaxInt(io.ReadInt());
            }

            var segtree = new LazySegmentTree<MaxInt, Nothing>(a);
            
            for (int q = 0; q < queries; q++)
            {
                var type = io.ReadInt();

                if (type == 1)
                {
                    var i = io.ReadInt() - 1;
                    var v = io.ReadInt();
                    segtree[i] = new MaxInt(v);
                }
                else if (type == 2)
                {
                    var l = io.ReadInt() - 1;
                    var r = io.ReadInt();
                    io.WriteLine(segtree.Query(l, r).Value);
                }
                else
                {
                    var l = io.ReadInt() - 1;
                    var v = io.ReadInt();
                    io.WriteLine(Math.Max(l, segtree.FindMaxRight(l, ai => ai.Value < v)) + 1);
                }
            }
        }

        readonly struct MaxInt : IMonoid<MaxInt>
        {
            public int Value { get; }

            public MaxInt Identity => new MaxInt(int.MinValue);

            public MaxInt(int value)
            {
                Value = value;
            }

            public MaxInt Merge(MaxInt other) => new MaxInt(Math.Max(Value, other.Value));
        }

        readonly struct Nothing : IMonoidWithAct<MaxInt, Nothing>
        {
            public Nothing Identity => new Nothing();

            public MaxInt Act(MaxInt monoid) => monoid;

            public Nothing Merge(Nothing other) => new Nothing();
        }
    }
}
