using Yorukatsu032.Questions;
using Yorukatsu032.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu032.Questions
{
    /// <summary>
    /// ABC128 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var restaurants = new Restaurant[n];

            for (int i = 0; i < n; i++)
            {
                var sp = inputStream.ReadStringArray();
                restaurants[i] = new Restaurant(sp[0], int.Parse(sp[1]), i + 1);
            }

            foreach (var restaurant in restaurants.OrderBy(r => r.City, StringComparer.Ordinal).ThenByDescending(r => r.Score))
            {
                yield return restaurant.ID;
            }
        }

        struct Restaurant
        {
            public string City { get; }
            public int Score { get; }
            public int ID { get; }

            public Restaurant(string city, int score, int id)
            {
                City = city;
                Score = score;
                ID = id;
            }
        }
    }
}
