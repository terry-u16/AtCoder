using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200627.Algorithms;
using Training20200627.Collections;
using Training20200627.Extensions;
using Training20200627.Numerics;
using Training20200627.Questions;

namespace Training20200627.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = LoadPositions(inputStream, n);
            var b = LoadPositions(inputStream, n);

            var scaleA = GetDistanceFromCenter(a);
            var scaleB = GetDistanceFromCenter(b);
            yield return scaleB / scaleA;
        }

        private Position[] LoadPositions(TextReader inputStream, int n)
        {
            var a = new Position[n];
            for (int i = 0; i < n; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                a[i] = new Position(x, y);
            }

            return a;
        }

        private double GetDistanceFromCenter(Position[] a)
        {
            var gx = 0.0;
            var gy = 0.0;
            foreach (var ai in a)
            {
                gx += ai.X;
                gy += ai.Y;
            }

            var center = new Position(gx / a.Length, gy / a.Length);
            return a.Max(ai => ai.GetDistanceTo(center));
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Position
        {
            public double X { get; }
            public double Y { get; }

            public Position(double x, double y)
            {
                X = x;
                Y = y;
            }

            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

            public double GetDistanceTo(Position other) => Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
        }
    }
}
