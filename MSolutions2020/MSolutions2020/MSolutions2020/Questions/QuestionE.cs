using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MSolutions2020.Algorithms;
using MSolutions2020.Collections;
using MSolutions2020.Extensions;
using MSolutions2020.Numerics;
using MSolutions2020.Questions;

namespace MSolutions2020.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        Town[] towns;
        long[] minDistances;
        long[][] minDistancesVertical;
        long[][] minDistancesHorizontal;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            towns = new Town[n];
            minDistances = Enumerable.Repeat(long.MaxValue, n + 1).ToArray();

            for (int i = 0; i < n; i++)
            {
                var (x, y, p) = inputStream.ReadValue<int, int, int>();
                towns[i] = new Town(new Coordinate(x, y), p);
            }

            minDistancesVertical = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(1L << 50, 1 << n).ToArray()).ToArray();
            minDistancesHorizontal = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(1L << 50, 1 << n).ToArray()).ToArray();

            for (int i = 0; i < towns.Length; i++)
            {
                var town = towns[i];
                for (var roads = BitSet.Zero; roads < (1 << towns.Length); roads++)
                {
                    long minV = town.GetTotalDistance(Math.Abs(town.Coordinate.X));
                    for (int v = 0; v < towns.Length; v++)
                    {
                        if (roads[v])
                        {
                            minV = Math.Min(minV, town.GetTotalDistance(Math.Abs(town.Coordinate.X - towns[v].Coordinate.X)));
                        }
                    }
                    minDistancesVertical[i][roads] = Math.Min(minDistancesVertical[i][roads], minV);
                     

                    var minH = town.GetTotalDistance(Math.Abs(town.Coordinate.Y));
                    for (int h = 0; h < towns.Length; h++)
                    {
                        if (roads[h])
                        {
                            minH = Math.Min(minH, town.GetTotalDistance(Math.Abs(town.Coordinate.Y - towns[h].Coordinate.Y)));
                        }
                    }
                    minDistancesHorizontal[i][roads] = Math.Min(minDistancesHorizontal[i][roads], minH);
                }
            }


            Dfs(BitSet.Zero, BitSet.Zero, 0);

            for (int i = 0; i <= n; i++)
            {
                yield return minDistances[i];
            }
        }

        void Dfs(BitSet verticals, BitSet horizontals, int current)
        {
            if (current == towns.Length)
            {
                var constructed = verticals.Count() + horizontals.Count();
                long total = 0;
                for (int i = 0; i < towns.Length; i++)
                {
                    total += Math.Min(minDistancesVertical[i][verticals], minDistancesHorizontal[i][horizontals]);
                }
                minDistances[constructed] = Math.Min(minDistances[constructed], total);
            }
            else
            {
                Dfs(verticals, horizontals, current + 1);
                Dfs(verticals | new BitSet(1u << current), horizontals, current + 1);
                Dfs(verticals, horizontals | new BitSet(1u << current), current + 1);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Coordinate
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Town
        {
            public Coordinate Coordinate { get; }
            public int Population { get; }

            public Town(Coordinate coordinate, int population)
            {
                Coordinate = coordinate;
                Population = population;
            }

            public long GetTotalDistance(int distance) => (long)distance * Population;
            public void Deconstruct(out Coordinate arg1, out int arg2) => (arg1, arg2) = (Coordinate, Population);
            public override string ToString() => $"{nameof(Coordinate)}: {Coordinate}, {nameof(Population)}: {Population}";
        }
    }
}
