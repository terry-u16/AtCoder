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
using System.Diagnostics.CodeAnalysis;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joisc2010/tasks/joisc2010_finals
    /// </summary>
    public class QuestionI : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (citiesCount, roadsCount, k) = inputStream.ReadValue<int, int, long>();
            var roads = new PriorityQueue<Road>(false);
            for (int i = 0; i < roadsCount; i++)
            {
                var (a, b, c) = inputStream.ReadValue<int, int, int>();
                a--;
                b--;
                roads.Enqueue(new Road(a, b, c));
            }

            var cities = new UnionFindTree(citiesCount);
            var totalCost = 0;
            while (roads.Count > 0 && cities.Groups > k)
            {
                var road = roads.Dequeue();
                if (!cities.IsInSameGroup(road.From, road.To))
                {
                    cities.Unite(road.From, road.To);
                    totalCost += road.Cost;
                }
            }

            yield return totalCost;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Road : IComparable<Road>
        {
            public int From { get; }
            public int To { get; }
            public int Cost { get; }

            public Road(int from, int to, int cost)
            {
                From = from;
                To = to;
                Cost = cost;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(Cost)}: {Cost}";

            public int CompareTo([AllowNull] Road other) => Cost - other.Cost;
        }
    }
}
