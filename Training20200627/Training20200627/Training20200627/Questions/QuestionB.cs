using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200627.Algorithms;
using Training20200627.Collections;
using Training20200627.Extensions;
using Training20200627.Numerics;
using Training20200627.Questions;

namespace Training20200627.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc018/tasks/abc018_3
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            var map = new char[height + 2][];

            map[0] = Enumerable.Repeat('x', width + 2).ToArray();
            map[height + 1] = Enumerable.Repeat('x', width + 2).ToArray();
            for (int row = 0; row < height; row++)
            {
                map[row + 1] = ("x" + inputStream.ReadLine() + "x").ToCharArray();
            }

            var distances = new int[height + 2, width + 2].SetAll((i, j) => 1 << 28);
            var todo = new Queue<Grid>();

            for (int r = 0; r < map.Length; r++)
            {
                for (int c = 0; c < map[r].Length; c++)
                {
                    if (map[r][c] == 'x')
                    {
                        distances[r, c] = 0;
                        todo.Enqueue(new Grid(r, c));
                    }
                }
            }

            Span<(int, int)> diffs = stackalloc (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var (dr, dc) in diffs)
                {
                    var next = new Grid(current.Row + dr, current.Column + dc);
                    if (next.In(height + 2, width + 2) && distances[next.Row, next.Column] > distances[current.Row, current.Column] + 1)
                    {
                        distances[next.Row, next.Column] = distances[current.Row, current.Column] + 1;
                        todo.Enqueue(next);
                    }
                }
            }

            var count = 0;
            for (int r = 0; r < height + 2; r++)
            {
                for (int c = 0; c < width + 2; c++)
                {
                    if (distances[r, c] >= k)
                    {
                        count++;
                    }
                }
            }

            return new object[] { count };
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

            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";

            public bool In(int height, int width) => unchecked((uint)Row) < height && unchecked((uint)Column) < width;
        }
    }
}
