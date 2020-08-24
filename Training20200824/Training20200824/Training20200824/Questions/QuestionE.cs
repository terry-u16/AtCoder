using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200824.Algorithms;
using Training20200824.Collections;
using Training20200824.Extensions;
using Training20200824.Numerics;
using Training20200824.Questions;
using System.Diagnostics.CodeAnalysis;
using static Training20200824.Algorithms.AlgorithmHelpers;

namespace Training20200824.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc042/tasks/arc042_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, priceLimit) = inputStream.ReadValue<int, int>();
            var snacks = new Snack[n];
            for (int i = 0; i < snacks.Length; i++)
            {
                var (p, h) = inputStream.ReadValue<int, int>();
                snacks[i] = new Snack(p, h);
            }

            Array.Sort(snacks);

            var maxHappinesses = new int[n + 1, priceLimit + 1];
            var overHappiness = 0;

            for (int i = 0; i < snacks.Length; i++)
            {
                for (int price = 0; price <= priceLimit; price++)
                {
                    UpdateWhenLarge(ref maxHappinesses[i + 1, price], maxHappinesses[i, price]);

                    var nextPrice = price + snacks[i].Price;
                    var nextHappiness = maxHappinesses[i, price] + snacks[i].Happiness;
                    if (nextPrice <= priceLimit)
                    {
                        UpdateWhenLarge(ref maxHappinesses[i + 1, nextPrice], nextHappiness);
                    }
                    else
                    {
                        UpdateWhenLarge(ref overHappiness, nextHappiness);
                    }
                }
            }

            var max = overHappiness;

            for (int price = 0; price <= priceLimit; price++)
            {
                UpdateWhenLarge(ref max, maxHappinesses[n, price]);
            }

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Snack : IComparable<Snack>
        {
            public int Price { get; }
            public int Happiness { get; }

            public Snack(int price, int happiness)
            {
                Price = price;
                Happiness = happiness;
            }

            public void Deconstruct(out int price, out int happiness) => (price, happiness) = (Price, Happiness);
            public override string ToString() => $"{nameof(Price)}: {Price}, {nameof(Happiness)}: {Happiness}";

            public int CompareTo([AllowNull] Snack other) => other.Price - Price;
        }
    }
}
