using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc057/tasks/abc057_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (studentCount, checkPointCount) = inputStream.ReadValue<int, int>();
            var students = new Coordinate[studentCount];
            var checkPoints = new Coordinate[checkPointCount];

            for (int i = 0; i < students.Length; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                students[i] = new Coordinate(a, b);
            }

            for (int i = 0; i < checkPoints.Length; i++)
            {
                var (c, d) = inputStream.ReadValue<int, int>();
                checkPoints[i] = new Coordinate(c, d);
            }

            for (int i = 0; i < students.Length; i++)
            {
                var min = int.MaxValue;
                var result = 0;
                for (int j = 0; j < checkPoints.Length; j++)
                {
                    var d = students[i].GetDistanceTo(checkPoints[j]);
                    if (min > d)
                    {
                        min = d;
                        result = j + 1;
                    }
                }

                yield return result;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Coordinate
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int GetDistanceTo(Coordinate other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
