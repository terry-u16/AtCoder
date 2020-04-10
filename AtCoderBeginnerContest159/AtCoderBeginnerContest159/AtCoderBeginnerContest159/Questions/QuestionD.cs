using AtCoderBeginnerContest159.Questions;
using AtCoderBeginnerContest159.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest159.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var counts = new int[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                counts[a[i]] += 1;
            }

            long sum = 0;
            var diffs = new long[n + 1];

            for (int i = 0; i < counts.Length; i++)
            {
                sum += nCr(counts[i], 2);
                diffs[i] = nCr(counts[i], 2) - nCr(counts[i] - 1, 2);
            }

            for (int i = 0; i < a.Length; i++)
            {
                yield return sum - diffs[a[i]];
            }
        }

        private long nCr(int n, int r)
        {
            if (n <= 0 || r <= 0 || n < r)
            {
                return 0;
            }

            if (n - r < r)
            {
                r = n - r;
            }

            long result = 1;

            for (int i = 0; i < r; i++)
            {
                result *= (n - i);
            }

            for (int i = 0; i < r; i++)
            {
                result /= (i + 1);
            }

            return result;
        }
    }
}
