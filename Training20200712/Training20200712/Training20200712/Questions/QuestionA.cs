using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200712.Algorithms;
using Training20200712.Collections;
using Training20200712.Extensions;
using Training20200712.Numerics;
using Training20200712.Questions;

namespace Training20200712.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        char[,] map;
        int width;
        int height;
        Square start;
        Square goal;
        const int MaxBreaks = 2;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (height, width) = inputStream.ReadValue<int, int>();
            map = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                var line = inputStream.ReadLine();
                for (int column = 0; column < line.Length; column++)
                {
                    map[row, column] = line[column];
                    switch (line[column])
                    {
                        case 's':
                            start = new Square(row, column);
                            break;
                        case 'g':
                            goal = new Square(row, column);
                            break;
                    }
                }
            }

            yield return Bfs() ? "YES" : "NO";
        }

        bool Bfs()
        {
            var todo = new Queue<SquareAndBreak>();
            var seen = new bool[height, width, MaxBreaks + 1];
            todo.Enqueue(new SquareAndBreak(start, 0));
            seen[start.Row, start.Column, 0] = true;
            Span<(int dr, int dc)> diffs = stackalloc[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            while (todo.Count > 0)
            {
                var ((currentRow, currentColumn), currentBreaks) = todo.Dequeue();

                foreach (var (dr, dc) in diffs)
                {
                    var nextRow = currentRow + dr;
                    var nextColumn = currentColumn + dc;

                    if (unchecked((uint)nextRow) >= height || unchecked((uint)nextColumn) >= width)
                    {
                        continue;
                    }

                    if (map[nextRow, nextColumn] != '#' && !seen[nextRow, nextColumn, currentBreaks])
                    {
                        todo.Enqueue(new SquareAndBreak(new Square(nextRow, nextColumn), currentBreaks));
                        seen[nextRow, nextColumn, currentBreaks] = true;
                    }
                    else if (map[nextRow, nextColumn] == '#' && currentBreaks < MaxBreaks && !seen[nextRow, nextColumn, currentBreaks + 1])
                    {
                        var nextBreaks = currentBreaks + 1;
                        todo.Enqueue(new SquareAndBreak(new Square(nextRow, nextColumn), nextBreaks));
                        seen[nextRow, nextColumn, nextBreaks] = true;
                    }
                }
            }

            return Enumerable.Range(0, MaxBreaks + 1).Any(count => seen[goal.Row, goal.Column, count]);
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

        [StructLayout(LayoutKind.Auto)]
        readonly struct SquareAndBreak
        {
            public Square Square { get; }
            public int Breaks { get; }

            public SquareAndBreak(Square square, int breaks)
            {
                Square = square;
                Breaks = breaks;
            }

            public void Deconstruct(out Square square, out int breaks) => (square, breaks) = (Square, Breaks);
            public override string ToString() => $"{nameof(Square)}: {Square}, {nameof(Breaks)}: {Breaks}";
        }
    }
}
