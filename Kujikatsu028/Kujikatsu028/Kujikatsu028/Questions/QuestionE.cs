using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu028.Algorithms;
using Kujikatsu028.Collections;
using Kujikatsu028.Extensions;
using Kujikatsu028.Numerics;
using Kujikatsu028.Questions;

namespace Kujikatsu028.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc075/tasks/abc075_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var points = ReadInput(inputStream, n);
            var candidatesX = points.Select(p => p.X).OrderBy(x => x).ToArray();
            var candidatesY = points.Select(p => p.Y).OrderBy(y => y).ToArray();

            var min = long.MaxValue;

            for (int beginXIndex = 0; beginXIndex < candidatesX.Length; beginXIndex++)
            {
                var beginX = candidatesX[beginXIndex];
                for (int endXIndex = beginXIndex + 1; endXIndex < candidatesX.Length; endXIndex++)
                {
                    var endX = candidatesX[endXIndex];
                    for (int beginYIndex = 0; beginYIndex < candidatesY.Length; beginYIndex++)
                    {
                        var beginY = candidatesY[beginYIndex];
                        for (int endYIndex = beginYIndex + 1; endYIndex < candidatesY.Length; endYIndex++)
                        {
                            var endY = candidatesY[endYIndex];
                            var contained = 0;
                            foreach (var point in points)
                            {
                                if (beginX <= point.X && point.X <= endX && beginY <= point.Y && point.Y <= endY)
                                {
                                    contained++;
                                }
                            }

                            if (contained >= k)
                            {
                                min = Math.Min(min, (long)(endX - beginX) * (endY - beginY));
                            }
                        }
                    }
                }
            }

            yield return min;
        }

        private Point[] ReadInput(TextReader inputStream, int n)
        {
            var points = new Point[n];

            foreach (ref var point in points.AsSpan())
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                point = new Point(x, y);
            }

            return points;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
