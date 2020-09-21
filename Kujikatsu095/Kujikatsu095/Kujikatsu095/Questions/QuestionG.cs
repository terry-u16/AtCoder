using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu095.Algorithms;
using Kujikatsu095.Collections;
using Kujikatsu095.Extensions;
using Kujikatsu095.Numerics;
using Kujikatsu095.Questions;
using System.Diagnostics;

namespace Kujikatsu095.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc021/tasks/agc021_b
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const double R = 1e15;
            const double RSquared = R * R;
            var sw = new Stopwatch();
            sw.Start();

            var n = inputStream.ReadInt();
            var points = new Point[n];

            for (int i = 0; i < points.Length; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                points[i] = new Point(x, y);
            }

            var counts = new int[n];
            var countSum = 0;
            var rand = new XorShift();


            while (sw.ElapsedMilliseconds < 1850)
            {
                var min = double.MaxValue;
                var index = -1;

                unchecked
                {
                    var x = rand.NextDouble() * 2 * R - R;
                    var y = rand.NextDouble() * 2 * R - R;

                    if (x * x + y * y <= RSquared)
                    {
                        for (int i = 0; i < points.Length; i++)
                        {
                            var dist = points[i].GetDistanceSquared(x, y);
                            if (dist < min)
                            {
                                index = i;
                                min = dist;
                            }
                        }

                        counts[index]++;
                        countSum++;
                    }
                }
            }

            foreach (var c in counts)
            {
                yield return (double)c / countSum;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double GetDistanceSquared(double x, double y) => X * x + Y * y;
            public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
