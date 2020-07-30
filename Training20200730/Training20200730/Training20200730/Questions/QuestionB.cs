using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200730.Algorithms;
using Training20200730.Collections;
using Training20200730.Extensions;
using Training20200730.Numerics;
using Training20200730.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200730.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc040/tasks/abc040_d
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cityCount, roadCount) = inputStream.ReadValue<int, int>();
            var roads = GetRoads(inputStream, roadCount);
            var queries = inputStream.ReadInt();
            var people = new Person[queries];
            for (int i = 0; i < people.Length; i++)
            {
                var (v, w) = inputStream.ReadValue<int, int>();
                v--;
                people[i] = new Person(v, w, i);
            }
            Array.Sort(people);
            var results = new int[queries];
            var unionFind = new UnionFindTree(cityCount);

            for (int i = 0; i < people.Length; i++)
            {
                while (roads.Count > 0 && roads.Peek().Year > people[i].Year)
                {
                    var road = roads.Dequeue();
                    unionFind.Unite(road.From, road.To);
                }

                results[people[i].Index] = unionFind.GetGroupSizeOf(people[i].From);
            }

            foreach (var result in results)
            {
                yield return result;
            }
        }

        Queue<Road> GetRoads(TextReader inputStream, int roadCount)
        {
            var roads = new Road[roadCount];
            for (int i = 0; i < roads.Length; i++)
            {
                var (a, b, y) = inputStream.ReadValue<int, int, int>();
                a--;
                b--;
                roads[i] = new Road(a, b, y);
            }
            Array.Sort(roads);
            return new Queue<Road>(roads);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Road : IComparable<Road>
        {
            public int From { get; }
            public int To { get; }
            public int Year { get; }

            public Road(int from, int to, int year)
            {
                From = from;
                To = to;
                Year = year;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
            public int CompareTo([AllowNull] Road other) => -(Year - other.Year);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Person : IComparable<Person>
        {
            public int From { get; }
            public int Year { get; }
            public int Index { get; }

            public Person(int from, int year, int index)
            {
                From = from;
                Year = year;
                Index = index;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(Year)}: {Year}";
            public int CompareTo([AllowNull] Person other) => -(Year - other.Year);
        }
    }
}
