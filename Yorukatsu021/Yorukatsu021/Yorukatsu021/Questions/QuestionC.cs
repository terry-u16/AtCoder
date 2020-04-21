using Yorukatsu021.Questions;
using Yorukatsu021.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu021.Questions
{
    /// <summary>
    /// ABC143 D
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var l = inputStream.ReadIntArray();
            Array.Sort(l);

            var count = 0;
            for (int aIndex = 0; aIndex < l.Length - 2; aIndex++)
            {
                for (int bIndex = aIndex + 1; bIndex < l.Length - 1; bIndex++)
                {
                    var aPlusB = l[aIndex] + l[bIndex];
                    var index = BoundaryBinarySearch(l, c => c < aPlusB, l.Length, -1);
                    count += Math.Max(index - bIndex, 0);
                }
            }

            yield return count;
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
