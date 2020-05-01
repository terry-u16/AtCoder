using AtCoderBeginnerContest131.Questions;
using AtCoderBeginnerContest131.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest131.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            // 全然わからなかった……
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            if (n == 2)
            {
                if (k == 0)
                {
                    yield return 1;
                    yield return "1 2";
                    yield break;
                }
                else
                {
                    yield return -1;
                    yield break;
                }
            }

            var maxCombination = Combination(n - 1, 2);
            if (k > maxCombination)
            {
                yield return -1;
            }
            else
            {
                var minimumEdges = n - 1;
                var extraEdges = maxCombination - k;
                yield return minimumEdges + extraEdges;
                for (int i = 2; i <= n; i++)
                {
                    yield return $"1 {i}";
                }

                var count = 0;
                for (int i = 2; i < n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        if (count++ == extraEdges)
                        {
                            yield break;
                        }
                        yield return $"{i} {j}";
                    }
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
