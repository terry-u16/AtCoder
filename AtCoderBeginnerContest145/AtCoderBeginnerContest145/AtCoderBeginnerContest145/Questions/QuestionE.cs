using AtCoderBeginnerContest145.Questions;
using AtCoderBeginnerContest145.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AtCoderBeginnerContest145.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nt = inputStream.ReadIntArray();
            var n = nt[0];
            var t = nt[1];

            var dishes = new Dish[n];
            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                dishes[i] = new Dish(ab[0], ab[1]);
            }

            Array.Sort(dishes);
            var satisfactions = new int[t + 3000, n + 1];

            for (int time = 0; time < t + 3000; time++)
            {
                for (int availableDishIndex = 1; availableDishIndex <= n; availableDishIndex++)
                {
                    var dish = dishes[availableDishIndex - 1];

                    // 食べる
                    if (time >= dish.Time && time - dish.Time < t)
                    {
                        UpdateWhenLarge(ref satisfactions[time, availableDishIndex], satisfactions[time - dish.Time, availableDishIndex - 1] + dish.Deliciousness);
                    }

                    // 食べない
                    UpdateWhenLarge(ref satisfactions[time, availableDishIndex], satisfactions[time, availableDishIndex - 1]);
                }
            }

            var max = 0;
            for (int time = t; time < t + 3000; time++)
            {
                max = Math.Max(max, satisfactions[time, n]);
            }

            yield return max;
        }

        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }

        public static void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }

    struct Dish : IComparable<Dish>
    {
        public int Time { get; }
        public int Deliciousness { get; set; }

        public Dish(int time, int deliciousness)
        {
            Time = time;
            Deliciousness = deliciousness;
        }

        public override string ToString() => $"Time{Time}, Deliciousness:{Deliciousness}";

        public int CompareTo(Dish other) => Time.CompareTo(other.Time);
    }
}
