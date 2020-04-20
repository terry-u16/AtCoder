using Yorukatsu020.Questions;
using Yorukatsu020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu020.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();
            var c = inputStream.ReadIntArray();

            Array.Sort(a);
            Array.Sort(c);

            long sum = 0L;
            foreach (var bi in b)
            {
                long aCount = BoundaryBinarySearch(a, i => bi.CompareTo(i) > 0, a.Length, - 1) + 1;
                long cCount = c.Length - BoundaryBinarySearch(c, i => bi.CompareTo(i) < 0, -1, c.Length);
                sum += aCount * cCount;
            }

            yield return sum;
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
