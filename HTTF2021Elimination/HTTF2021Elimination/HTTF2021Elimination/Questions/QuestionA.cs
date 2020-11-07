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
            var sw = new Stopwatch();
            sw.Start();

            var cards = new Coordinate[100];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = new Coordinate(io.ReadInt(), io.ReadInt());
            }

            var solver = new Solver(cards);
            solver.Annealing(sw);

            io.WriteLine(solver.GetResult());
        }
    }

    public class Solver
    {
        const int Size = 20;
        const int TimeLimit = 2900;
        readonly Coordinate[] _cards;
        readonly int[] _takeOrder;
        readonly int[] _takeOrderInv;
        readonly Coordinate[] _compressed;

        public Solver(Coordinate[] cards)
        {
            _cards = cards;
            _takeOrder = new int[cards.Length];
            _takeOrderInv = new int[cards.Length];
            _compressed = new Coordinate[cards.Length];
            Initialize();
        }

        public string GetResult()
        {
            var result = new StringBuilder();
            var row = 0;
            var column = 0;

            foreach (var i in _takeOrder)
            {
                var (r, c) = _cards[i];
                AppendMove(r - row, c - column);
                result.Append('I');
                row = r;
                column = c;
            }

            if (row < 9)
            {
                AppendMove(9 - row, 0);
            }

            if (column > 9)
            {
                AppendMove(0, 9 - column);
            }

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    result.Append('O');

                    if (c < 9)
                    {
                        if (r % 2 == 0)
                        {
                            result.Append('R');
                        }
                        else
                        {
                            result.Append('L');
                        }
                    }
                    else if (r < 9)
                    {
                        result.Append('U');
                    }
                }
            }

            row = 10;
            column = 0;

            foreach (var (r, c) in _compressed)
            {
                AppendMove(r - row, c - column);
                result.Append('I');
                row = r;
                column = c;
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

        public void Annealing(Stopwatch sw)
        {
            var random = new XorShift();
            var prev = CalculateCost();
            var count = 0;
            var startTime = sw.ElapsedMilliseconds;
            var temp = CalculateTemp(startTime, startTime, TimeLimit);

            while (sw.ElapsedMilliseconds < TimeLimit)
            {
                var cardA = random.Next(_takeOrder.Length);
                var cardB = random.Next(_takeOrder.Length);

                if (count++ % 100 == 0)
                {
                    temp = CalculateTemp(sw.ElapsedMilliseconds, startTime, TimeLimit);
                }

                if (cardA == cardB)
                {
                    continue;
                }

                Swap(ref _takeOrderInv[cardA], ref _takeOrderInv[cardB]);
                Swap(ref _takeOrder[_takeOrderInv[cardA]], ref _takeOrder[_takeOrderInv[cardB]]);
                Swap(ref _compressed[cardA], ref _compressed[cardB]);
                var next = CalculateCost();

                // 小さい方が優秀
                var diff = prev - next;

                if (diff >= 0 || random.NextDouble() <= Math.Exp(diff / temp))
                {
                    prev = next;
                }
                else
                {
                    Swap(ref _takeOrderInv[cardA], ref _takeOrderInv[cardB]);
                    Swap(ref _takeOrder[_takeOrderInv[cardA]], ref _takeOrder[_takeOrderInv[cardB]]);
                    Swap(ref _compressed[cardA], ref _compressed[cardB]);
                }
            }
        }

        double CalculateTemp(long currentTime, long startTime, long endTime)
        {
            const double startTemp = 10;
            const double endTemp = 0;
            var duration = endTime - startTime;
            var dt = currentTime - startTime;
            var temp = startTemp + (endTemp - startTemp) * dt / duration;
            return temp;
        }

        void Initialize()
        {
            var map = new int[Size, Size];
            map.Fill(-1);
            for (int i = 0; i < _cards.Length; i++)
            {
                var (r, c) = _cards[i];
                map[r, c] = i;
            }

            var stack = new Stack<int>();

            var takenIndex = 0;

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
                        _takeOrder[takenIndex] = map[row, column];
                        _takeOrderInv[map[row, column]] = takenIndex++;
                        stack.Push(map[row, column]);
                    }
                }
            }

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
                    var card = stack.Pop();
                    _compressed[card] = new Coordinate(row, column);
                }
            }
        }

        int CalculateCost()
        {
            var cost = 0;
            var row = 0;
            var column = 0;

            foreach (var i in _takeOrder)
            {
                var (r, c) = _cards[i];
                cost += GetDistance(row - r, column - c);
                row = r;
                column = c;
            }

            (row, column) = _compressed[_takeOrder[0]];

            foreach (var (r, c) in _compressed)
            {
                cost += GetDistance(row - r, column - c);
                row = r;
                column = c;
            }

            return cost;
        }

        int GetDistance(int dr, int dc) => Math.Abs(dr) + Math.Abs(dc);

        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
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
