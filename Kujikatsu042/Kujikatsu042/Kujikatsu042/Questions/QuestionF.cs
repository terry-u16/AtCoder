using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu042.Algorithms;
using Kujikatsu042.Collections;
using Kujikatsu042.Extensions;
using Kujikatsu042.Numerics;
using Kujikatsu042.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu042.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc094/tasks/arc094_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var pairs = new Pair[n];
            for (int i = 0; i < pairs.Length; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                pairs[i] = new Pair(u, v);
            }

            Array.Sort(pairs);
            var toZero = new bool[n];
            long operations = 0;
            long result = 0;

            for (int i = 0; i < pairs.Length; i++)
            {
                var pair = pairs[i];
                if (pair.A < pair.B)
                {
                    operations += pair.B - pair.A;
                    toZero[i] = true;
                    result += pair.B;
                }
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                var pair = pairs[i];
                if (!toZero[i] && pair.A - pair.B < operations)
                {
                    operations -= pair.A - pair.B;
                    toZero[i] = true;
                    result += pair.B;
                }
            }

            yield return result;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Pair : IComparable<Pair>
        {
            public int A { get; }
            public int B { get; }

            public Pair(int a, int b)
            {
                A = a;
                B = b;
            }

            public void Deconstruct(out int a, out int b) => (a, b) = (A, B);
            public override string ToString() => $"{nameof(A)}: {A}, {nameof(B)}: {B}";

            public int CompareTo([AllowNull] Pair other) => other.B - B;
        }
    }
}
