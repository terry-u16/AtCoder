using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu051.Algorithms;
using Kujikatsu051.Collections;
using Kujikatsu051.Extensions;
using Kujikatsu051.Numerics;
using Kujikatsu051.Questions;

namespace Kujikatsu051.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc011/tasks/agc011_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (peopleCount, capacity, acceptableDelay) = inputStream.ReadValue<int, int, int>();
            var arrived = new int[peopleCount];
            for (int i = 0; i < arrived.Length; i++)
            {
                arrived[i] = inputStream.ReadInt();
            }

            Array.Sort(arrived);

            var lastArrived = 0;
            var current = 0;
            var buses = 0;

            foreach (var time in arrived)
            {
                if (current == 0 || time - lastArrived > acceptableDelay)
                {
                    buses++;
                    lastArrived = time;
                    current = 0;
                }

                current++;

                if (current == capacity)
                {
                    current = 0;
                }
            }

            yield return buses;
        }
    }
}
