using Yorukatsu048.Questions;
using Yorukatsu048.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu048.Questions
{
    /// <summary>
    /// ABC145 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var coordinates = new Coordinate[n];

            for (int i = 0; i < n; i++)
            {
                var xy = inputStream.ReadIntArray();
                coordinates[i] = new Coordinate(xy[0], xy[1]);
            }

            yield return GetPermutations(Enumerable.Range(0, n), true).Average(p => Enumerable.Range(0, n - 1).Sum(i => coordinates[p[i]].GetLengthTo(coordinates[p[i + 1]])));
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

        struct Coordinate
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public double GetLengthTo(Coordinate other) => Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
        }
    }
}
