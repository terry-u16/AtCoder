using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc088/tasks/abc088_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        int height;
        int width;
        char[,] map;
        const int Inf = 1 << 28;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (height, width) = inputStream.ReadValue<int, int>();
            map = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();
                for (int column = 0; column < width; column++)
                {
                    map[row, column] = s[column];
                }
            }

            var distance = Bfs()[height - 1, width - 1];

            if (distance == Inf)
            {
                yield return "-1";
            }
            else
            {
                var whiteCount = 0;
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
                    {
                        if (map[row, column] == '.')
                        {
                            whiteCount++;
                        }
                    }
                }
                yield return whiteCount - (distance + 1);
            }
        }

        int[,] Bfs()
        {
            var todo = new Queue<Grid>();
            var delta = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var distances = new int[height, width].SetAll((i, j) => Inf);

            todo.Enqueue(new Grid(0, 0));
            distances[0, 0] = 0;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                var currentDistance = distances[current.Row, current.Column];

                foreach (var (dr, dc) in delta)
                {
                    var next = new Grid(current.Row + dr, current.Column + dc);
                    if (next.In(height, width) && distances[next.Row, next.Column] == Inf && map[next.Row, next.Column] == '.')
                    {
                        todo.Enqueue(next);
                        distances[next.Row, next.Column] = currentDistance + 1;
                    }
                }
            }

            return distances;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Grid
        {
            public int Row { get; }
            public int Column { get; }

            public Grid(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public bool In(int height, int width) => unchecked((uint)Row) < height && unchecked((uint)Column) < width;
            public void Deconstruct(out int row, out int column) => (row, column) = (Row, Column);
            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
        }
    }
}
