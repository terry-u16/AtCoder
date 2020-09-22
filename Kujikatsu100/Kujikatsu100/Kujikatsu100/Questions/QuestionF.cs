using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu100.Algorithms;
using Kujikatsu100.Collections;
using Kujikatsu100.Numerics;
using Kujikatsu100.Questions;

namespace Kujikatsu100.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc069/tasks/arc069_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);

            var valueAndIndice = GetMaxes(a);
            var counts = new long[valueAndIndice.Length];
            var over = new long[valueAndIndice.Length];
            var current = valueAndIndice.Length - 1;
            var results = new long[n];

            for (int i = a.Length - 1; i >= 0; i--)
            {
                var toInsert = SearchExtensions.BoundaryBinarySearch(idx => a[i] <= valueAndIndice[idx].Value, valueAndIndice.Length, -1);
                counts[toInsert]++;
                over[toInsert] += a[i] - valueAndIndice[toInsert].Value;

                if (valueAndIndice[current].Index == i)
                {
                    long diff = valueAndIndice[current].Value - valueAndIndice[current - 1].Value;
                    results[i] = diff * counts[current] + over[current];
                    counts[current - 1] += counts[current];
                    current--;
                }
            }

            foreach (var result in results)
            {
                io.WriteLine(result);
            }
        }

        ValueAndIndex[] GetMaxes(int[] a)
        {
            var result = new List<ValueAndIndex>();
            result.Add(new ValueAndIndex(0, -1));

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > result[^1].Value)
                {
                    result.Add(new ValueAndIndex(a[i], i));
                }
            }

            return result.ToArray();
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct ValueAndIndex
        {
            public int Value { get; }
            public int Index { get; }

            public ValueAndIndex(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public void Deconstruct(out int value, out int index) => (value, index) = (Value, Index);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Index)}: {Index}";
        }
    }
}
