using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc176/tasks/abc176_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const int INF = 1 << 28;
            var height = io.ReadInt();
            var width = io.ReadInt();
            var startRow = io.ReadInt() - 1;
            var startColumn = io.ReadInt() - 1;
            var goalRow = io.ReadInt() - 1;
            var goalColumn = io.ReadInt() - 1;

            var map = new char[height][];

            for (int row = 0; row < map.Length; row++)
            {
                map[row] = io.ReadString().ToCharArray();
            }

            var distances = Bfs(startRow, startColumn);

            if (distances[goalRow, goalColumn] < INF)
            {
                io.WriteLine(distances[goalRow, goalColumn]);
            }
            else
            {
                io.WriteLine(-1);
            }

            int[,] Bfs(int startRow, int startColumn)
            {
                var distances = new int[height, width].Fill(INF);
                distances[startRow, startColumn] = 0;
                var queue = new Deque<(int row, int column)>();
                Span<(int dr, int dc)> diffs = stackalloc (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
                queue.EnqueueFirst((startRow, startColumn));

                while (queue.Count > 0)
                {
                    var (row, column) = queue.DequeueFirst();

                    foreach (var (dr, dc) in diffs)
                    {
                        var nextRow = row + dr;
                        var nextColumn = column + dc;

                        if (CanEnter(nextRow, nextColumn) && distances[nextRow, nextColumn] > distances[row, column])
                        {
                            distances[nextRow, nextColumn] = distances[row, column];
                            queue.EnqueueFirst((nextRow, nextColumn));
                        }
                    }

                    for (int dr = -2; dr <= 2; dr++)
                    {
                        for (int dc = -2; dc <= 2; dc++)
                        {
                            var nextRow = row + dr;
                            var nextColumn = column + dc;
                            var nextDistance = distances[row, column] + 1;

                            if (CanEnter(nextRow, nextColumn) && distances[nextRow, nextColumn] > nextDistance)
                            {
                                distances[nextRow, nextColumn] = nextDistance;
                                queue.EnqueueLast((nextRow, nextColumn));
                            }
                        }
                    }
                }

                return distances;
            }

            bool CanEnter(int row, int column) => unchecked((uint)row < height && (uint)column < width) && map[row][column] != '#';
        }
    }
}
