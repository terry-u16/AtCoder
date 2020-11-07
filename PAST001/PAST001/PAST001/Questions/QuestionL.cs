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
using System.Runtime.Intrinsics.X86;
using System.Diagnostics.CodeAnalysis;

namespace PAST001.Questions
{
    public class QuestionL : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var largeTowerCount = io.ReadInt();
            var smallTowerCount = io.ReadInt();

            var towers = LoadTowers(io, largeTowerCount + smallTowerCount);

            double minCost = double.MaxValue;

            for (var flag = BitSet.Zero; flag < (1 << smallTowerCount); flag++)
            {
                var uf = new UnionFind(towers.Length);
                var queue = new PriorityQueue<Bridge>(false);

                for (int i = 0; i < towers.Length; i++)
                {
                    if (i >= largeTowerCount && !flag[i - largeTowerCount])
                    {
                        continue;
                    }

                    for (int j = i + 1; j < towers.Length; j++)
                    {
                        if (j >= largeTowerCount && !flag[j - largeTowerCount])
                        {
                            continue;
                        }

                        var cost = towers[i].GetDistanceFrom(towers[j]);
                        if (towers[i].Color != towers[j].Color)
                        {
                            cost *= 10;
                        }
                        queue.Enqueue(new Bridge(i, j, cost));
                    }
                }

                for (int i = largeTowerCount; i < towers.Length; i++)
                {
                    if (!flag[i - largeTowerCount])
                    {
                        uf.Unite(0, i);
                    }
                }

                double totalCost = 0;

                while (queue.Count > 0)
                {
                    var bridge = queue.Dequeue();

                    if (uf.Unite(bridge.From, bridge.To))
                    {
                        totalCost += bridge.Cost;
                    }
                }

                minCost.ChangeMin(totalCost);
            }

            io.WriteLine(minCost);
        }

        Tower[] LoadTowers(IOManager io, int count)
        {
            var towers = new Tower[count];

            for (int i = 0; i < towers.Length; i++)
            {
                var x = io.ReadInt() - 1;
                var y = io.ReadInt() - 1;
                var c = io.ReadInt() - 1;
                towers[i] = new Tower(x, y, c);
            }

            return towers;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Tower
        {
            public readonly int X;
            public readonly int Y;
            public readonly int Color;

            public Tower(int x, int y, int color)
            {
                X = x;
                Y = y;
                Color = color;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public double GetDistanceFrom(Tower other)
            {
                var dx = X - other.X;
                var dy = Y - other.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Color)}: {Color}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Bridge : IComparable<Bridge>
        {
            public readonly int From;
            public readonly int To;
            public readonly double Cost;

            public Bridge(int from, int to, double cost)
            {
                From = from;
                To = to;
                Cost = cost;
            }

            public int CompareTo([AllowNull] Bridge other) => Cost.CompareTo(other.Cost);

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(Cost)}: {Cost}";
        }
    }
}
