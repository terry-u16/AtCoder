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

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc170/tasks/abc170_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Inf = 1 << 28;
            var (height, width, length) = inputStream.ReadValue<int, int, int>();
            var (startRow, startColumn, goalRow, goalColumn) = inputStream.ReadValue<int, int, int, int>();
            var canEnter = new bool[height + 2][];
            canEnter[0] = Enumerable.Repeat(false, width + 2).ToArray();
            canEnter[^1] = Enumerable.Repeat(false, width + 2).ToArray();

            for (int row = 0; row < height; row++)
            {
                canEnter[row + 1] = new[] { false }.Concat(inputStream.ReadLine().Select(c => c == '.')).Concat(new[] { false }).ToArray();
            }

            int Bfs()
            {
                var distances = new int[height + 2, width + 2].SetAll((i, j) => Inf);
                var seen = new bool[height + 2, width + 2, 4];
                distances[startRow, startColumn] = 0;
                for (int dir = 0; dir < 4; dir++)
                {
                    seen[startRow, startColumn, dir] = true;
                }

                const int Left = 0;
                const int Right = 1;
                const int Up = 2;
                const int Down = 3;

                var todo = new Queue<(int row, int column)>();
                todo.Enqueue((startRow, startColumn));
                var directions = new (int dr, int dc, int dir)[] { (-1, 0, Left), (1, 0, Right), (0, -1, Up), (0, 1, Down) };
                var stack = new Stack<(int row, int column)>();

                while (todo.Count > 0)
                {
                    var (row, column) = todo.Dequeue();
                    var nextDistance = distances[row, column] + 1;

                    foreach (var (dr, dc, dir) in directions)
                    {
                        var nextRow = row;
                        var nextColumn = column;

                        for (int d = 1; d <= length; d++)
                        {
                            nextRow += dr;
                            nextColumn += dc;
                            if (canEnter[nextRow][nextColumn] && !seen[nextRow, nextColumn, dir])
                            {
                                seen[nextRow, nextColumn, dir] = true;
                                if (distances[nextRow, nextColumn] > nextDistance)
                                {
                                    distances[nextRow, nextColumn] = nextDistance;
                                    stack.Push((nextRow, nextColumn));
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        while (stack.Count > 0)
                        {
                            todo.Enqueue(stack.Pop());
                        }
                    }
                }

                return distances[goalRow, goalColumn];
            }

            var result = Bfs();

            if (result < Inf)
            {
                yield return result;
            }
            else
            {
                yield return -1;
            }
        }
    }
}
