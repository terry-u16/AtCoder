using Training20200612.Questions;
using Training20200612.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200612.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nikkei2019-qual/tasks/nikkei2019_qual_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var dishes = new Dish[n];

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                dishes[i] = new Dish(ab[0], ab[1]);
            }

            Array.Sort(dishes);

            long advantage = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    advantage += dishes[i].Takahashi;
                }
                else
                {
                    advantage -= dishes[i].Aoki;
                }
            }

            yield return advantage;
        }

        struct Dish : IComparable<Dish>
        {
            public long Takahashi { get; }
            public long Aoki { get; }

            public Dish(long takahashi, long aoki)
            {
                Takahashi = takahashi;
                Aoki = aoki;
            }

            public int CompareTo(Dish other) => -(Takahashi + Aoki).CompareTo(other.Takahashi + other.Aoki);
        }
    }
}
