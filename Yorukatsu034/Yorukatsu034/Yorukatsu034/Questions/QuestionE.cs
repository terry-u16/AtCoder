using Yorukatsu034.Questions;
using Yorukatsu034.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu034.Questions
{
    /// <summary>
    /// ABC073 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmr = inputStream.ReadIntArray();
            var towns = nmr[0];
            var roads = nmr[1];
            var toVisit = nmr[2];

            var toVisits = inputStream.ReadIntArray().Select(i => i - 1).OrderBy(i => i).ToArray();
            var distances = new int[towns, towns];
            for (int i = 0; i < towns; i++)
            {
                for (int j = 0; j < towns; j++)
                {
                    distances[i, j] = 1 << 28;
                }
            }

            for (int i = 0; i < roads; i++)
            {
                var abc = inputStream.ReadIntArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];
                distances[a, b] = c;
                distances[b, a] = c;
            }

            WarshallFloyd(distances);

            yield return GetPermutations(toVisits).Min(visitOrder =>
            {
                long distance = 0;
                for (int i = 0; i < visitOrder.Length - 1; i++)
                {
                    distance += distances[visitOrder[i], visitOrder[i + 1]];
                }
                return distance;
            });
        }

        void WarshallFloyd(int[,] d)
        {
            var n = d.GetLength(0);
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                    }
                }
            }
        }

        public static IEnumerable<T[]> GetPermutations<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var a = collection.ToArray();

            yield return a; // ソート済み初期配列

            if (a.Length <= 2)
            {
                if (a.Length == 2 && a[0].CompareTo(a[1]) != 0)
                {
                    Swap(ref a[1], ref a[0]);
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
                        Swap(ref a[j], ref a[i]);

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

        static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
