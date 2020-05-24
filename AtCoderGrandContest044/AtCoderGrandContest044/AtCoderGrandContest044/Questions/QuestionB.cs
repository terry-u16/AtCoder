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
    /// <summary>
    /// 復習
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var people = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var costs = GetInitializedCost(n);
            var isVacant = new bool[n, n];

            var totalCost = 0;
            foreach (var person in people)
            {
                var (row, column) = ToRowAndColumn(person, n);
                totalCost += costs[row, column];
                isVacant[row, column] = true;
                UpdateCosts(costs, isVacant, row, column);
            }

            yield return totalCost;
        }

        int[,] GetInitializedCost(int n)
        {
            var costs = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    var cost = Math.Min(Math.Min(Math.Min(row, n - 1 - row), column), n - 1 - column);
                    costs[row, column] = cost;
                }
            }

            return costs;
        }

        void UpdateCosts(int[,] costs, bool[,] isVacant, int lastRow, int lastColumn)
        {
            var n = costs.GetLength(0);
            var todo = new Queue<(int row, int column)>();
            todo.Enqueue((lastRow, lastColumn));
            Span<(int dy, int dx)> delta = stackalloc (int, int)[4] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            while (todo.Count > 0)
            {
                var (row, column) = todo.Dequeue();
                var vacant = isVacant[row, column];
                var currentCost = costs[row, column];

                foreach (var (dy, dx) in delta)
                {
                    var nextRow = row + dy;
                    var nextColumn = column + dx;
                    if ((uint)nextRow >= (uint)n || (uint)nextColumn >= (uint)n)
                    {
                        continue;
                    }

                    var nextCost = currentCost + (vacant ? 0 : 1);
                    if (costs[nextRow, nextColumn] > nextCost)
                    {
                        costs[nextRow, nextColumn] = nextCost;
                        todo.Enqueue((nextRow, nextColumn));
                    }
                }
            }
        }

        (int row, int column) ToRowAndColumn(int i, int n) => (i / n, i % n);
    }
}
