using Yorukatsu032.Questions;
using Yorukatsu032.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu032.Questions
{
    /// <summary>
    /// ABC047 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nt = inputStream.ReadIntArray();
            var towns = nt[0];
            var appleCosts = inputStream.ReadIntArray();

            var minBuyValuesBefore = new int[towns];
            var maxSellValuesAfter = new int[towns];

            minBuyValuesBefore[0] = appleCosts[0];
            for (int i = 1; i < minBuyValuesBefore.Length; i++)
            {
                minBuyValuesBefore[i] = Math.Min(minBuyValuesBefore[i - 1], appleCosts[i]);
            }

            maxSellValuesAfter[maxSellValuesAfter.Length - 1] = appleCosts[maxSellValuesAfter.Length - 1];
            for (int i = maxSellValuesAfter.Length - 2; i >= 0; i--)
            {
                maxSellValuesAfter[i] = Math.Max(maxSellValuesAfter[i + 1], appleCosts[i]);
            }

            var maxProfit = int.MinValue;
            var minBuyValue = int.MaxValue;
            var maxSellValue = int.MinValue;

            for (int i = 0; i < towns - 1; i++)
            {
                var profit = maxSellValuesAfter[i + 1] - minBuyValuesBefore[i];

                if (profit > maxProfit)
                {
                    maxProfit = profit;
                    minBuyValue = minBuyValuesBefore[i];
                    maxSellValue = maxSellValuesAfter[i + 1];
                }
            }

            var minBuyTowns = 0;
            var maxSellTowns = 0;
            for (int i = 0; i < towns - 1; i++)
            {
                if (maxSellValuesAfter[i + 1] - appleCosts[i] == maxProfit)
                {
                    minBuyTowns++;
                }
                if (appleCosts[i + 1] - minBuyValuesBefore[i] == maxProfit)
                {
                    maxSellTowns++;
                }
            }

            yield return Math.Min(minBuyTowns, maxSellTowns);


        }
    }
}
