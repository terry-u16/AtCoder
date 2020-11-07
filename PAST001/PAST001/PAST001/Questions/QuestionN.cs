using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;
using System.Diagnostics.CodeAnalysis;

namespace PAST001.Questions
{
    public class QuestionN : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const long Inf = 1L << 60;
            var n = io.ReadInt();
            var width = io.ReadInt();
            var carWidth = io.ReadInt();

            var rightQueue = new PriorityQueue<Stone>(false);
            var leftQueue = new PriorityQueue<LeftStone>(false);

            for (int i = 0; i < n; i++)
            {
                rightQueue.Enqueue(new Stone(io.ReadInt(), io.ReadInt(), io.ReadInt()));
            }

            rightQueue.Enqueue(new Stone(width, width, Inf));
            leftQueue.Enqueue(new LeftStone(0, Inf));

            long currentCost = Inf;
            long minCost = Inf;

            while (rightQueue.Count > 0)
            {
                var next = rightQueue.Dequeue();
                var x = next.L;

                while (leftQueue.Count > 0 && leftQueue.Peek().R <= x - carWidth)
                {
                    currentCost -= leftQueue.Dequeue().Cost;
                }

                minCost.ChangeMin(currentCost);

                currentCost += next.Cost;
                leftQueue.Enqueue(new LeftStone(next.R, next.Cost));
            }

            io.WriteLine(minCost);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Stone : IComparable<Stone>
        {
            public readonly int L;
            public readonly int R;
            public readonly long Cost;

            public Stone(int l, int r, long cost)
            {
                L = l;
                R = r;
                Cost = cost;
            }

            public int CompareTo([AllowNull] Stone other) => L.CompareTo(other.L);

            public override string ToString() => $"{nameof(L)}: {L}, {nameof(R)}: {R}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct LeftStone : IComparable<LeftStone>
        {
            public readonly int R;
            public readonly long Cost;

            public LeftStone(int r, long cost)
            {
                R = r;
                Cost = cost;
            }

            public int CompareTo([AllowNull] LeftStone other) => R.CompareTo(other.R);

            public void Deconstruct(out int r, out long cost) => (r, cost) = (R, Cost);
            public override string ToString() => $"{nameof(R)}: {R}, {nameof(Cost)}: {Cost}";
        }
    }
}
