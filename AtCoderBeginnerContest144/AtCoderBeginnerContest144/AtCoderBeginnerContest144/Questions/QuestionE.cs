using AtCoderBeginnerContest144.Questions;
using AtCoderBeginnerContest144.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest144.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadLongArray();
            var k = nk[1];
            var a = inputStream.ReadLongArray();
            var f = inputStream.ReadLongArray();
            
            Array.Sort(a);      // コスト低い順
            Array.Sort(f);
            Array.Reverse(f);   // コスト重い順。i番目のメンバーがFiを食べる

            var bestResult = BoundaryBinarySearch(result =>
            {
                long trainingCount = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    var cost = a[i] * f[i];
                    if (a[i] * f[i] > result)
                    {
                        trainingCount += (long)Math.Ceiling((double)(a[i] * f[i] - result) / f[i]);
                    }
                }
                return trainingCount <= k;
            }, -1, a[a.Length - 1] * f[0]);

            yield return bestResult;
        }

        private static long BoundaryBinarySearch(Predicate<long> predicate, long ng, long ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
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
