using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200824.Algorithms;
using Training20200824.Collections;
using Training20200824.Extensions;
using Training20200824.Numerics;
using Training20200824.Questions;

namespace Training20200824.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2012yo/tasks/joi2012yo_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int None = 0;
            const int Tomato = 1;
            const int Cream = 2;
            const int Basil = 3;

            var (totalDays, decided) = inputStream.ReadValue<int, int>();
            var plan = new int[totalDays];
            for (int i = 0; i < decided; i++)
            {
                var (day, type) = inputStream.ReadValue<int, int>();
                day--;
                plan[day] = type;
            }

            Modular.Mod = 10000;
            var counts = new Modular[totalDays + 1, 4, 4];
            counts[0, None, None] = 1;

            for (int day = 0; day < totalDays; day++)
            {
                if (plan[day] == 0)
                {
                    for (int dayBefore = None; dayBefore <= Basil; dayBefore++)
                    {
                        for (int yesterday = None; yesterday <= Basil; yesterday++)
                        {
                            for (int today = Tomato; today <= Basil; today++)
                            {
                                if (dayBefore == None || dayBefore != yesterday || yesterday != today)
                                {
                                    counts[day + 1, yesterday, today] += counts[day, dayBefore, yesterday];
                                }
                            }
                        }
                    }
                }
                else
                {
                    var today = plan[day];
                    for (int dayBefore = None; dayBefore <= Basil; dayBefore++)
                    {
                        for (int yesterday = None; yesterday <= Basil; yesterday++)
                        {
                            if (dayBefore == None || dayBefore != yesterday || yesterday != today)
                            {
                                counts[day + 1, yesterday, today] += counts[day, dayBefore, yesterday];
                            }
                        }
                    }
                }
            }

            var result = Modular.Zero;
            for (int dayBefore = None; dayBefore <= Basil; dayBefore++)
            {
                for (int yesterday = None; yesterday <= Basil; yesterday++)
                {
                    result += counts[totalDays, dayBefore, yesterday];
                }
            }

            yield return result;
        }
    }
}
