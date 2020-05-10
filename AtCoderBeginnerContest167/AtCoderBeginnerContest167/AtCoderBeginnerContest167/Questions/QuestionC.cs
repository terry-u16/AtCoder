using AtCoderBeginnerContest167.Algorithms;
using AtCoderBeginnerContest167.Collections;
using AtCoderBeginnerContest167.Questions;
using AtCoderBeginnerContest167.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest167.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m, x) = inputStream.ReadValue<int, int, int>();

            var books = new Book[n];
            for (int i = 0; i < n; i++)
            {
                var ac = inputStream.ReadIntArray();
                var c = ac[0];
                var a = ac.Skip(1).ToArray();
                books[i] = new Book(c, a);
            }

            var minCost = int.MaxValue;
            for (int flag = 0; flag < 1 << books.Length; flag++)
            {
                var cost = 0;
                var learn = new int[m];
                for (int book = 0; book < books.Length; book++)
                {
                    if (((1 << book) & flag) > 0)
                    {
                        cost += books[book].Cost;
                        for (int language = 0; language < learn.Length; language++)
                        {
                            learn[language] += books[book].Learns[language];
                        }
                    }
                }

                if (learn.All(l => l >= x))
                {
                    minCost = Math.Min(cost, minCost);
                }
            }

            yield return minCost == int.MaxValue ? -1 : minCost;
        }

        struct Book
        {
            public int Cost { get; }
            public int[] Learns { get; }

            public Book(int cost, int[] learns)
            {
                Cost = cost;
                Learns = learns;
            }
        }
    }
}
