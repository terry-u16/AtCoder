using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using HTTF2021Elimination.Algorithms;
using HTTF2021Elimination.Collections;
using HTTF2021Elimination.Numerics;
using HTTF2021Elimination.Questions;

namespace HTTF2021Elimination.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var cards = new Coordinate[100];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = new Coordinate(io.ReadInt(), io.ReadInt());
            }

            var solver = new Solver(cards);
            var firstResult = solver.Solve();

            for (int i = 0; i < cards.Length; i++)
            {
                var (r, c) = cards[i];
                cards[i] = new Coordinate(c, r);
            }

            solver = new Solver(cards);
            var secondResult = solver.Solve();

            var firstScore = firstResult.Count(c => c == 'U' || c == 'D' || c == 'L' || c == 'R');
            var secondScore = secondResult.Count(c => c == 'U' || c == 'D' || c == 'L' || c == 'R');

            if (firstScore < secondScore)
            {
                io.WriteLine(firstResult);
            }
            else
            {
                var builder = new StringBuilder();

                foreach (var c in secondResult)
                {
                    builder.Append(c switch
                    {
                        'U' => 'L',
                        'L' => 'U',
                        'R' => 'D',
                        'D' => 'R',
                        _ => c
                    });
                }

                io.WriteLine(builder.ToString());
            }
        }
    }

    public class Solver
    {
        const int Size = 20;
        readonly Coordinate[] _cards;

        public Solver(Coordinate[] cards)
        {
            _cards = cards;
        }

        public string Solve()
        {
            var map = new int[Size, Size];
            map.Fill(-1);
            for (int i = 0; i < _cards.Length; i++)
            {
                var (r, c) = _cards[i];
                map[r, c] = i;
            }

            var takahashiRow = 0;
            var takahashiColumn = 0;
            var result = new StringBuilder();
            var stack = new Stack<int>();

            for (int row = 0; row < Size; row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 0; column < Size; column++)
                    {
                        CheckAndAdd(row, column);
                    }
                }
                else
                {
                    for (int column = Size - 1; column >= 0; column--)
                    {
                        CheckAndAdd(row, column);
                    }
                }

                void CheckAndAdd(int row, int column)
                {
                    if (map[row, column] != -1)
                    {
                        stack.Push(map[row, column]);
                        AppendMove(row - takahashiRow, column - takahashiColumn);
                        result.Append('I');
                        takahashiRow = row;
                        takahashiColumn = column;
                    }
                }
            }

            AppendMove(Size - 1 - takahashiRow, 0 - takahashiColumn);
            takahashiRow = Size - 1;
            takahashiColumn = 0;

            var currentCards = new Coordinate[_cards.Length];

            for (int row = Size - 1; row >= 10; row--)
            {
                if (row % 2 == 1)
                {
                    for (int column = 0; column < 10; column++)
                    {
                        Drop(row, column);
                    }
                }
                else
                {
                    for (int column = 10 - 1; column >= 0; column--)
                    {
                        Drop(row, column);
                    }
                }

                void Drop(int row, int column)
                {
                    currentCards[stack.Pop()] = new Coordinate(row, column);
                    AppendMove(row - takahashiRow, column - takahashiColumn);
                    result.Append('O');
                    takahashiRow = row;
                    takahashiColumn = column;
                }
            }

            foreach (var (row, column) in currentCards)
            {
                AppendMove(row - takahashiRow, column - takahashiColumn);
                result.Append('I');
                takahashiRow = row;
                takahashiColumn = column;
            }

            return result.ToString();

            void AppendMove(int dr, int dc)
            {
                if (dr > 0)
                {
                    result.Append('D', dr);
                }
                else if (dr < 0)
                {
                    result.Append('U', -dr);
                }

                if (dc > 0)
                {
                    result.Append('R', dc);
                }
                else
                {
                    result.Append('L', -dc);
                }
            }

        }
    }

    [StructLayout(LayoutKind.Auto)]
    readonly struct Card
    {
        public readonly int Number;
        public readonly Coordinate Coordinate;

        public Card(int number, Coordinate coordinate)
        {
            Number = number;
            Coordinate = coordinate;
        }

        public void Deconstruct(out int number, out Coordinate coordinate) => (number, coordinate) = (Number, Coordinate);
        public override string ToString() => $"{nameof(Number)}: {Number}, {nameof(Coordinate)}: {Coordinate}";
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct Coordinate
    {
        public readonly int Row;
        public readonly int Column;

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void Deconstruct(out int row, out int column) => (row, column) = (Row, Column);
        public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
    }
}
