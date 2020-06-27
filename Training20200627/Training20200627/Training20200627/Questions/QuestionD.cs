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
    /// <summary>
    /// https://atcoder.jp/contests/arc023/tasks/arc023_3
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var unreadables = new List<Unreadable>();
            var last = 0;
            var streak = 0;
            foreach (var ai in a)
            {
                if (ai == -1)
                {
                    streak++;
                }
                else
                {
                    if (streak > 0)
                    {
                        unreadables.Add(new Unreadable(ai - last, streak));
                    }
                    last = ai;
                    streak = 0;
                }
            }

            var count = Modular.One;

            foreach (var unreadable in unreadables)
            {
                var begin = unreadable.Diff + 1 + unreadable.Length - 1;
                for (int i = 0; i < unreadable.Length; i++)
                {
                    count *= new Modular(begin - i) / new Modular(i + 1);
                }
            }

            yield return count.Value;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Unreadable
        {
            public int Diff { get; }
            public int Length { get; }

            public Unreadable(int diff, int length)
            {
                Diff = diff;
                Length = length;
            }

            public override string ToString() => $"{nameof(Diff)}: {Diff}, {nameof(Length)}: {Length}";
        }
    }
}
