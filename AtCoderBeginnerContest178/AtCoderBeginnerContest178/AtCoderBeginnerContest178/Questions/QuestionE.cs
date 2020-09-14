using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest178.Algorithms;
using AtCoderBeginnerContest178.Collections;
using AtCoderBeginnerContest178.Extensions;
using AtCoderBeginnerContest178.Numerics;
using AtCoderBeginnerContest178.Questions;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderBeginnerContest178.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var coordinates = new Coordinate[n];

            for (int i = 0; i < coordinates.Length; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                coordinates[i] = new Coordinate(x, y);
            }

            Array.Sort(coordinates, (a, b) => (a.X + a.Y) - (b.X + b.Y));
            var max = Math.Abs(coordinates[0].X - coordinates[^1].X) + Math.Abs(coordinates[0].Y - coordinates[^1].Y);
            Array.Sort(coordinates, (a, b) => (a.X - a.Y) - (b.X - b.Y));
            max = Math.Max(max, Math.Abs(coordinates[0].X - coordinates[^1].X) + Math.Abs(coordinates[0].Y - coordinates[^1].Y));

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Coordinate : IComparable<Coordinate>
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

            public int CompareTo([AllowNull] Coordinate other)
            {
                var comp = X - other.X;
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return Y - other.Y;
                }
            }
        }
    }
}
