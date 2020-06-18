using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu004.Algorithms;
using Kujikatsu004.Collections;
using Kujikatsu004.Extensions;
using Kujikatsu004.Numerics;
using Kujikatsu004.Questions;

namespace Kujikatsu004.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc144/tasks/abc144_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, maxTraining) = inputStream.ReadValue<int, long>();
            var costs = inputStream.ReadLongArray();
            var foods = inputStream.ReadLongArray();

            Array.Sort(costs);
            Array.Sort(foods);
            Array.Reverse(foods);

            var minSeconds = SearchExtensions.BoundaryBinarySearch(seconds => CanEatWithin(seconds, maxTraining, costs, foods), 100_0000_0000_0000, -1);

            yield return minSeconds;
        }

        bool CanEatWithin(long seconds, long maxTraining, long[] costs, long[] foods)
        {
            long training = 0;
            for (int i = 0; i < costs.Length; i++)
            {
                var neededCost = seconds / foods[i];
                training += Math.Max(costs[i] - neededCost, 0);
            }
            return training <= maxTraining;
        }
    }
}
