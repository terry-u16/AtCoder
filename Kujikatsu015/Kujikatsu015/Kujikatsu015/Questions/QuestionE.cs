using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu015.Algorithms;
using Kujikatsu015.Collections;
using Kujikatsu015.Extensions;
using Kujikatsu015.Numerics;
using Kujikatsu015.Questions;

namespace Kujikatsu015.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc073/tasks/arc073_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, capacity) = inputStream.ReadValue<int, int>();
            var items = new Item[n];
            for (int i = 0; i < items.Length; i++)
            {
                var (w, v) = inputStream.ReadValue<int, int>();
                items[i] = new Item(w, v);
            }
            var baseW = items[0].Weight;

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item(items[i].Weight - baseW, items[i].Value);
            }

            const int maxCapacity = 300;
            var maxValues = new int[n + 1, n + 1, maxCapacity];

            for (int i = 0; i < n; i++)
            {
                for (int selected = 0; selected <= i; selected++)
                {
                    for (int w = 0; w < maxCapacity; w++)
                    {
                        AlgorithmHelpers.UpdateWhenLarge(ref maxValues[i + 1, selected, w], maxValues[i, selected, w]);

                        if (w + items[i].Weight < maxCapacity)
                        {
                            AlgorithmHelpers.UpdateWhenLarge(ref maxValues[i + 1, selected + 1, w + items[i].Weight], maxValues[i, selected, w] + items[i].Value);
                        }
                    }
                }
            }

            var max = int.MinValue;
            for (int selected = 0; selected <= n; selected++)
            {
                for (int w = 0; w < maxCapacity; w++)
                {
                    if ((long)baseW * selected + w <= capacity)
                    {
                        max = Math.Max(max, maxValues[n, selected, w]);
                    }
                }
            }

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Item
        {
            public int Weight { get; }
            public int Value { get; }

            public Item(int weight, int value)
            {
                Weight = weight;
                Value = value;
            }

            public void Deconstruct(out int weight, out int value) => (weight, value) = (Weight, Value);
            public override string ToString() => $"{nameof(Weight)}: {Weight}, {nameof(Value)}: {Value}";
        }
    }
}
