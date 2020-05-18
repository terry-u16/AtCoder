using Yorukatsu042.Questions;
using Yorukatsu042.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu042.Questions
{
    /// <summary>
    /// ABC121 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var storeCounts = nm[0];
            var needed = nm[1];

            var stores = new Store[storeCounts];
            for (int i = 0; i < stores.Length; i++)
            {
                var ab = inputStream.ReadIntArray();
                stores[i] = new Store(ab[0], ab[1]);
            }

            Array.Sort(stores);

            long total = 0;
            foreach (var store in stores)
            {
                var buy = Math.Min(store.Stock, needed);
                total += (long)store.Price * buy;
                needed -= buy;
                if (needed == 0)
                {
                    break;
                }
            }

            yield return total;
        }

        struct Store : IComparable<Store>
        {
            public int Price { get; }
            public int Stock { get; }

            public Store(int price, int stock)
            {
                Price = price;
                Stock = stock;
            }

            public int CompareTo(Store other) => Price.CompareTo(other.Price);
        }
    }
}
