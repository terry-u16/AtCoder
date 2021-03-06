﻿using System;
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

            var solver = new Solver(cards, 3.5);
            solver.Annealing(sw);

            io.WriteLine(solver.GetResult());
        }
    }

    public class Solver
    {
        const int Size = 20;
        const int TimeLimit = 2900;
        const int SecondRow = 10;
        const int SecondColumn = 0;
        readonly Coordinate[] _cards;
        readonly double _initialTemperature;

        /// <summary>
        /// <see cref="_takeOrder"/>[order] = card;
        /// </summary>
        readonly int[] _takeOrder;

        /// <summary>
        /// <see cref="_takeOrderInv"/>[card] = order;
        /// </summary>
        readonly int[] _takeOrderInv;
        readonly Coordinate[] _compressed;

        public Solver(Coordinate[] cards, double initialTemperature)
        {
            _cards = cards;
            _takeOrder = new int[cards.Length];
            _takeOrderInv = new int[cards.Length];
            _compressed = new Coordinate[cards.Length];
            _initialTemperature = initialTemperature;
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

            if (column > 10)
            {
                AppendMove(0, 10 - column);
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

            row = SecondRow;
            column = SecondColumn;

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

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public void Annealing(Stopwatch sw)
        {
            var random = new XorShift();
            var count = 0;
            var startTime = sw.ElapsedMilliseconds;
            var temperature = CalculateTemp(startTime, startTime, TimeLimit);

            while (true)
            {
                if (count++ % 10000 == 0)
                {
                    temperature = CalculateTemp(sw.ElapsedMilliseconds, startTime, TimeLimit);

                    if (sw.ElapsedMilliseconds >= TimeLimit)
                    {
                        break;
                    }
                }

                var cardA = random.Next(_takeOrderInv.Length);
                var cardB = random.Next(_takeOrderInv.Length);

                if (cardA == cardB)
                {
                    continue;
                }

                var prev = CalculateLocal(cardA, cardB);

                Swap(ref _takeOrderInv[cardA], ref _takeOrderInv[cardB]);
                Swap(ref _takeOrder[_takeOrderInv[cardA]], ref _takeOrder[_takeOrderInv[cardB]]);
                Swap(ref _compressed[cardA], ref _compressed[cardB]);

                var next = CalculateLocal(cardA, cardB);

                // 大きい方が優秀
                var diff = prev - next;

                if (!(diff >= 0 || random.NextDouble() <= Math.Exp(diff / temperature)))
                {
                    Swap(ref _takeOrderInv[cardA], ref _takeOrderInv[cardB]);
                    Swap(ref _takeOrder[_takeOrderInv[cardA]], ref _takeOrder[_takeOrderInv[cardB]]);
                    Swap(ref _compressed[cardA], ref _compressed[cardB]);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        int CalculateLocal(int cardNoA, int cardNoB)
        {
            var cost = 0;

            var cardA = _cards[cardNoA];
            var orderA = _takeOrderInv[cardNoA];
            var compA = _compressed[cardNoA];
            cost += GetCollectCost(cardA, orderA);
            cost += GetOrderCost(compA, cardNoA);

            var cardB = _cards[cardNoB];
            var orderB = _takeOrderInv[cardNoB];
            var compB = _compressed[cardNoB];
            cost += GetCollectCost(cardB, orderB);
            cost += GetOrderCost(compB, cardNoB);

            return cost;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        int GetCollectCost(Coordinate card, int order)
        {
            var last = new Coordinate();
            var prevOrder = order - 1;

            if (unchecked((uint)prevOrder < (uint)_takeOrder.Length))
            {
                last = _cards[_takeOrder[prevOrder]];
            }

            var cost = 0;
            cost += last.GetDistanceTo(card);

            var nextOrder = order + 1;
            if (unchecked((uint)nextOrder < (uint)_takeOrder.Length))
            {
                var nextCard = _cards[_takeOrder[nextOrder]];
                cost += card.GetDistanceTo(nextCard);
            }

            return cost;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        int GetOrderCost(Coordinate card, int cardNo)
        {
            var last = new Coordinate(SecondRow, SecondColumn);
            var prevNo = cardNo - 1;

            if (unchecked((uint)prevNo < (uint)_compressed.Length))
            {
                last = _compressed[prevNo];
            }

            var cost = 0;
            cost += last.GetDistanceTo(card);

            var nextNo = cardNo + 1;
            if (unchecked((uint)nextNo < (uint)_compressed.Length))
            {
                var nextCard = _compressed[nextNo];
                cost += card.GetDistanceTo(nextCard);
            }

            return cost;
        }

        double CalculateTemp(long currentTime, long startTime, long endTime)
        {
            double startTemp = _initialTemperature;
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

        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetDistanceTo(Coordinate other) => Math.Abs(Row - other.Row) + Math.Abs(Column - other.Column);

        public void Deconstruct(out int row, out int column) => (row, column) = (Row, Column);
        public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
    }
}
