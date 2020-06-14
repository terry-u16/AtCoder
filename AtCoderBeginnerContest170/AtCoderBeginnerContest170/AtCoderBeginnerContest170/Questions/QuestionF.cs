using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest170.Algorithms;
using AtCoderBeginnerContest170.Collections;
using AtCoderBeginnerContest170.Extensions;
using AtCoderBeginnerContest170.Graphs;
using AtCoderBeginnerContest170.Numerics;
using AtCoderBeginnerContest170.Questions;

namespace AtCoderBeginnerContest170.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        const int Inf = 1 << 28;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            var (sx, sy, gx, gy) = inputStream.ReadValue<int, int, int, int>();

            var map = new char[height + 2][];

            map[0] = Enumerable.Repeat('@', width + 2).ToArray();
            for (int row = 0; row < height; row++)
            {
                map[row + 1] = ("@" + inputStream.ReadLine() + "@").ToArray();
            }

            map[height + 1] = Enumerable.Repeat('@', width + 2).ToArray();
            var distances = Bfs(map, new Node(sx, sy), new Node(gx, gy), k);

            yield return distances[gx, gy] != Inf ? distances[gx, gy] : -1;
        }

        struct Node
        {
            public int Row { get; }
            public int Column { get; }

            public Node(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }

        int[,] Bfs(char[][] map, Node start, Node goal, int k)
        {
            var height = map.Length - 2;
            var width = map[0].Length - 2;
            var distances = new int[height + 2, width + 2];
            for (int row = 0; row < distances.GetLength(0); row++)
            {
                for (int column = 0; column < distances.GetLength(1); column++)
                {
                    distances[row, column] = Inf;
                }
            }
            distances[start.Row, start.Column] = 0;
            var up = new bool[height + 2, width + 2];
            var down = new bool[height + 2, width + 2];
            var left = new bool[height + 2, width + 2];
            var right = new bool[height + 2, width + 2];

            var todo = new Queue<Node>();
            todo.Enqueue(start);

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();

                for (int i = 1; i <= k; i++)
                {
                    var next = new Node(current.Row + i, current.Column);
                    if (map[next.Row][next.Column] == '@' || distances[next.Row, next.Column] <= distances[current.Row, current.Column])
                    {
                        break;
                    }
                    else if (distances[next.Row, next.Column] < Inf)
                    {
                        continue;
                    }
                    todo.Enqueue(next);
                    distances[next.Row, next.Column] = distances[current.Row, current.Column] + 1;
                    up[next.Row, next.Column] = true;
                }

                for (int i = 1; i <= k; i++)
                {
                    var next = new Node(current.Row - i, current.Column);
                    if (map[next.Row][next.Column] == '@' || distances[next.Row, next.Column] <= distances[current.Row, current.Column])
                    {
                        break;
                    }
                    else if (distances[next.Row, next.Column] < Inf)
                    {
                        continue;
                    }
                    todo.Enqueue(next);
                    distances[next.Row, next.Column] = distances[current.Row, current.Column] + 1;
                    down[next.Row, next.Column] = true;
                }

                for (int i = 1; i <= k; i++)
                {
                    var next = new Node(current.Row, current.Column + i);
                    if (map[next.Row][next.Column] == '@' || distances[next.Row, next.Column] <= distances[current.Row, current.Column])
                    {
                        break;
                    }
                    else if (distances[next.Row, next.Column] < Inf)
                    {
                        continue;
                    }
                    todo.Enqueue(next);
                    distances[next.Row, next.Column] = distances[current.Row, current.Column] + 1;
                    left[next.Row, next.Column] = true;
                }

                for (int i = 1; i <= k; i++)
                {
                    var next = new Node(current.Row, current.Column - i);
                    if (map[next.Row][next.Column] == '@' || distances[next.Row, next.Column] <= distances[current.Row, current.Column])
                    {
                        break;
                    }
                    else if (distances[next.Row, next.Column] < Inf)
                    {
                        continue;
                    }
                    todo.Enqueue(next);
                    distances[next.Row, next.Column] = distances[current.Row, current.Column] + 1;
                    right[next.Row, next.Column] = true;
                }

                if (distances[goal.Row, goal.Column] < Inf)
                {
                    break;
                }
            }

            return distances;
        }
    }
}
