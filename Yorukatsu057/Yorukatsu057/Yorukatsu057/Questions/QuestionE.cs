using Yorukatsu057.Questions;
using Yorukatsu057.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc144/tasks/abc144_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadLongArray();
            var trainingMax = nk[1];
            var power = inputStream.ReadLongArray();
            var foods = inputStream.ReadLongArray();

            Array.Sort(power);
            Array.Sort(foods);
            Array.Reverse(foods);

            yield return BoundaryBinarySearch(seconds => CanEatWithin(seconds, trainingMax, power, foods), long.MaxValue >> 1, -1);
        }

        bool CanEatWithin(long seconds, long trainingCount, long[] power, long[] foods)
        {
            long count = 0;

            for (int i = 0; i < power.Length; i++)
            {
                count += Math.Max(0, power[i] - seconds / foods[i]);
            }

            return count <= trainingCount;
        }

        public static long BoundaryBinarySearch(Predicate<long> predicate, long ok, long ng)
        {
            // めぐる式二分探索
            while (Math.Abs(ok - ng) > 1)
            {
                long mid = (ok + ng) / 2;
                if (predicate(mid))
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
