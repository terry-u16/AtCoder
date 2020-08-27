using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu074.Algorithms;
using Kujikatsu074.Collections;
using Kujikatsu074.Extensions;
using Kujikatsu074.Numerics;
using Kujikatsu074.Questions;
using static Kujikatsu074.Algorithms.AlgorithmHelpers;

namespace Kujikatsu074.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc143/tasks/abc143_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const long Inf = 1L << 60;
            var (towns, roads, capacity) = inputStream.ReadValue<int, int, int>();
            var distances = new long[towns, towns].SetAll((i, j) => Inf);

            for (int i = 0; i < roads; i++)
            {
                var (a, b, c) = inputStream.ReadValue<int, int, int>();
                a--;
                b--;
                distances[a, b] = c;
                distances[b, a] = c;
            }

            WarshallFloyd(distances, towns);

            var refuels = new long[towns, towns].SetAll((i, j) => Inf);
            for (int i = 0; i < towns; i++)
            {
                for (int j = 0; j < towns; j++)
                {
                    if (distances[i, j] <= capacity)
                    {
                        refuels[i, j] = 1;
                    }
                }
            }

            WarshallFloyd(refuels, towns);

            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var (s, t) = inputStream.ReadValue<int, int>();
                s--;
                t--;
                if (refuels[s, t] < Inf)
                {
                    yield return refuels[s, t] - 1;
                }
                else
                {
                    yield return -1;
                }
            }
        }

        void WarshallFloyd(long[,] distances, int towns)
        {
            for (int k = 0; k < towns; k++)
            {
                for (int i = 0; i < towns; i++)
                {
                    for (int j = 0; j < towns; j++)
                    {
                        UpdateWhenSmall(ref distances[i, j], distances[i, k] + distances[k, j]);
                    }
                }
            }
        }
    }
}
