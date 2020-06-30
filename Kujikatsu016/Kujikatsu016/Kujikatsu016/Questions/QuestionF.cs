using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu016.Algorithms;
using Kujikatsu016.Collections;
using Kujikatsu016.Extensions;
using Kujikatsu016.Numerics;
using Kujikatsu016.Questions;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu016.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc037/tasks/agc037_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();
            var unmatched = new PriorityQueue<ValueAndIndex>(true);
            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] != b[i])
                {
                    unmatched.Enqueue(new ValueAndIndex(b[i], i));
                }
            }

            long count = 0;
            while (unmatched.Count > 0)
            {
                var (value, index) = unmatched.Dequeue();
                var left = b[(index - 1 + b.Length) % b.Length];
                var right = b[(index + 1) % b.Length];
                var sub = left + right;

                if (value - sub < a[index])
                {
                    yield return -1;
                    yield break;
                }
                else if ((value - a[index]) % sub == 0)
                {
                    b[index] = a[index];
                    count += (value - a[index]) / sub;
                }
                else
                {
                    var c = value / sub;
                    b[index] = value - sub * c;
                    count += c;
                    unmatched.Enqueue(new ValueAndIndex(b[index], index));
                }
            }

            yield return count;
        }


        [StructLayout(LayoutKind.Auto)]
        readonly struct ValueAndIndex : IComparable<ValueAndIndex>
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

            public int CompareTo([AllowNull] ValueAndIndex other) => Value - other.Value;
        }
    }
}
