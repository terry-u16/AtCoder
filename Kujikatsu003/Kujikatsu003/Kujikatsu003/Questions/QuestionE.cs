using Kujikatsu003.Questions;
using Kujikatsu003.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu003.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var islandCount = nm[0];
            var warCount = nm[1];

            var wars = new War[warCount];

            for (int i = 0; i < warCount; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0]--;
                var b = ab[1]--;
                wars[i] = new War(a, b);
            }

            Array.Sort(wars);

            var count = 0;
            var lastBridge = int.MinValue;
            foreach (var war in wars)
            {
                if (lastBridge < war.A)
                {
                    count++;
                    lastBridge = war.B - 1;
                }
            }

            yield return count;
        }

        struct War : IComparable<War>
        {
            public int A { get; }
            public int B { get; }

            public War(int a, int b)
            {
                A = a;
                B = b;
            }

            public int CompareTo(War other) => B.CompareTo(other.B);
        }
    }
}
