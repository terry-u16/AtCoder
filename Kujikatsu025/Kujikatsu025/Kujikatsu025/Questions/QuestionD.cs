using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu025.Algorithms;
using Kujikatsu025.Collections;
using Kujikatsu025.Extensions;
using Kujikatsu025.Numerics;
using Kujikatsu025.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu025.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc113/tasks/abc113_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (prefecturesCount, citiesCount) = inputStream.ReadValue<int, int>();
            var cities = Enumerable.Repeat(0, prefecturesCount + 1).Select(_ => new List<City>()).ToArray();
            var ids = new string[citiesCount];

            for (int i = 0; i < citiesCount; i++)
            {
                var (p, y) = inputStream.ReadValue<int, int>();
                cities[p].Add(new City(p, y, i));
            }

            foreach (var citiesInPref in cities)
            {
                citiesInPref.Sort();
                int count = 1;
                foreach (var city in citiesInPref)
                {
                    ids[city.Order] = $"{city.PrefectureID:000000}{count++:000000}";
                }
            }

            foreach (var id in ids)
            {
                yield return id;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct City : IComparable<City>
        {
            public int PrefectureID { get; }
            public int Year { get; }
            public int Order { get; }

            public City(int prefectureID, int year, int order)
            {
                PrefectureID = prefectureID;
                Year = year;
                Order = order;
            }

            public void Deconstruct(out int prefectureID, out int year) => (prefectureID, year) = (PrefectureID, Year);
            public override string ToString() => $"{nameof(PrefectureID)}: {PrefectureID}, {nameof(Year)}: {Year}";

            public int CompareTo([AllowNull] City other) => Year - other.Year;
        }
    }
}
