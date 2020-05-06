using AtCoderBeginnerContest123.Questions;
using AtCoderBeginnerContest123.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest123.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var xyzk = inputStream.ReadIntArray();
            var k = xyzk[3];

            var a = inputStream.ReadLongArray();
            var b = inputStream.ReadLongArray();
            var c = inputStream.ReadLongArray();

            var orderedAB = a.SelectMany(x => b.Select(y => x + y)).ToArray();
            Array.Sort(orderedAB);
            Array.Reverse(orderedAB);
            var orderedABC = orderedAB.Take(k).SelectMany(ab => c.Select(z => ab + z)).ToArray();
            Array.Sort(orderedABC);
            Array.Reverse(orderedABC);

            foreach (var abc in orderedABC.Take(k))
            {
                yield return abc;
            }
        }

        struct SumAndCount : IComparable<SumAndCount>
        {
            public long Sum { get; }
            public int Count { get; }

            public SumAndCount(long sum, int count)
            {
                Sum = sum;
                Count = count;
            }

            public int CompareTo(SumAndCount other) => Sum.CompareTo(other.Sum);

            public override string ToString() => $"Sum:{Sum}, Count:{Count}";
        }
    }
}
