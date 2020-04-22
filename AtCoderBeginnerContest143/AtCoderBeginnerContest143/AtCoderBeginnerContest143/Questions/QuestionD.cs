using AtCoderBeginnerContest143.Questions;
using AtCoderBeginnerContest143.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest143.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var l = inputStream.ReadIntArray();
            Array.Sort(l);

            var count = 0;
            for (int i = 0; i < l.Length - 2; i++)
            {
                for (int j = i + 1; j < l.Length - 1; j++)
                {
                    var available = BoundaryBinarySearch(l, c => l[i] + l[j] > c, l.Length, -1);
                    count += Math.Max(available - j, 0);
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
