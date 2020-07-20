using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu036.Algorithms;
using Kujikatsu036.Collections;
using Kujikatsu036.Extensions;
using Kujikatsu036.Numerics;
using Kujikatsu036.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu036.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc127/tasks/abc127_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cardCount, operationCount) = inputStream.ReadValue<int, int>();
            var a = new Queue<long>(inputStream.ReadLongArray().OrderBy(ai => ai));
            var alternates = new Queue<long>(cardCount);
            var countAndNumbers = new CountAndNumber[operationCount];

            for (int i = 0; i < operationCount; i++)
            {
                var (b, c) = inputStream.ReadValue<int, int>();
                countAndNumbers[i] = new CountAndNumber(b, c);
            }

            Array.Sort(countAndNumbers);
            foreach (var (count, number) in countAndNumbers)
            {
                for (int i = 0; i < count; i++)
                {
                    alternates.Enqueue(number);
                }

                if (alternates.Count >= cardCount)
                {
                    break;
                }
            }

            long sum = 0;
            for (int i = 0; i < cardCount; i++)
            {
                var initial = a.Dequeue();
                var alternate = alternates.Count > 0 ? alternates.Peek() : long.MinValue;

                if (initial < alternate)
                {
                    sum += alternates.Dequeue();
                }
                else
                {
                    sum += initial;
                }
            }

            yield return sum;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct CountAndNumber : IComparable<CountAndNumber>
        {
            public int Count { get; }
            public int Number { get; }

            public CountAndNumber(int count, int number)
            {
                Count = count;
                Number = number;
            }

            public void Deconstruct(out int count, out int number) => (count, number) = (Count, Number);
            public override string ToString() => $"{nameof(Count)}: {Count}, {nameof(Number)}: {Number}";

            public int CompareTo([AllowNull] CountAndNumber other) => other.Number - Number;
        }
    }
}
