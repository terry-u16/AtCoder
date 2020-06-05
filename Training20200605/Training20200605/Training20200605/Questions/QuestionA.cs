using Training20200605.Questions;
using Training20200605.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200605.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc033/tasks/agc033_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var height = hw[0];
            var width = hw[1];

            var map = new int[height, width];

            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();

                for (int column = 0; column < s.Length; column++)
                {
                    map[row, column] = s[column] == '#' ? 0 : -1;
                }
            }

            Paint(map);

            var max = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    max = Math.Max(max, map[row, column]);
                }
            }

            yield return max;
        }

        void Paint(int[,] map)
        {
            var todo = new Queue<Coordinate>();
            var height = map.GetLength(0);
            var width = map.GetLength(1);

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (map[row, column] == 0)
                    {
                        todo.Enqueue(new Coordinate(row, column));
                    }
                }
            }

            var diffs = new Diff[] { new Diff(-1, 0), new Diff(1, 0), new Diff(0, -1), new Diff(0, 1) };

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();

                foreach (var diff in diffs)
                {
                    var next = current + diff;
                    if (!next.InMap(height, width) || map[next.Row, next.Column] >= 0)
                    {
                        continue;
                    }

                    map[next.Row, next.Column] = map[current.Row, current.Column] + 1;
                    todo.Enqueue(next);
                }
            }
        }

        struct Coordinate
        {
            public int Row { get; }
            public int Column { get; }

            public Coordinate(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public bool InMap(int height, int width)
            {
                unchecked
                {
                    return (uint)Row < height && (uint)Column < width;
                }
            }
        }

        struct Diff
        {
            public int DY { get; }
            public int DX { get; }

            public Diff(int dy, int dx)
            {
                DY = dy;
                DX = dx;
            }

            public static Coordinate operator +(Coordinate coordinate, Diff diff) => new Coordinate(coordinate.Row + diff.DY, coordinate.Column + diff.DX);
        }
    }
}
