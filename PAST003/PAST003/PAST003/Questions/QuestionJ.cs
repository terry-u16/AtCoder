using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionJ : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (childrenCount, sushiCount) = inputStream.ReadValue<int, int>();
            var sushis = inputStream.ReadIntArray();
            var eaten = new int[childrenCount];

            foreach (var sushi in sushis)
            {
                var child = BoundaryBinarySearch<int>(eaten, d => sushi > d, -1, eaten.Length);
                if (child < eaten.Length)
                {
                    eaten[child] = sushi;
                    yield return child + 1;
                }
                else
                {
                    yield return -1;
                }
            }
        }

        private static int BoundaryBinarySearch<T>(ReadOnlySpan<T> span, Predicate<T> predicate, int ng, int ok)
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
