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
    public class QuestionM : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var m = io.ReadInt();
            var myMonsters = LoadMonsters(io, n);
            var helpMonsters = LoadMonsters(io, m);

            myMonsters.Sort();
            var maxPower = myMonsters.Reverse().Take(5).Sum(mo => mo.Power);

            var dp = Enumerable.Repeat(0, 6).Select(_ =>
            {
                var d = new int[maxPower + 1];
                d.Fill(1 << 29);
                return d;
            }).ToArray();

            dp[0][0] = 0;

            for (int i = 0; i < myMonsters.Length; i++)
            {
                for (int selected = dp.Length - 1; selected >= 1; selected--)
                {
                    var length = maxPower - myMonsters[i].Power + 1;
                    var current = dp[selected].AsSpan(myMonsters[i].Power, length);
                    var last = dp[selected - 1].AsSpan(0, length);

                    var toAdd = new Vector<int>(myMonsters[i].Weight);

                    int p;

                    for (p = 0; p + Vector<int>.Count <= current.Length; p += Vector<int>.Count)
                    {
                        var lastSpan = last.Slice(p);
                        var currentSpan = current.Slice(p);

                        var lastV = new Vector<int>(lastSpan);
                        var currentV = new Vector<int>(currentSpan);

                        var added = lastV + toAdd;
                        var comp = Vector.LessThan(added, currentV);
                        var result = Vector.ConditionalSelect(comp, added, currentV);
                        result.CopyTo(currentSpan);
                    }

                    if (p != current.Length)
                    {
                        for (; p < current.Length; p++)
                        {
                            current[p].ChangeMin(last[p] + myMonsters[i].Weight);
                        }
                    }
                }
            }

            double max = 0;

            for (int p = 1; p <= maxPower; p++)
            {
                max.ChangeMax((double)p / dp[5][p]);

                for (int i = 0; i < helpMonsters.Length; i++)
                {
                    var weight = dp[4][p] + helpMonsters[i].Weight;
                    var power = p + helpMonsters[i].Power;
                    max.ChangeMax((double)power / weight);
                }
            }

            io.WriteLine(max);
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
