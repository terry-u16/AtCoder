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
using Training20201016.Algorithms;
using Training20201016.Collections;
using Training20201016.Numerics;
using Training20201016.Questions;

namespace Training20201016.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const double Inf = 1e10;
            var n = io.ReadInt();
            var l = io.ReadInt();
            var cars = new Car[n + 2];

            cars[0] = new Car(0, io.ReadInt(), io.ReadInt());

            for (int i = 1; i <= n; i++)
            {
                cars[i] = new Car(io.ReadInt(), io.ReadInt(), io.ReadInt());
            }

            cars[^1] = new Car(l, 0, 0);

            Array.Sort(cars, (a, b) => a.X - b.X);

            var dp = new double[cars.Length];
            dp.AsSpan().Fill(Inf);
            dp[0] = 0;

            for (int current = 1; current < cars.Length; current++)
            {
                var x = cars[current].X;

                for (int last = 0; last < current; last++)
                {
                    var distance = x - cars[last].X;
                    if (distance <= cars[last].D)
                    {
                        dp[current].ChangeMin(dp[last] + (double)distance / cars[last].V);
                    }
                }
            }

            if (dp[^1] < Inf)
            {
                io.WriteLine(dp[^1].ToString("f15"));
            }
            else
            {
                io.WriteLine("impossible");
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Car
        {
            public readonly int X;
            public readonly int V;
            public readonly int D;

            public Car(int x, int v, int d)
            {
                X = x;
                V = v;
                D = d;
            }

            public override string ToString() => $"{nameof(X)}: {X}, {nameof(V)}: {V}, {nameof(D)}: {D}";
        }
    }
}
