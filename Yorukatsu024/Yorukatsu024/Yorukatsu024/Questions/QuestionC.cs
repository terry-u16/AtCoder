using Yorukatsu024.Questions;
using Yorukatsu024.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu024.Questions
{
    /// <summary>
    /// ABC159 D
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var integerCount= new Dictionary<int, int>();

            foreach (var ai in a)
            {
                if (integerCount.ContainsKey(ai))
                {
                    integerCount[ai]++;
                }
                else
                {
                    integerCount.Add(ai, 1);
                }
            }

            var count = 0L;
            foreach (var pair in integerCount)
            {
                if (pair.Value >= 2)
                {
                    count += Combination(pair.Value, 2);
                }
            }

            foreach (var ai in a)
            {
                if (integerCount[ai] >= 3)
                {
                    yield return count - Combination(integerCount[ai], 2) + Combination(integerCount[ai] - 1, 2);
                }
                else if (integerCount[ai] == 2)
                {
                    yield return count - Combination(integerCount[ai], 2);
                }
                else
                {
                    yield return count;
                }
            }
        }

        public static long Combination(int n, int r)
        {
            CheckNR(n, r);
            r = Math.Min(r, n - r);

            // See https://stackoverflow.com/questions/1838368/calculating-the-amount-of-combinations
            long result = 1;
            for (int i = 1; i <= r; i++)
            {
                result *= n--;
                result /= i;
            }
            return result;
        }

        private static void CheckNR(int n, int r)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は正の整数でなければなりません。");
            }
            if (r < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(r), $"{nameof(r)}は0以上の整数でなければなりません。");
            }
            if (n < r)
            {
                throw new ArgumentOutOfRangeException($"{nameof(n)},{nameof(r)}", $"{nameof(r)}は{nameof(n)}以下でなければなりません。");
            }
        }
    }
}
