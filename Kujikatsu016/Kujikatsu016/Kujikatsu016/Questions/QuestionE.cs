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

namespace Kujikatsu016.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sushiCount, length) = inputStream.ReadValue<int, long>();
            var sushis = new Sushi[sushiCount];
            for (int i = 0; i < sushis.Length; i++)
            {
                var (x, v) = inputStream.ReadValue<long, long>();
                sushis[i] = new Sushi(x, v);
            }

            var clockwise = new long[sushis.Length + 1];
            var clockwiseDoubled = new long[sushis.Length + 1];
            var counterClockwise = new long[sushis.Length + 1];
            var counterClockwiseDoubled = new long[sushis.Length + 1];

            long cal = 0;
            for (int i = 0; i + 1 < clockwise.Length; i++)
            {
                cal += sushis[i].Calorie;
                clockwise[i + 1] = cal - sushis[i].Position;
                clockwiseDoubled[i + 1] = cal - sushis[i].Position * 2;
            }

            cal = 0;
            for (int i = 0; i + 1 < counterClockwise.Length; i++)
            {
                cal += sushis[^(i + 1)].Calorie;
                var distance = length - sushis[^(i + 1)].Position;
                counterClockwise[i + 1] = cal - distance;
                counterClockwiseDoubled[i + 1] = cal - distance * 2;
            }

            for (int i = 0; i + 1 < clockwise.Length; i++)
            {
                clockwise[i + 1] = Math.Max(clockwise[i], clockwise[i + 1]);
                clockwiseDoubled[i + 1] = Math.Max(clockwiseDoubled[i], clockwiseDoubled[i + 1]);
                counterClockwise[i + 1] = Math.Max(counterClockwise[i], counterClockwise[i + 1]);
                counterClockwiseDoubled[i + 1] = Math.Max(counterClockwiseDoubled[i], counterClockwiseDoubled[i + 1]);
            }

            long max = 0;
            for (int section = 0; section <= sushiCount; section++)
            {
                AlgorithmHelpers.UpdateWhenLarge(ref max, clockwise[section] + counterClockwiseDoubled[^(section + 1)]);
                AlgorithmHelpers.UpdateWhenLarge(ref max, clockwiseDoubled[section] + counterClockwise[^(section + 1)]);
            }

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Sushi
        {
            public long Position { get; }
            public long Calorie { get; }

            public Sushi(long position, long calorie)
            {
                Position = position;
                Calorie = calorie;
            }

            public void Deconstruct(out long position, out long calorie) => (position, calorie) = (Position, Calorie);
            public override string ToString() => $"{nameof(Position)}: {Position}, {nameof(Calorie)}: {Calorie}";
        }
    }
}
