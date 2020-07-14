using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu030.Algorithms;
using Kujikatsu030.Collections;
using Kujikatsu030.Extensions;
using Kujikatsu030.Numerics;
using Kujikatsu030.Questions;

namespace Kujikatsu030.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc060/tasks/arc060_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();
            var l = inputStream.ReadInt();

            var reachableHotels = new List<List<int>>();
            var listIndexes = Enumerable.Repeat(-1, n).ToArray();

            for (int start = 0; start < listIndexes.Length; start++)
            {
                if (listIndexes[start] != -1)
                {
                    continue;
                }

                var listIndex = reachableHotels.Count;
                listIndexes[start] = listIndex;
                var currentReachableHotels = new List<int>();
                reachableHotels.Add(currentReachableHotels);

                int current = start;
                currentReachableHotels.Add(current);
                while (current < n - 1)
                {
                    current = SearchExtensions.GetLessEqualIndex(x, x[current] + l);
                    currentReachableHotels.Add(current);
                    if (listIndexes[current] != -1)
                    {
                        break;
                    }

                    listIndexes[current] = listIndex;
                }
            }

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;
                if (from > to)
                {
                    (from, to) = (to, from);
                }

                var days = 0;
                var current = from;

                while (current < to)
                {
                    var listIndex = listIndexes[current];
                    var currentList = reachableHotels[listIndex];
                    var currentIndex = currentList.BinarySearch(current);
                    var nextIndex = SearchExtensions.BoundaryBinarySearch(i => currentList[i] >= to, currentList.Count - 1, currentIndex);
                    days += nextIndex - currentIndex;
                    current = currentList[nextIndex];
                }

                yield return days;
            }
        }
    }
}
