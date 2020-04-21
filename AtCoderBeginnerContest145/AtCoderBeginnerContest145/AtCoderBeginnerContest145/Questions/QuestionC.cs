using AtCoderBeginnerContest145.Questions;
using AtCoderBeginnerContest145.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest145.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var towns = new Coordinate[n];
            var indexes = Enumerable.Range(0, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                var xy = inputStream.ReadIntArray();
                towns[i] = new Coordinate(xy[0], xy[1]);
            }

            foreach (var order in GetPermutations(indexes,true))
            {
                var hoge = GetWholePathLength(towns, order);
            }

            yield return GetPermutations(indexes, true).Average(order => GetWholePathLength(towns, order));
        }

        double GetWholePathLength(Coordinate[] towns, int[] order)
        {
            double total = 0;
            for (int i = 0; i < order.Length - 1; i++)
            {
                total += towns[order[i]].GetLengthTo(towns[order[i + 1]]);
            }
            return total;
        }

        public static IEnumerable<T[]> GetPermutations<T>(IEnumerable<T> collection, bool isSorted) where T : IComparable<T>
        {
            var a = collection.ToArray();

            if (!isSorted && a.Length > 1)
            {
                Array.Sort(a);
            }

            yield return a; // ソート済み初期配列

            if (a.Length <= 2)
            {
                if (a.Length == 2 && a[0].CompareTo(a[1]) != 0)
                {
                    var temp = a[0];
                    a[0] = a[1];
                    a[1] = temp;
                    yield return a;
                    yield break;
                }

                yield break;
            }

            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = a.Length - 2; i >= 0; i--)
                {
                    // iよりi+1の方が大きい（昇順）なら
                    if (a[i].CompareTo(a[i + 1]) < 0)
                    {
                        // 後ろから見ていってi<jとなるところを探して
                        int j;
                        for (j = a.Length - 1; a[i].CompareTo(a[j]) >= 0; j--) { }

                        // iとjを入れ替えて
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;

                        // i+1以降を反転
                        if (i < a.Length - 2)
                        {
                            Array.Reverse(a, i + 1, a.Length - (i + 1)); 
                        }

                        flag = true;
                        yield return a;
                        break;
                    }
                }
            }
        }
    }

    struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double GetLengthTo(Coordinate other)
        {
            var diffX = X - other.X;
            var diffY = Y - other.Y;
            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }
    }
}
