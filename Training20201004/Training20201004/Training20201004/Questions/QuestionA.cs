using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201004.Algorithms;
using Training20201004.Collections;
using Training20201004.Numerics;
using Training20201004.Questions;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AtCoder;
using AtCoder.Internal;

namespace Training20201004.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc104/editorial/158
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var stairs = 2 * n;

            var events = new Event[stairs];
            events.AsSpan().Fill(new Event(-1, Direction.None));
            var people = new Person[n];

            for (int i = 0; i < people.Length; i++)
            {
                var a = io.ReadInt();
                var b = io.ReadInt();

                people[i] = new Person(a, b);

                a--;
                b--;

                if (a >= 0)
                {
                    if (events[a].Direction != Direction.None)
                    {
                        io.WriteLine("No");
                        return;
                    }
                    events[a] = new Event(i, Direction.GetOn);
                }

                if (b >= 0)
                {
                    if (events[b].Direction != Direction.None)
                    {
                        io.WriteLine("No");
                        return;
                    }
                    events[b] = new Event(i, Direction.GetOff);
                }
            }

            var dp = new bool[stairs + 1];
            dp[0] = true;

            for (int stair = 1; stair <= stairs; stair++)
            {
                for (int last = 0; last < stair && !dp[stair]; last++)
                {
                    var length = stair - last;
                    if (dp[last] && (length & 1) == 0)
                    {
                        var halfLength = length >> 1;
                        var ok = true;

                        for (int j = 0; j < halfLength && ok; j++)
                        {
                            var getOn = last + j;
                            var getOff = getOn + halfLength;

                            ok &= events[getOn].Direction != Direction.GetOff;
                            ok &= events[getOff].Direction != Direction.GetOn;

                            if (events[getOn].ID != -1 && events[getOff].ID != -1)
                            {
                                ok &= events[getOn].ID == events[getOff].ID;
                            }

                            if (events[getOn].ID == -1 && events[getOff].ID != -1)
                            {
                                ok &= people[events[getOff].ID].GetOn == -1;
                            }

                            if (events[getOn].ID != -1 && events[getOff].ID == -1)
                            {
                                ok &= people[events[getOn].ID].GetOff == -1;
                            }
                        }

                        if (ok)
                        {
                            dp[stair] = true;
                            break;
                        }
                    }
                }
            }

            io.WriteLine(dp[stairs] ? "Yes" : "No");
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Person
        {
            public int GetOn { get; }
            public int GetOff { get; }

            public Person(int getOn, int getOff)
            {
                GetOn = getOn != -1 ? getOn - 1 : -1;
                GetOff = getOff != -1 ? getOff - 1 : -1;
            }

            public void Deconstruct(out int getOn, out int getOff) => (getOn, getOff) = (GetOn, GetOff);
            public override string ToString() => $"{nameof(GetOn)}: {GetOn}, {nameof(GetOff)}: {GetOff}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Event
        {
            public int ID { get; }
            public Direction Direction { get; }

            public Event(int id, Direction direction)
            {
                ID = id;
                Direction = direction;
            }

            public void Deconstruct(out int id, out Direction direction) => (id, direction) = (ID, Direction);
            public override string ToString() => $"{nameof(ID)}: {ID}, {nameof(Direction)}: {Direction}";
        }

        enum Direction
        {
            None,
            GetOn,
            GetOff
        }
    }
}
