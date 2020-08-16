using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200724.Algorithms;
using Training20200724.Collections;
using Training20200724.Extensions;
using Training20200724.Numerics;
using Training20200724.Questions;

namespace Training20200724.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/aising2019/tasks/aising2019_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        char[,] map;
        bool[,] seen;
        int height;
        int width;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (height, width) = inputStream.ReadValue<int, int>();
            map = new char[height, width];
            seen = new bool[height, width];

            for (int i = 0; i < height; i++)
            {
                var s = inputStream.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    map[i, j] = s[j];
                }
            }

            long total = 0;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (map[row, column] == '#' && !seen[row, column])
                    {
                        var (blacks, whites) = Search(new Square(row, column));
                        total += blacks * whites;
                    }
                }
            }

            yield return total;
        }

        (long blacks, long whites) Search(Square start)
        {
            var todo = new Queue<Square>();
            todo.Enqueue(start);
            seen[start.Row, start.Column] = true;
            Span<(int, int)> diffs = stackalloc[] { (0, -1), (0, 1), (-1, 0), (1, 0) };

            long blacks = 1;
            long whites = 0;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                var currentColor = map[current.Row, current.Column];
                foreach (var (dr, dc) in diffs)
                {
                    var nextRow = current.Row + dr;
                    var nextColumn = current.Column + dc;
                    if (unchecked((uint)nextRow < height && (uint)nextColumn < width) && !seen[nextRow, nextColumn])
                    {
                        var nextColor = map[nextRow, nextColumn];
                        if (currentColor != nextColor)
                        {
                            todo.Enqueue(new Square(nextRow, nextColumn));
                            seen[nextRow, nextColumn] = true;
                            if (nextColor == '#')
                            {
                                blacks++;
                            }
                            else
                            {
                                whites++;
                            }
                        }
                    }
                }
            }

            return (blacks, whites);
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
