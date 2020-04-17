using Yorukatsu018.Questions;
using Yorukatsu018.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu018.Questions
{
    /// <summary>
    /// ARC073 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nw = inputStream.ReadIntArray();
            var n = nw[0];
            var w = nw[1];

            var items = new Item[n + 1];
            for (int i = 0; i < n; i++)
            {
                var wv = inputStream.ReadIntArray();
                items[i + 1] = new Item(wv[0], wv[1]);
            }

            var minWeight = items[1].Weight;
            items = items.Select(item => new Item(item.Weight - minWeight, item.Value)).ToArray();

            var dpMaxValue = Enumerable.Range(0, n + 1).Select(
                _=> Enumerable.Range(0, n + 1).Select(
                    __ => Enumerable.Repeat(0, (n + 1) * 3).ToArray()).ToArray()).ToArray();    // dp[i番目まで][j個選んで][重さがk]

            var totalWeightMax = 0;
            for (int i = 1; i <= n; i++)
            {
                totalWeightMax += items[i].Weight;
                for (int j = 0; j <= i; j++)
                {
                    for (int k = 0; k <= totalWeightMax; k++)
                    {
                        // 入れない
                        dpMaxValue[i][j][k] = dpMaxValue[i - 1][j][k];

                        if (j > 0 && k - items[i].Weight >= 0)
                        {
                            // 入れる
                            dpMaxValue[i][j][k] = Math.Max(dpMaxValue[i][j][k], dpMaxValue[i - 1][j - 1][k - items[i].Weight] + items[i].Value);
                        }
                    }
                }
            }

            var maxValue = 0;
            for (int j = 0; j < dpMaxValue[n].Length; j++)
            {
                for (int k = 0; k < dpMaxValue[n][j].Length; k++)
                {
                    if ((long)minWeight * j + k <= w)
                    {
                        maxValue = Math.Max(maxValue, dpMaxValue[n][j][k]);
                    }
                }
            }

            yield return maxValue;
        }
    }

    struct Item
    {
        public int Weight { get; }
        public int Value { get; }

        public Item(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }

        public override string ToString() => $"Weight:{Weight}, Value:{Value}";
    }
}
