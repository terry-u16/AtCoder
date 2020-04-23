using AtCoderBeginnerContest142.Questions;
using AtCoderBeginnerContest142.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace AtCoderBeginnerContest142.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            const int veryBigValue = int.MaxValue >> 4;

            var minPrices = new int[m + 1, 1 << n];
            for (int i = 0; i < minPrices.GetLength(0); i++)
            {
                for (int j = 0; j < minPrices.GetLength(1); j++)
                {
                    minPrices[i, j] = veryBigValue;
                }
            }

            minPrices[0, 0] = 0;

            for (int keyIndex = 0; keyIndex < m; keyIndex++)    // 配るDP
            {
                var a = inputStream.ReadIntArray()[0];
                var c = inputStream.ReadIntArray();
                var key = new Key(a, c);

                for (int treasureState = 0; treasureState < 1 << n; treasureState++)
                {
                    // 鍵を使わない
                    UpdateWhenSmall(ref minPrices[keyIndex + 1, treasureState], minPrices[keyIndex, treasureState]);

                    // 鍵を使う
                    UpdateWhenSmall(ref minPrices[keyIndex + 1, treasureState | key.AcceptableTreasureBoxes], minPrices[keyIndex, treasureState] + key.Price);
                }
            }

            var minPrice = minPrices[m, (1 << n) - 1];
            if (minPrice < veryBigValue)
            {
                yield return minPrice;
            }
            else
            {
                yield return -1;
            }
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

    class Key
    {
        public int Price { get; }
        public int AcceptableTreasureBoxes { get; }

        public Key(int price, int[] treasureBoxes)
        {
            Price = price;

            foreach (var treasureBox in treasureBoxes)
            {
                AcceptableTreasureBoxes |= 1 << (treasureBox - 1);
            }
        }
    }
}
