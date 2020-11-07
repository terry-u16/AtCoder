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
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;
using System.Diagnostics.CodeAnalysis;

namespace PAST001.Questions
{
    public class QuestionM2 : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var m = io.ReadInt();
            var myMonsters = LoadMonsters(io, n);
            var helpMonsters = LoadMonsters(io, m);

            var mines = new double[myMonsters.Length];
            var helpers = new double[helpMonsters.Length];

            var result = BoundaryBinarySearch(Fusionable, 0, 1e6, 1e-7);

            io.WriteLine(result);

            bool Fusionable(double targetPower)
            {
                for (int i = 0; i < myMonsters.Length; i++)
                {
                    mines[i] = myMonsters[i].Power - myMonsters[i].Weight * targetPower;
                }

                for (int i = 0; i < helpMonsters.Length; i++)
                {
                    helpers[i] = helpMonsters[i].Power - helpMonsters[i].Weight * targetPower;
                }

                mines.Sort((a, b) => b.CompareTo(a));

                var current = 0.0;

                for (int i = 0; i < 4; i++)
                {
                    current += mines[i];
                }

                if (current + mines[4] >= 0)
                {
                    return true;
                }
                else
                {
                    for (int i = 0; i < helpers.Length; i++)
                    {
                        if (current + helpers[i] >= 0)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public static double BoundaryBinarySearch(Predicate<double> predicate, double ok, double ng, double eps)
        {
            // めぐる式二分探索
            while (Math.Abs(ok - ng) > eps)
            {
                var mid = (ok + ng) / 2;
                if (predicate(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }

        private static Monster[] LoadMonsters(IOManager io, int n)
        {
            var monsters = new Monster[n];

            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i] = new Monster(io.ReadInt(), io.ReadInt());
            }

            return monsters;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Monster : IComparable<Monster>
        {
            public readonly int Weight;
            public readonly int Power;

            public Monster(int weight, int power)
            {
                Weight = weight;
                Power = power;
            }

            public int CompareTo([AllowNull] Monster other) => Power - other.Power;

            public void Deconstruct(out int weight, out int power) => (weight, power) = (Weight, Power);
            public override string ToString() => $"{nameof(Weight)}: {Weight}, {nameof(Power)}: {Power}";
        }
    }
}
