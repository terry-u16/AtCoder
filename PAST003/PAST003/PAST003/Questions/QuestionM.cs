using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionM : AtCoderQuestionBase
    {
        List<int>[] roads;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (citiesCount, roadsCount) = inputStream.ReadValue<int, int>();
            roads = Enumerable.Repeat(0, citiesCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < roadsCount; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                u--;
                v--;
                roads[u].Add(v);
                roads[v].Add(u);
            }

            var start = inputStream.ReadInt() - 1;
            _ = inputStream.ReadInt();
            var toVisits = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            var costsFromStart = new int[toVisits.Length];
            var c = GetCostFrom(start);
            for (int i = 0; i < toVisits.Length; i++)
            {
                costsFromStart[i] = c[toVisits[i]];
            }

            var costsFrom = new int[toVisits.Length][];

            for (int i = 0; i < toVisits.Length; i++)
            {
                var costs = GetCostFrom(toVisits[i]);
                costsFrom[i] = new int[toVisits.Length];
                for (int j = 0; j < toVisits.Length; j++)
                {
                    costsFrom[i][j] = costs[toVisits[j]];
                }
            }

            dp = new int[(1 << (toVisits.Length + 1)), toVisits.Length + 1];
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    dp[i, j] = -1;
                }
            }

            var minCost = 1 << 28;
            for (int last = 0; last < toVisits.Length; last++)
            {
                var cost = GetMinCost(costsFrom, (1 << toVisits.Length) - 1, last) + costsFromStart[last];
                minCost = Math.Min(minCost, cost);
            }

            yield return minCost;
        }

        int[,] dp;
        int GetMinCost(int[][] costsFrom, int flag, int current)
        {
            if (dp[flag, current] != -1)
            {
                return dp[flag, current];
            }

            if (flag == (1 << current))
            {
                return dp[flag, current] = 0;
            }

            var result = 1 << 28;
            int prevBit = flag & ~(1 << current);

            for (int previous = 0; previous < costsFrom.Length; previous++)
            {
                if ((prevBit & (1 << previous)) == 0)
                {
                    continue;
                }

                result = Math.Min(result, GetMinCost(costsFrom, prevBit, previous) + costsFrom[previous][current]);
            }

            return dp[flag, current] = result;
        }

        int[] GetCostFrom(int start)
        {
            var seen = new bool[roads.Length];
            var costs = new int[roads.Length];
            var toDo = new Queue<int>();
            toDo.Enqueue(start);
            seen[start] = true;

            while (toDo.Count > 0)
            {
                var current = toDo.Dequeue();
                var cost = costs[current];

                foreach (var nextCity in roads[current])
                {
                    if (!seen[nextCity])
                    {
                        seen[nextCity] = true;
                        costs[nextCity] = cost + 1;
                        toDo.Enqueue(nextCity);
                    }
                }
            }

            return costs;
        }
    }
}
