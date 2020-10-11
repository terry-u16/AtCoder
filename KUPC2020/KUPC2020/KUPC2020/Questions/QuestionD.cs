using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KUPC2020.Algorithms;
using KUPC2020.Collections;
using KUPC2020.Numerics;
using KUPC2020.Questions;
using System.Diagnostics.CodeAnalysis;

namespace KUPC2020.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();

            long totalLength = 0;
            var sticks = new int[n];
            var maxLength = 2 * n - 1;

            for (int i = 0; i < sticks.Length; i++)
            {
                sticks[i] = 2 * i + 1;
                totalLength += sticks[i];
            }

            var rbtree = new RedBlackTree<Stick>();

            if (n % 2 == 0 && n >= 4)
            {
                io.WriteLine(n / 2);

                var left = 0;
                var right = n - 1;

                for (int i = 0; i < n / 2; i++)
                {
                    io.WriteLine($"2 {sticks[left++]} {sticks[right--]}");
                }
                return;
            }

            foreach (var div in Divisiors.GetDivisiors(totalLength))
            {
                var eachLength = totalLength / div;
                
                if (div == 1 || eachLength < maxLength || sticks.Length % div != 0)
                {
                    continue;
                }

                var groupCount = sticks.Length / div;
                var lengths = new long[div];
                var shift = 0;
                var results = Enumerable.Repeat(0, (int)div).Select(_ => new List<int>()).ToArray();

                for (int group = 0; group < groupCount; group++)
                {
                    for (int i = 0; i < lengths.Length; i++)
                    {
                        var next = sticks[group * lengths.Length + i];
                        var index = (i + shift) % lengths.Length;
                        lengths[index] += next;
                        results[index].Add(next);
                    }

                    shift++;
                }

                if (lengths.All(l => l == lengths[0]))
                {
                    io.WriteLine(results.Length);

                    for (int i = 0; i < results.Length; i++)
                    {
                        var line = new int[results[i].Count + 1];
                        line[0] = results[i].Count;
                        results[i].CopyTo(line, 1);
                        io.WriteLine(line, ' ');
                    }

                    return;
                }
            }

            io.WriteLine("impossible");
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Stick : IComparable<Stick>
        {
            public readonly long Remain;
            public readonly int Index;

            public Stick(long remain, int index)
            {
                Remain = remain;
                Index = index;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CompareTo([AllowNull] Stick other)
            {
                var comp = Remain - other.Remain;
                if (comp != 0)
                {
                    return Math.Sign(comp);
                }
                else
                {
                    return Index - other.Index;
                }
            }

            public void Deconstruct(out long remain, out int index) => (remain, index) = (Remain, Index);
            public override string ToString() => $"{nameof(Remain)}: {Remain}, {nameof(Index)}: {Index}";
        }
    }
}
