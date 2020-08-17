using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu064.Algorithms;
using Kujikatsu064.Collections;
using Kujikatsu064.Extensions;
using Kujikatsu064.Numerics;
using Kujikatsu064.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu064.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/diverta2019-2/tasks/diverta2019_2_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var (gA, sA, bA) = inputStream.ReadValue<int, int, int>();
            var (gB, sB, bB) = inputStream.ReadValue<int, int, int>();

            var metals = new Metal[] { new Metal(gA, gB), new Metal(sA, sB), new Metal(bA, bB) };
            Array.Sort(metals);

            long max = n;
            if (metals.All(m => m.BuyAtA) || metals.All(m => m.BuyAtB))
            {
                // どちらかで3個買って3個全部売る
                for (long metal0 = 0; metal0 <= n / metals[0].Buy; metal0++)
                {
                    var payed0 = metals[0].Buy * metal0;
                    for (long metal1 = 0; metal1 <= (n - payed0) / metals[1].Buy; metal1++)
                    {
                        var payed1 = metals[1].Buy * metal1;
                        var metal2 = (n - payed0 - payed1) / metals[2].Buy;
                        max = Math.Max(max, n + metal0 * metals[0].Profit + metal1 * metals[1].Profit + metal2 * metals[2].Profit);
                    }
                }
            }
            else if (metals[1].BuyAtA)
            {
                // Aで2個、Bで1個買う
                for (long metal0 = 0; metal0 <= n / metals[0].Buy; metal0++)
                {
                    long wallet = n;
                    var payed0 = metals[0].Buy * metal0;
                    var metal1 = (wallet - payed0) / metals[1].Buy;

                    wallet += metal0 * metals[0].Profit + metal1 * metals[1].Profit;

                    var metal2 = wallet / metals[2].Buy;
                    wallet += metal2 * metals[2].Profit;
                    max = Math.Max(max, wallet);
                }
            }
            else
            {
                // Aで1個、Bで2個買う
                var metal0 = n / metals[0].Buy;
                var initialWallet = n + metal0 * metals[0].Profit;

                for (long metal1 = 0; metal1 <= initialWallet / metals[1].Buy; metal1++)
                {
                    var payed1 = metal1 * metals[1].Buy;
                    var metal2 = (initialWallet - payed1) / metals[2].Buy;
                    max = Math.Max(max, initialWallet + metal1 * metals[1].Profit + metal2 * metals[2].Profit);
                }
            }

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Metal : IComparable<Metal>
        {
            public int A { get; }
            public int B { get; }
            public bool BuyAtA => A <= B;
            public bool BuyAtB => A >= B;
            public int Profit => Math.Max(A - B, B - A);
            public int Buy => Math.Min(A, B);
            public int Sell => Math.Max(A, B);

            public Metal(int priceA, int priceB)
            {
                A = priceA;
                B = priceB;
            }

            public void Deconstruct(out int arg1, out int arg2) => (arg1, arg2) = (A, B);
            public override string ToString() => $"{nameof(A)}: {A}, {nameof(B)}: {B}";

            public int CompareTo([AllowNull] Metal other) => A - B;
        }
    }
}
