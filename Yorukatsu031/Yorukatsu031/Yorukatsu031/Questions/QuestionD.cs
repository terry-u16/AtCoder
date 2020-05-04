using Yorukatsu031.Questions;
using Yorukatsu031.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu031.Questions
{
    /// <summary>
    /// ABC113 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var citiesCount = nm[1];

            var cities = new Dictionary<int, List<City>>();
            

            for (int i = 0; i < citiesCount; i++)
            {
                var py = inputStream.ReadIntArray();
                var city = new City(py[0], py[1], i);
                if (cities.ContainsKey(city.Prefecture))
                {
                    cities[city.Prefecture].Add(city);
                }
                else
                {
                    cities.Add(city.Prefecture, new List<City>() { city });
                }
            }

            var ids = new string[citiesCount];

            foreach (var pair in cities)
            {
                var citiesInPref = pair.Value;
                citiesInPref.Sort();
                for (int i = 0; i < citiesInPref.Count; i++)
                {
                    var city = citiesInPref[i];
                    ids[city.OriginalOrder] = city.ToString(i + 1);
                }
            }

            foreach (var id in ids)
            {
                yield return id;
            }
        }

        struct City : IComparable<City>
        {
            public int Prefecture { get; }
            public int Year { get; }
            public int OriginalOrder { get; }

            public City(int prefecture, int year, int originalOrder)
            {
                Prefecture = prefecture;
                Year = year;
                OriginalOrder = originalOrder;
            }

            public string ToString(int order) => $"{Prefecture:000000}{order:000000}";

            public int CompareTo(City other) => Year.CompareTo(other.Year);
        }
    }
}
