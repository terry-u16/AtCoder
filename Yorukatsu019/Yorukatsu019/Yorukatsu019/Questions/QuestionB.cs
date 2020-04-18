using Yorukatsu019.Questions;
using Yorukatsu019.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu019.Questions
{
    /// <summary>
    /// ABC121 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var drinkShops = new EnergyDrinkStore[n];
            long drinkCount = 0;
            long totalCost = 0;

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                drinkShops[i] = new EnergyDrinkStore(ab[0], ab[1]);
            }

            Array.Sort(drinkShops);

            foreach (var shop in drinkShops)
            {
                var toBuy = m - drinkCount;
                if (toBuy > shop.Stock)
                {
                    drinkCount += shop.Stock;
                    totalCost += shop.Cost * shop.Stock;
                }
                else
                {
                    drinkCount += toBuy;
                    totalCost += shop.Cost * toBuy;
                    break;
                }
            }

            yield return totalCost;
        }
    }

    struct EnergyDrinkStore : IComparable<EnergyDrinkStore>
    {
        public long Cost { get; }
        public long Stock { get; }

        public EnergyDrinkStore(long cost, long stock)
        {
            Cost = cost;
            Stock = stock;
        }

        public int CompareTo(EnergyDrinkStore other) => Cost.CompareTo(other.Cost);

        public override string ToString() => $"Cost:{Cost}, Stock:{Stock}";
    }
}
