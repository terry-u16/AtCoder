using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu099.Algorithms;
using Kujikatsu099.Collections;
using Kujikatsu099.Numerics;
using Kujikatsu099.Questions;

namespace Kujikatsu099.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc044/tasks/agc044_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var orders = io.ReadIntArray(n * n).Select(i => i - 1);

            var distances = new int[n, n];
            var absent = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distances[i, j] = Math.Min(Math.Min(Math.Min(i, j), n - 1 - i), n - 1 - j);
                }
            }

            var total = 0;

            foreach (var order in orders)
            {
                var row = order / n;
                var column = order % n;
                total += distances[row, column];
                absent[row, column] = true;
                BFS(row, column);
            }

            io.WriteLine(total);

            void BFS(int startRow, int startColumn)
            {
                Span<(int dr, int dc)> diffs = stackalloc (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
                var queue = new Queue<(int row, int column)>();

                foreach (var (dr, dc) in diffs)
                {
                    var row = startRow + dr;
                    var column = startColumn + dc;
                    if (InMap(row, column) && distances[row, column] > distances[startRow, startColumn])
                    {
                        distances[row, column] = distances[startRow, startColumn];
                        queue.Enqueue((row, column));
                    }
                }

                while (queue.Count > 0)
                {
                    var (row, column) = queue.Dequeue();

                    foreach (var (dr, dc) in diffs)
                    {
                        var nextRow = row + dr;
                        var nextColumn = column + dc;

                        if (InMap(nextRow, nextColumn))
                        {
                            var nextDistance = distances[row, column] + (absent[row, column] ? 0 : 1);
                            if (distances[nextColumn, nextColumn] > nextDistance)
                            {
                                distances[nextRow, nextColumn] = nextDistance;
                                queue.Enqueue((nextRow, nextColumn));
                            }
                        }
                    }
                }
            }

            bool InMap(int row, int column) => unchecked((uint)row < n && (uint)column < n);
        }
    }
}
