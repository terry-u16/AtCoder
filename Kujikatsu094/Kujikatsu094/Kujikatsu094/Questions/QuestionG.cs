using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;
using System.Runtime.Intrinsics.X86;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/m-solutions2020/tasks/m_solutions2020_e
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var villages = new Village[n];

            for (int i = 0; i < villages.Length; i++)
            {
                var (x, y, p) = inputStream.ReadValue<int, int, int>();
                villages[i] = new Village(x, y, p);
            }

            var xCosts = new long[1 << villages.Length, villages.Length];
            var yCosts = new long[1 << villages.Length, villages.Length];

            for (var flags = BitSet.Zero; flags < 1 << villages.Length; flags++)
            {
                for (int i = 0; i < villages.Length; i++)
                {
                    var minX = villages[i].WalkX(0);
                    var minY = villages[i].WalkY(0);

                    for (int road = 0; road < villages.Length; road++)
                    {
                        if (flags[road])
                        {
                            minX = Math.Min(minX, villages[i].WalkX(villages[road].X));
                            minY = Math.Min(minY, villages[i].WalkY(villages[road].Y));
                        }
                    }

                    xCosts[flags, i] += minX;
                    yCosts[flags, i] += minY;
                }
            }

            var results = new long[villages.Length + 1];
            results.AsSpan().Fill(long.MaxValue);

            DFS(0, 0, 0);

            foreach (var result in results)
            {
                yield return result;
            }

            void DFS(int xFlags, int yFlags, int depth)
            {
                if (depth == villages.Length)
                {
                    long cost = 0;
                    for (int i = 0; i < villages.Length; i++)
                    {
                        var xCost = xCosts[xFlags, i];
                        var yCost = yCosts[yFlags, i];
                        cost += Math.Min(xCost, yCost);
                    }

                    var construction = Popcnt.PopCount((uint)xFlags) + Popcnt.PopCount((uint)yFlags);
                    results[construction] = Math.Min(results[construction], cost);
                }
                else
                {
                    DFS(xFlags, yFlags, depth + 1);
                    DFS(xFlags | (1 << depth), yFlags, depth + 1);
                    DFS(xFlags, yFlags | (1 << depth), depth + 1);
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Village
        {
            public int X { get; }
            public int Y { get; }
            public int Population { get; }

            public Village(int x, int y, int population)
            {
                X = x;
                Y = y;
                Population = population;
            }

            public long WalkX(int x) => (long)Population * Math.Abs(X - x);
            public long WalkY(int y) => (long)Population * Math.Abs(Y - y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Population)}: {Population}";
        }
    }
}
