using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderGrandContest044.Algorithms;
using AtCoderGrandContest044.Collections;
using AtCoderGrandContest044.Extensions;
using AtCoderGrandContest044.Numerics;
using AtCoderGrandContest044.Questions;

namespace AtCoderGrandContest044.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        List<Edge>[] edges;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var people = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var seats = new int[n, n];

            for (int i = 0; i < people.Length; i++)
            {
                var person = people[i];
                var row = person / n;
                var column = person % n;
                seats[row, column] = i;
            }

            edges = Enumerable.Range(0, people.Length + 1).Select(_ => new List<Edge>()).ToArray();

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    var me = seats[row, column];
                    var index = row * n + column;
                    if (row - 1 >= 0)
                    {
                        edges[index].Add(new Edge(index - n, me > seats[row - 1, column] ? 1 : 0));
                    }
                    if (row + 1 < n)
                    {
                        edges[index].Add(new Edge(index + n, me > seats[row + 1, column] ? 1 : 0));
                    }
                    if (column - 1 >= 0)
                    {
                        edges[index].Add(new Edge(index - 1, me > seats[row, column - 1] ? 1 : 0));
                    }
                    if (column + 1 < n)
                    {
                        edges[index].Add(new Edge(index + 1, me > seats[row, column + 1] ? 1 : 0));
                    }

                    if (row == 0 || row == n - 1 || column == 0 || column == n - 1)
                    {
                        edges[index].Add(new Edge(n * n, 0));
                        edges[n * n].Add(new Edge(index, 0));
                    }
                }
            }

            var costs = GetMinCostsFrom(n * n, edges);
            yield return costs.Sum();
        }

        int[] GetMinCostsFrom(int start, List<Edge>[] edges)
        {
            var costs = Enumerable.Repeat(1 << 28, edges.Length).ToArray();

            var queue = new PriorityQueue<DPState>(false);
            queue.Enqueue(new DPState(start, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.TotalCost > costs[current.Point])
                {
                    continue;
                }

                foreach (var edge in edges[current.Point])
                {
                    var currentCost = current.TotalCost + edge.Cost;
                    if (costs[edge.To] > currentCost)
                    {
                        costs[edge.To] = currentCost;
                        queue.Enqueue(new DPState(edge.To, currentCost));
                    }
                }
            }

            return costs;
        }


        struct Edge
        {
            public int To { get; }
            public int Cost { get; }

            public Edge(int to, int distance)
            {
                To = to;
                Cost = distance;
            }

            public override string ToString() => $"--{Cost:0}-->{To}";
        }

        struct DPState : IComparable<DPState>
        {
            public int Point { get; }
            public int TotalCost { get; }

            public DPState(int point, int totalDistance)
            {
                Point = point;
                TotalCost = totalDistance;
            }

            public int CompareTo(DPState other) => TotalCost.CompareTo(other.TotalCost);
        }

    }
}
