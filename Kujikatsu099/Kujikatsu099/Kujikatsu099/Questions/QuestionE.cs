using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu099.Algorithms;
using Kujikatsu099.Collections;
using Kujikatsu099.Numerics;
using Kujikatsu099.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu099.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc153/tasks/abc153_f
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var d = io.ReadInt();
            var attack = io.ReadInt();
            var range = 2 * d + 1;

            var monsters = new Monster[n];

            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i] = new Monster(io.ReadInt(), io.ReadInt());
            }

            Array.Sort(monsters);

            var currentDamage = 0;
            var events = new Queue<Event>();
            long count = 0;

            foreach (var monster in monsters)
            {
                while (events.Count > 0 && events.Peek().X <= monster.X)
                {
                    currentDamage += events.Dequeue().Diff;
                }

                var diff = monster.HP - currentDamage;

                if (diff > 0)
                {
                    var c = (diff + attack - 1) / attack;
                    count += c;
                    currentDamage += c * attack;
                    events.Enqueue(new Event(monster.X + range, -c * attack));
                }
            }

            io.WriteLine(count);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Monster : IComparable<Monster>
        {
            public int X { get; }
            public int HP { get; }

            public Monster(int x, int hp)
            {
                X = x;
                HP = hp;
            }

            public void Deconstruct(out int x, out int hp) => (x, hp) = (X, HP);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(HP)}: {HP}";

            public int CompareTo([AllowNull] Monster other) => X - other.X;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Event
        {
            public int X { get; }
            public int Diff { get; }

            public Event(int x, int diff)
            {
                X = x;
                Diff = diff;
            }

            public void Deconstruct(out int x, out int diff) => (x, diff) = (X, Diff);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Diff)}: {Diff}";
        }
    }
}
