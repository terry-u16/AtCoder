using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200725.Algorithms;
using Training20200725.Collections;
using Training20200725.Extensions;
using Training20200725.Numerics;
using Training20200725.Questions;

namespace Training20200725.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc013/tasks/abc013_3
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (totalDays, initialManpuku) = inputStream.ReadValue<int, int>();
            var (normalCost, normalManpuku, shissoCost, shissoManpuku, hungry) = inputStream.ReadValue<int, int, int, int, int>();

            normalManpuku += hungry;
            shissoManpuku += hungry;
            long needed = (long)hungry * totalDays - initialManpuku + 1;

            long minCost = long.MaxValue;
            for (long normalMeals = 0; normalMeals <= totalDays; normalMeals++)
            {
                var last = needed - normalManpuku * normalMeals;
                var shissoMeals = Math.Max((last + shissoManpuku - 1) / shissoManpuku, 0);

                if (normalMeals + shissoMeals <= totalDays)
                {
                    minCost = Math.Min(minCost, normalCost * normalMeals + shissoCost * shissoMeals);
                }
            }

            yield return minCost;

        }
    }
}
