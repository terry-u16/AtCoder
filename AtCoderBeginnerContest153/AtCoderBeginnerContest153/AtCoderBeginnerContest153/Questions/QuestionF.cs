using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nda = inputStream.ReadIntArray();
            var n = nda[0];
            var d = nda[1];
            var a = nda[2];

            var monsters = new Monster[n];
            for (int i = 0; i < n; i++)
            {
                var xh = inputStream.ReadIntArray();
                monsters[i] = new Monster(xh[0], xh[1]);
            }

            Array.Sort(monsters);
            int forwardCursor = 0;
            int backCursor = monsters.Length - 1;

            long count = 0;
            while (true)
            {
                // 前から
                var target = monsters[forwardCursor].Position + d;
                var localCount = (long)Math.Ceiling((double)monsters[forwardCursor].HP / a);
                count += localCount;
                var damage = a * localCount;
                var maxIndex = monsters.GetIndexSmallerEqual(new Monster(target + d, 0));
                for (int i = forwardCursor; i <= maxIndex; i++)
                {
                    monsters[i].HP -= damage;
                }
                forwardCursor = SearchNextAvailableMonsterIndex(monsters, forwardCursor);
                if (forwardCursor > monsters.Length)
                {
                    break;
                }

                // 後ろから
                target = monsters[backCursor].Position - d;
                localCount = (long)Math.Ceiling((double)monsters[backCursor].HP / a);
                count += localCount;
                damage = a * localCount;
                var minIndex = monsters.GetIndexGreaterEqual(new Monster(target - d, 0));
                for (int i = minIndex; i <= backCursor; i++)
                {
                    monsters[i].HP -= damage;
                }
                backCursor = SearchPreviousAvailableMonsterIndex(monsters, backCursor);
                if (backCursor < 0)
                {
                    break;
                }
            }

            yield return count;
        }

        private int SearchNextAvailableMonsterIndex(Monster[] monsters, int currentIndex)
        {
            for (int i = currentIndex + 1; i < monsters.Length; i++)
            {
                if (monsters[i].HP > 0)
                {
                    return i;
                }
            }
            return int.MaxValue;
        }

        private int SearchPreviousAvailableMonsterIndex(Monster[] monsters, int currentIndex)
        {
            for (int i = currentIndex - 1; i > 0; i--)
            {
                if (monsters[i].HP > 0)
                {
                    return i;
                }
            }
            return int.MinValue;
        }


        private struct Monster : IComparable<Monster>
        {
            public int Position { get; }
            public long HP { get; set; }

            public Monster(int position, long hp)
            {
                Position = position;
                HP = hp;
            }

            public int CompareTo(Monster other) => Position - other.Position;
        }
    }

    public static class SearchExtensions
    {

        public static int GetIndexGreaterEqual<T>(this T[] array, T minValue) where T : IComparable<T>
        {
            int ng = -1;
            int ok = array.Length;

            return BoundaryBinarySearch(array, v => v.CompareTo(minValue) >= 0, ng, ok);
        }

        public static int GetIndexSmallerEqual<T>(this T[] array, T maxValue) where T : IComparable<T>
        {
            int ng = array.Length;
            int ok = -1;

            return BoundaryBinarySearch(array, v => v.CompareTo(maxValue) <= 0, ng, ok);
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
