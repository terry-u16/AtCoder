using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_m
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (children, candies) = inputStream.ReadValue<int, int>();
            var limits = inputStream.ReadIntArray();

            var counts = new Modular[children + 1, candies + 1];
            counts[0, 0] = 1;

            for (int child = 1; child <= children; child++)
            {
                var prefixSum = Modular.Zero;
                for (int distributed = 0; distributed <= candies; distributed++)
                {
                    prefixSum += counts[child - 1, distributed];
                    if (distributed - limits[child - 1] - 1 >= 0)
                    {
                        prefixSum -= counts[child - 1, distributed - limits[child - 1] - 1];
                    }
                    counts[child, distributed] = prefixSum;
                }
            }

            yield return counts[children, candies];
        }
    }
}
