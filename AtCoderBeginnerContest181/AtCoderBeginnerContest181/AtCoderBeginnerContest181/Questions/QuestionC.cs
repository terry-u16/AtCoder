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
using System.Diagnostics.CodeAnalysis;

namespace AtCoderBeginnerContest181.Questions
{
    public class QuestionC : AtCoderQuestionBase
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

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        var dx1 = points[i].X - points[j].X;
                        var dx2 = points[i].X - points[k].X;
                        var dy1 = points[i].Y - points[j].Y;
                        var dy2 = points[i].Y - points[k].Y;

                        if (dx2 * dy1 == dx1 * dy2)
                        {
                            io.WriteLine("Yes");
                            return;
                        }
                    }
                }
            }

            io.WriteLine("No");
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Point : IComparable<Point>
        {
            public readonly int X;
            public readonly int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int CompareTo([AllowNull] Point other) => X - other.X;

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
