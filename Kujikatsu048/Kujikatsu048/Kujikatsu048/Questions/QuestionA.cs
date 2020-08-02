using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu048.Algorithms;
using Kujikatsu048.Collections;
using Kujikatsu048.Extensions;
using Kujikatsu048.Numerics;
using Kujikatsu048.Questions;

namespace Kujikatsu048.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/jsc2019-qual/tasks/jsc2019_qual_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (m, d) = inputStream.ReadValue<int, int>();
            var count = 0;
            for (int month = 1; month <= m; month++)
            {
                for (int day = 1; day <= d; day++)
                {
                    var d1 = day % 10;
                    var d10 = day / 10;
                    if (d1 >= 2 && d10 >= 2 && d1 * d10 == month)
                    {
                        count++;
                    }
                }
            }

            yield return count;
        }
    }
}
