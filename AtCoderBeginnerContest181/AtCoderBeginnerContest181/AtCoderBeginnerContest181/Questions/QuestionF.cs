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
using System.Runtime.Intrinsics.X86;
using AtCoderBeginnerContest181.Algorithms;
using AtCoderBeginnerContest181.Collections;
using AtCoderBeginnerContest181.Numerics;
using AtCoderBeginnerContest181.Questions;

namespace AtCoderBeginnerContest181.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();

            var points = new Point[n];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(io.ReadInt(), io.ReadInt());
            }

            var pairs = new List<(int a, int b, double d)>();

            for (int i = 0; i < points.Length; i++)
            {
                pairs.Add((n, i, 100 - points[i].Y));
                pairs.Add((n + 1, i, points[i].Y + 100));

                for (int j = i + 1; j < points.Length; j++)
                {
                    pairs.Add((i, j, points[i].GetDistanceTo(points[j])));
                }
            }

            pairs.Sort((p, q) => p.d.CompareTo(q.d));

            var uf = new UnionFind(n + 2);

            foreach (var (a, b, d) in pairs.AsSpan())
            {
                uf.Unite(a, b);
                if (uf.IsInSameGroup(n, n + 1))
                {
                    io.WriteLine(d / 2);
                    return;
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Point
        {
            public readonly int X;
            public readonly int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public double GetDistanceTo(Point p)
            {
                var dx = X - p.X;
                var dy = Y - p.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
