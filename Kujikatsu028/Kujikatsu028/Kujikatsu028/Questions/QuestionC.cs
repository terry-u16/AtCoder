using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu028.Algorithms;
using Kujikatsu028.Collections;
using Kujikatsu028.Extensions;
using Kujikatsu028.Numerics;
using Kujikatsu028.Questions;

namespace Kujikatsu028.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc167/tasks/abc167_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (bookCount, algorithmCount, needed) = inputStream.ReadValue<int, int, int>();
            var books = new Book[bookCount];
            ReadInput(inputStream, books);

            var minCost = int.MaxValue;
            for (var flags = BitSet.Zero; flags < (1 << bookCount); flags++)
            {
                var understanding = new int[algorithmCount];
                var cost = 0;
                for (int i = 0; i < books.Length; i++)
                {
                    if (flags[i])
                    {
                        for (int j = 0; j < understanding.Length; j++)
                        {
                            understanding[j] += books[i].Value[j];
                        }
                        cost += books[i].Cost;
                    }
                }

                if (understanding.All(u => u >= needed))
                {
                    minCost = Math.Min(minCost, cost);
                }
            }

            yield return minCost != int.MaxValue ? minCost : -1;
        }

        private static void ReadInput(TextReader inputStream, Book[] books)
        {
            foreach (ref var book in books.AsSpan())
            {
                book = new Book(inputStream.ReadIntArray());
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Book
        {
            public int Cost { get; }
            public int[] Value { get; }

            public Book(int[] array)
            {
                Cost = array[0];
                Value = array[1..];
            }

            public override string ToString() => $"{nameof(Cost)}: {Cost}, {nameof(Value)}: {Value}";
        }
    }
}
