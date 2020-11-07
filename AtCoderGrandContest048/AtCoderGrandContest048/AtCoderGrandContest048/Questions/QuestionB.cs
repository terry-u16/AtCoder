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
using System.Runtime.Intrinsics.X86;
using AtCoderGrandContest048.Algorithms;
using AtCoderGrandContest048.Collections;
using AtCoderGrandContest048.Numerics;
using AtCoderGrandContest048.Questions;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderGrandContest048.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var b = io.ReadIntArray(n);

            var odds = new DiffAndB[a.Length / 2];
            var evens = new DiffAndB[a.Length / 2];

            for (int i = 0; i < odds.Length; i++)
            {
                evens[i] = new DiffAndB(a[2 * i] - b[2 * i], b[2 * i]);
                odds[i] = new DiffAndB(a[2 * i + 1] - b[2 * i + 1], b[2 * i + 1]);
            }

            odds.Sort();
            evens.Sort();

            long result = 0;

            for (int i = 0; i < odds.Length; i++)
            {
                long sum = evens[i].Diff + odds[i].Diff;
                long addB = evens[i].B + odds[i].B;

                if (sum > 0)
                {
                    result += sum + addB;
                }
                else
                {
                    result += addB;
                }
            }

            io.WriteLine(result);
        }


        [StructLayout(LayoutKind.Auto)]
        readonly struct DiffAndB : IComparable<DiffAndB>
        {
            public readonly int Diff;
            public readonly int B;

            public DiffAndB(int diff, int b)
            {
                Diff = diff;
                B = b;
            }

            public int CompareTo([AllowNull] DiffAndB other) => Diff.CompareTo(other.Diff);

            public void Deconstruct(out int diff, out int b) => (diff, b) = (Diff, B);
            public override string ToString() => $"{nameof(Diff)}: {Diff}, {nameof(B)}: {B}";
        }
    }
}
