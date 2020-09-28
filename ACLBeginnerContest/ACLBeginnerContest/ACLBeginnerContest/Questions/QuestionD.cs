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

namespace ACLBeginnerContest.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadInt();
            var a = new int[n];
            var segTree = new SegmentTree<MaxInt>(Enumerable.Repeat(new MaxInt(0), 300001).ToArray());

            for (int i = 0; i < a.Length; i++)
            {
                var ai = io.ReadInt();
                var left = System.Math.Max(0, ai - k);
                var right = System.Math.Min(segTree.Length, ai + k + 1);
                segTree[ai] = new MaxInt(segTree.Query(left, right).Value + 1);
            }

            io.WriteLine(segTree.Query(0, segTree.Length).Value);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct MaxInt : IMonoid<MaxInt>
        {
            public int Value { get; }

            public MaxInt Identity => new MaxInt(int.MinValue);

            public MaxInt(int value)
            {
                Value = value;
            }

            public override string ToString() => $"{nameof(Value)}: {Value}";

            public MaxInt Merge(MaxInt other) => Value > other.Value ? this : other;
        }
    }
}
