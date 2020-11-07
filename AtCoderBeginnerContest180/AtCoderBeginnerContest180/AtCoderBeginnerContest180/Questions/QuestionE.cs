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
using AtCoderBeginnerContest180.Algorithms;
using AtCoderBeginnerContest180.Collections;
using AtCoderBeginnerContest180.Numerics;
using AtCoderBeginnerContest180.Questions;

namespace AtCoderBeginnerContest180.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const int Inf = 1 << 28;
            var n = io.ReadInt();
            var towns = new Town[n];

            for (int i = 0; i < towns.Length; i++)
            {
                towns[i] = new Town(io.ReadInt(), io.ReadInt(), io.ReadInt());
            }

            var dp = new int[1 << n, n];
            dp.Fill(Inf);
            dp[1, 0] = 0;

            for (var flags = BitSet.One; flags < (1 << n); flags++, flags++)
            {
                for (int last = 0; last < towns.Length; last++)
                {
                    if (flags[last])
                    {
                        for (int next = 0; next < towns.Length; next++)
                        {
                            dp[flags | (1u << next), next].ChangeMin(dp[flags, last] + towns[last].GetDistanceTo(towns[next]));
                        }
                    }
                }
            }

            var min = Inf;

            for (int i = 1; i < towns.Length; i++)
            {
                min.ChangeMin(dp[(1 << towns.Length) - 1, i] + towns[i].GetDistanceTo(towns[0]));
            }

            io.WriteLine(min);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Town
        {
            public readonly int X;
            public readonly int Y;
            public readonly int Z;

            public Town(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetDistanceTo(Town other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Max(0, other.Z - Z);

            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(X)}: {X}";
        }
    }
}
