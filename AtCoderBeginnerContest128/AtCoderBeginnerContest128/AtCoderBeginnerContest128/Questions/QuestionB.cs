using AtCoderBeginnerContest128.Questions;
using AtCoderBeginnerContest128.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest128.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var restaurantCount = inputStream.ReadInt();
            var restaurants = new Restaurant[restaurantCount];
            for (int i = 0; i < restaurantCount; i++)
            {
                var sp = inputStream.ReadStringArray();
                restaurants[i] = new Restaurant(i + 1, sp[0], int.Parse(sp[1]));
            }

            foreach (var restaurant in restaurants.OrderBy(r => r.City, StringComparer.Ordinal).ThenByDescending(r => r.Score))
            {
                yield return restaurant.ID;
            }
        }

        struct Restaurant
        {
            public int ID { get; }
            public string City { get; }
            public int Score { get; }

            public Restaurant(int id, string city, int score)
            {
                ID = id;
                City = city;
                Score = score;
            }
        }
    }
}
