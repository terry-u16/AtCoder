using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu052.Algorithms;
using Kujikatsu052.Collections;
using Kujikatsu052.Extensions;
using Kujikatsu052.Numerics;
using Kujikatsu052.Questions;
using static Kujikatsu052.Algorithms.AlgorithmHelpers;

namespace Kujikatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc054/tasks/abc054_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, ma, mb) = inputStream.ReadValue<int, int, int>();
            const int Inf = 1 << 28;
            int maxQuantity = 10 * n;
            var minCosts = new int[n + 1, maxQuantity + 1, maxQuantity + 1].SetAll((i, j, k) => Inf);
            minCosts[0, 0, 0] = 0;

            for (int i = 0; i < n; i++)
            {
                var (a, b, price) = inputStream.ReadValue<int, int, int>();
                for (int sumA = 0; sumA <= maxQuantity; sumA++)
                {
                    for (int sumB = 0; sumB <= maxQuantity; sumB++)
                    {
                        UpdateWhenSmall(ref minCosts[i + 1, sumA, sumB], minCosts[i, sumA, sumB]);
                        if (sumA + a <= maxQuantity && sumB + b <= maxQuantity)
                        {
                            UpdateWhenSmall(ref minCosts[i + 1, sumA + a, sumB + b], minCosts[i, sumA, sumB] + price);
                        }
                    }
                }
            }

            var result = Inf;

            for (int mul = 1; true; mul++)
            {
                var mulA = ma * mul;
                var mulB = mb * mul;
                if (mulA > maxQuantity || mulB > maxQuantity)
                {
                    break;
                }

                UpdateWhenSmall(ref result, minCosts[n, mulA, mulB]);
            }

            yield return result != Inf ? result : -1;
        }
    }
}
