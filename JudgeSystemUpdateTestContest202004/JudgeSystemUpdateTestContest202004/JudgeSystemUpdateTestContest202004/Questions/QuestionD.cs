using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using JudgeSystemUpdateTestContest202004.Questions;
using JudgeSystemUpdateTestContest202004.Extensions;
using JudgeSystemUpdateTestContest202004.Algorithms;

namespace JudgeSystemUpdateTestContest202004.Questions
{
    // 復習
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var (n, q) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            var s = inputStream.ReadIntArray();

            var gcds = new long[n];
            gcds[0] = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                gcds[i] = BasicAlgorithm.Gcd(a[i], gcds[i - 1]);
            }

            foreach (var si in s)
            {
                var index = BoundaryBinarySearch(gcds, (long l) => BasicAlgorithm.Gcd(l, si) == 1, -1, gcds.Length);
                if (index < gcds.Length)
                {
                    yield return (index + 1).ToString();
                }
                else
                {
                    yield return BasicAlgorithm.Gcd(gcds[^1], si).ToString();
                }
            }
        }

        private int BoundaryBinarySearch<T>(ReadOnlySpan<T> span, Predicate<T> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(span[mid]))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }

    }
}
