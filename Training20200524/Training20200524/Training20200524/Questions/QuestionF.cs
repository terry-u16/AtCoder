using Training20200524.Questions;
using Training20200524.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200524.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var balloons = new Balloon[n];
            for (int i = 0; i < balloons.Length; i++)
            {
                var hs = inputStream.ReadLongArray();
                balloons[i] = new Balloon(hs[0], hs[1]);
            }

            var minHeight = BoundaryBinarySearch(height =>
            {
                var limits = balloons.Select(b => (double)(height - b.InitialHeight) / b.Velocity).ToArray();
                Array.Sort(limits);
                for (int i = 0; i < limits.Length; i++)
                {
                    if (limits[i] < i)
                    {
                        return false;
                    }
                }
                return true;
            }, 0, long.MaxValue);

            yield return minHeight;
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

        struct Balloon
        {
            public long InitialHeight { get; }
            public long Velocity { get; }

            public Balloon(long initialHeight, long velocity)
            {
                InitialHeight = initialHeight;
                Velocity = velocity;
            }

            public long GetHeightAfter(int second) => InitialHeight + Velocity * second;
        }
    }
}
