using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc006/tasks/abc006_4
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var minValue = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
            minValue[0] = int.MinValue;


            for (int i = 0; i < n; i++)
            {
                var card = inputStream.ReadInt();
                var index = BoundaryBinarySearch(minValue, v => card >= v, minValue.Length, 0);
                minValue[index + 1] = card;
            }

            yield return n - BoundaryBinarySearch(minValue, v => v <= n, minValue.Length, 0);
        }

        private static int BoundaryBinarySearch<T>(T[] array, Predicate<T> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(array[mid]))
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
