using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu066.Algorithms;
using Kujikatsu066.Collections;
using Kujikatsu066.Extensions;
using Kujikatsu066.Numerics;
using Kujikatsu066.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc170/tasks/abc170_f
    /// </summary>
    public class QuestionF2 : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const long Inf = 1L << 60;
            var (height, width, skateLength) = inputStream.ReadValue<int, int, int>();
            var (startRow, startColumn, goalRow, goalColumn) = inputStream.ReadValue<int, int, int, int>();
            var canEnter = new bool[height + 2][];
            canEnter[0] = Enumerable.Repeat(false, width + 2).ToArray();
            canEnter[^1] = Enumerable.Repeat(false, width + 2).ToArray();

            for (int row = 0; row < height; row++)
            {
                canEnter[row + 1] = new[] { false }.Concat(inputStream.ReadLine().Select(c => c == '.')).Concat(new[] { false }).ToArray();
            }

            long Dijkstra()
            {
                const int Left = 0;
                const int Right = 1;
                const int Up = 2;
                const int Down = 3;

                var distances = new long[height + 2, width + 2, 4].SetAll((i, j, k) => Inf);
                var todo = new PriorityQueue<DpState>(false);

                for (int direction = 0; direction < 4; direction++)
                {
                    distances[startRow, startColumn, direction] = 0;
                    todo.Enqueue(new DpState(startRow, startColumn, direction, 0));
                }

                var directions = new int[] { Left, Right, Up, Down };
                var diffs = new (int dr, int dc)[] { (0, -1), (0, 1), (-1, 0), (1, 0)};

                while (todo.Count > 0)
                {
                    var current = todo.Dequeue();

                    if (current.Distance > distances[current.Row, current.Column, current.Direction])
                    {
                        continue;
                    }
                    
                    foreach (var nextDirection in directions)
                    {
                        if (nextDirection == current.Direction)
                        {
                            // 直進
                            var nextDistance = distances[current.Row, current.Column, current.Direction] + 1;
                            var (dr, dc) = diffs[current.Direction];
                            var nextRow = current.Row + dr;
                            var nextColumn = current.Column + dc;

                            if (canEnter[nextRow][nextColumn] && distances[nextRow, nextColumn, current.Direction] > nextDistance)
                            {
                                distances[nextRow, nextColumn, current.Direction] = nextDistance;
                                todo.Enqueue(new DpState(nextRow, nextColumn, current.Direction, nextDistance));
                            }
                        }
                        else
                        {
                            // 方向転換
                            var nextDistance = RoundUp(distances[current.Row, current.Column, current.Direction], skateLength);

                            if (distances[current.Row, current.Column, nextDirection] > nextDistance)
                            {
                                distances[current.Row, current.Column, nextDirection] = nextDistance;
                                todo.Enqueue(new DpState(current.Row, current.Column, nextDirection, nextDistance));
                            }
                        }
                    }
                }

                var minDistance = Inf;

                for (int direction = 0; direction < 4; direction++)
                {
                    minDistance = Math.Min(minDistance, distances[goalRow, goalColumn, direction]);
                }

                return minDistance;
            }

            var result = Dijkstra();

            if (result < Inf)
            {
                yield return (result + skateLength - 1) / skateLength;
            }
            else
            {
                yield return -1;
            }
        }

        long RoundUp(long n, long div) => (n + div - 1) / div * div;

        [StructLayout(LayoutKind.Auto)]
        class DpState : IComparable<DpState>
        {
            public int Row { get; }
            public int Column { get; }
            public int Direction { get; }
            public long Distance { get; }

            public DpState(int row, int column, int direction, long distance)
            {
                Row = row;
                Column = column;
                Direction = direction;
                Distance = distance;
            }

            public override string ToString() => $"({Row}, {Column}),  {nameof(Direction)}: {Direction}, {nameof(Distance)}: {Distance}";

            public int CompareTo([AllowNull] DpState other) => Math.Sign(Distance - other.Distance);
        }
    }
}
