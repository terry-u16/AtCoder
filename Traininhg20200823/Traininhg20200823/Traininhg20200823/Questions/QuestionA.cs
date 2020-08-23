using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Traininhg20200823.Algorithms;
using Traininhg20200823.Collections;
using Traininhg20200823.Extensions;
using Traininhg20200823.Numerics;
using Traininhg20200823.Questions;

namespace Traininhg20200823.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc176/tasks/abc176_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var (startRow, startColumn) = inputStream.ReadValue<int, int>();
            var (goalRow, goalColumn) = inputStream.ReadValue<int, int>();
            startRow--;
            startColumn--;
            goalRow--;
            goalColumn--;

            var canEnter = new bool[height][];
            for (int i = 0; i < canEnter.Length; i++)
            {
                canEnter[i] = inputStream.ReadLine().Select(c => c == '.').ToArray();
            }

            yield return Bfs();

            int Bfs()
            {
                const int Inf = 1 << 28;
                var todo = new Deque<(int row, int column)>();
                var distances = new int[height, width].SetAll((i, j) => Inf);
                distances[startRow, startColumn] = 0;
                todo.EnqueueFirst((startRow, startColumn));
                var adjacents = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

                while (todo.Count > 0)
                {
                    var (currentRow, currentColumn) = todo.DequeueFirst();
                    foreach (var (dr, dc) in adjacents)
                    {
                        var nextRow = currentRow + dr;
                        var nextColumn = currentColumn + dc;
                        var nextDistance = distances[currentRow, currentColumn];

                        if (InMap(nextRow, nextColumn, height, width) && canEnter[nextRow][nextColumn] && distances[nextRow, nextColumn] > nextDistance)
                        {
                            distances[nextRow, nextColumn] = nextDistance;
                            todo.EnqueueFirst((nextRow, nextColumn));
                        }
                    }


                    for (int dr = -2; dr <= 2; dr++)
                    {
                        for (int dc = -2; dc <= 2; dc++)
                        {
                            if ((Math.Abs(dr) <= 1 && dc == 0) || (dr == 0 && Math.Abs(dc) <= 1))
                            {
                                continue;
                            }

                            var nextRow = currentRow + dr;
                            var nextColumn = currentColumn + dc;
                            var nextDistance = distances[currentRow, currentColumn] + 1;

                            if (InMap(nextRow, nextColumn, height, width) && canEnter[nextRow][nextColumn] && distances[nextRow, nextColumn] > nextDistance)
                            {
                                distances[nextRow, nextColumn] = nextDistance;
                                todo.EnqueueLast((nextRow, nextColumn));
                            }
                        }
                    }
                }

                if (distances[goalRow, goalColumn] < Inf)
                {
                    return distances[goalRow, goalColumn];
                }
                else
                {
                    return -1;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool InMap(int row, int column, int height, int width) => unchecked((uint)row < height && (uint)column < width);
    }
}
