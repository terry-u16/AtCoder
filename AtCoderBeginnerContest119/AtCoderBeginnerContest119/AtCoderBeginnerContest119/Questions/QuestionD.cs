using AtCoderBeginnerContest119.Questions;
using AtCoderBeginnerContest119.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest119.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abq = inputStream.ReadIntArray();
            var a = abq[0];
            var b = abq[1];
            var queries = abq[2];

            var shrines = new long[a + 2];
            var temples = new long[b + 2];

            shrines[0] = -1L << 60;
            for (int i = 0; i < a; i++)
            {
                shrines[i + 1] = inputStream.ReadLong();
            }
            shrines[a + 1] = 1L << 60;

            temples[0] = -1L << 60;
            for (int i = 0; i < b; i++)
            {
                temples[i + 1] = inputStream.ReadLong();
            }
            temples[b + 1] = 1L << 60;

            for (int q = 0; q < queries; q++)
            {
                var x = inputStream.ReadLong();
                var leftShrine = Math.Abs(shrines[BoundaryBinarySearch(shrines, l => l <= x, shrines.Length, -1)] - x);
                var rightShrine = Math.Abs(shrines[BoundaryBinarySearch(shrines, l => l >= x, -1, shrines.Length)] - x);
                var leftTemple = Math.Abs(temples[BoundaryBinarySearch(temples, l => l <= x, temples.Length, -1)] - x);
                var rightTemple = Math.Abs(temples[BoundaryBinarySearch(temples, l => l >= x, -1, temples.Length)] - x);

                var minLength = long.MaxValue;
                // LL
                minLength = Math.Min(minLength, Math.Max(leftShrine, leftTemple));
                // RR
                minLength = Math.Min(minLength, Math.Max(rightShrine, rightTemple));
                // LR
                minLength = Math.Min(minLength, Math.Min(leftShrine, rightTemple) * 2 + Math.Max(leftShrine, rightTemple));
                // RL
                minLength = Math.Min(minLength, Math.Min(rightShrine, leftTemple) * 2 + Math.Max(rightShrine, leftTemple));

                yield return minLength;
            }
        }

        private static int BoundaryBinarySearch<T>(T[] span, Predicate<T> predicate, int ng, int ok)
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
