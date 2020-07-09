using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu025.Algorithms;
using Kujikatsu025.Collections;
using Kujikatsu025.Extensions;
using Kujikatsu025.Numerics;
using Kujikatsu025.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu025.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc145/tasks/abc145_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (dishKinds, lastOrder) = inputStream.ReadValue<int, int>();
            var dishes = new Dish[dishKinds];

            for (int i = 0; i < dishKinds; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                dishes[i] = new Dish(a, b);
            }

            Array.Sort(dishes);
            var maxMinutes = lastOrder + 3000;

            var happinesses = new int[dishKinds + 1, maxMinutes + 1];

            for (int i = 0; i < dishes.Length; i++)
            {
                for (int minutes = 0; minutes <= maxMinutes; minutes++)
                {
                    AlgorithmHelpers.UpdateWhenLarge(ref happinesses[i + 1, minutes], happinesses[i, minutes]);

                    if (minutes < lastOrder)
                    {
                        AlgorithmHelpers.UpdateWhenLarge(ref happinesses[i + 1, minutes + dishes[i].NeedToEat], happinesses[i, minutes] + dishes[i].Deliciousness);
                    }
                }
            }

            var max = 0;
            for (int minutes = 0; minutes <= maxMinutes; minutes++)
            {
                AlgorithmHelpers.UpdateWhenLarge(ref max, happinesses[dishKinds, minutes]);
            }
            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Dish : IComparable<Dish>
        {
            public int NeedToEat { get; }
            public int Deliciousness { get; }

            public Dish(int needToEat, int deliciousness)
            {
                NeedToEat = needToEat;
                Deliciousness = deliciousness;
            }

            public void Deconstruct(out int needToEat, out int deliciousness) => (needToEat, deliciousness) = (NeedToEat, Deliciousness);
            public override string ToString() => $"{nameof(NeedToEat)}: {NeedToEat}, {nameof(Deliciousness)}: {Deliciousness}";

            public int CompareTo([AllowNull] Dish other) => NeedToEat - other.NeedToEat;
        }
    }
}
