using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikastu034.Algorithms;
using Kujikastu034.Collections;
using Kujikastu034.Extensions;
using Kujikastu034.Numerics;
using Kujikastu034.Questions;

namespace Kujikastu034.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc151/tasks/abc151_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        const int Inf = 1 << 30;
        char[][] map;
        int height;
        int width;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (height, width) = inputStream.ReadValue<int, int>();
            map = new char[height][];

            for (int row = 0; row < height; row++)
            {
                map[row] = inputStream.ReadLine().ToCharArray();
            }

            var max = 0;
            for (int startRow = 0; startRow < height; startRow++)
            {
                for (int startColumn = 0; startColumn < width; startColumn++)
                {
                    if (map[startRow][startColumn] == '.')
                    {
                        var distances = GetDistanceFrom(new Square(startRow, startColumn));
                        for (int goalRow = 0; goalRow < height; goalRow++)
                        {
                            for (int goalColumn = 0; goalColumn < width; goalColumn++)
                            {
                                if (map[goalRow][goalColumn] == '.' && distances[goalRow, goalColumn] != Inf)
                                {
                                    max = Math.Max(max, distances[goalRow, goalColumn]);
                                }
                            }
                        }
                    }
                }
            }

            yield return max;
        }

        int[,] GetDistanceFrom(Square start)
        {
            var todo = new Queue<Square>();
            var distances = new int[height, width];
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    distances[row, column] = Inf;
                }
            }

            todo.Enqueue(start);
            distances[start.Row, start.Column] = 0;
            Span<(int dr, int dc)> diff = stackalloc (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();

                foreach (var (dr, dc) in diff)
                {
                    var nextRow = current.Row + dr;
                    var nextColumn = current.Column + dc;

                    if (unchecked((uint)nextRow < height && (uint)nextColumn < width) && distances[nextRow, nextColumn] == Inf && map[nextRow][nextColumn] == '.')
                    {
                        distances[nextRow, nextColumn] = distances[current.Row, current.Column] + 1;
                        todo.Enqueue(new Square(nextRow, nextColumn));
                    }
                }
            }

            return distances;   
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Square
        {
            public int Row { get; }
            public int Column { get; }

            public Square(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public void Deconstruct(out int row, out int column) => (row, column) = (Row, Column);
            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
        }
    }
}
