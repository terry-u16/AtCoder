using Yorukatsu024.Questions;
using Yorukatsu024.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.CodeDom;

namespace Yorukatsu024.Questions
{
    /// <summary>
    /// ABC100 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var cakes = new Cake[n];

            for (int i = 0; i < n; i++)
            {
                var xyz = inputStream.ReadLongArray();
                cakes[i] = new Cake(xyz[0], xyz[1], xyz[2]);
            }

            var totalValue = new long?[1 << 3, n + 1, m + 1];
            
            for (int bitFlag = 0; bitFlag < 1 << 3; bitFlag++)
            {
                totalValue[bitFlag, 0, 0] = 0;
                for (int cakeIndex = 0; cakeIndex < n; cakeIndex++)
                {
                    for (int selectedCakeCount = 0; selectedCakeCount <= m; selectedCakeCount++)
                    {
                        // 選ばない場合
                        if (totalValue[bitFlag, cakeIndex, selectedCakeCount].HasValue)
                        {
                            if (totalValue[bitFlag, cakeIndex + 1, selectedCakeCount].HasValue)
                            {
                                totalValue[bitFlag, cakeIndex + 1, selectedCakeCount] =
                                    Math.Max(totalValue[bitFlag, cakeIndex + 1, selectedCakeCount].Value, totalValue[bitFlag, cakeIndex, selectedCakeCount].Value);
                            }
                            else
                            {
                                totalValue[bitFlag, cakeIndex + 1, selectedCakeCount] = totalValue[bitFlag, cakeIndex, selectedCakeCount];
                            }
                        }

                        // 選ぶ場合
                        if (selectedCakeCount < m && totalValue[bitFlag, cakeIndex, selectedCakeCount].HasValue)
                        {
                            var beauty = ((bitFlag & (1 << 0)) > 0 ? 1 : -1) * cakes[cakeIndex].Beauty;
                            var delicious = ((bitFlag & (1 << 1)) > 0 ? 1 : -1) * cakes[cakeIndex].Delicious;
                            var popular = ((bitFlag & (1 << 2)) > 0 ? 1 : -1) * cakes[cakeIndex].Popular;
                            var value = beauty + delicious + popular;
                            totalValue[bitFlag, cakeIndex + 1, selectedCakeCount + 1] = totalValue[bitFlag, cakeIndex, selectedCakeCount] + value;
                        }
                    }
                }
            }

            long max = 0;
            for (int bitFlag = 0; bitFlag < 1 << 3; bitFlag++)
            {
                UpdateWhenLarge(ref max, totalValue[bitFlag, n, m].Value);
            }

            yield return max;
        }

        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }

        public static void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }

    }

    class Cake
    {
        public long Beauty { get; }
        public long Delicious { get; }
        public long Popular { get; }

        public Cake(long beauty, long delicious, long popular)
        {
            Beauty = beauty;
            Delicious = delicious;
            Popular = popular;
        }
    }
}
