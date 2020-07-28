using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu043.Algorithms;
using Kujikatsu043.Collections;
using Kujikatsu043.Extensions;
using Kujikatsu043.Numerics;
using Kujikatsu043.Questions;

namespace Kujikatsu043.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 1_000_000_007;
            Modular.InitializeCombinationTable();
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var (dupLeft, dupRight) = GetDuplicatedIndices(a);

            var left = dupLeft;
            var right = a.Length - dupRight - 1;

            for (int k = 1; k <= a.Length; k++)
            {
                var count = Modular.Combination(a.Length, k);
                if (left + right >= k - 1)
                {
                    count -= Modular.Combination(left + right, k - 1);
                }
                yield return count;
            }
        }

        (int, int) GetDuplicatedIndices(int[] a)
        {
            var indices = Enumerable.Repeat(-1, a.Length).ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (indices[a[i]] >= 0)
                {
                    return (indices[a[i]], i);
                }
                else
                {
                    indices[a[i]] = i;
                }
            }
            return (-1, -1);
        }
    }
}
