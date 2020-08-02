using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu048.Algorithms;
using Kujikatsu048.Collections;
using Kujikatsu048.Extensions;
using Kujikatsu048.Numerics;
using Kujikatsu048.Questions;

namespace Kujikatsu048.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc060/tasks/arc060_a
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cardCount, average) = inputStream.ReadValue<int, int>();
            var x = inputStream.ReadIntArray();
            int maxSum = 50 * cardCount;
            var counts = new long[cardCount + 1, cardCount + 1, maxSum + 1];
            counts[0, 0, 0] = 1;

            for (int i = 0; i < cardCount; i++)
            {
                for (int selected = 0; selected <= i; selected++)
                {
                    for (int sum = 0; sum <= maxSum; sum++)
                    {
                        counts[i + 1, selected, sum] += counts[i, selected, sum];

                        if (sum + x[i] <= maxSum)
                        {
                            counts[i + 1, selected + 1, sum + x[i]] += counts[i, selected, sum];
                        }
                    }
                }
            }

            long result = 0;
            for (int selected = 1; selected <= cardCount; selected++)
            {
                result += counts[cardCount, selected, average * selected];
            }

            yield return result;
        }
    }
}
