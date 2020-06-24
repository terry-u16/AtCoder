using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu010.Algorithms;
using Kujikatsu010.Collections;
using Kujikatsu010.Extensions;
using Kujikatsu010.Numerics;
using Kujikatsu010.Questions;

namespace Kujikatsu010.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc114/tasks/abc114_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return Get753(n, 0, false, false, false);
        }

        long Get753(long max, long current, bool seven, bool five, bool three)
        {
            if (current > max)
            {
                return 0;
            }
            long count = 0;

            if (seven && five && three)
            {
                count++;
            }

            count += Get753(max, current * 10 + 7, true, five, three);
            count += Get753(max, current * 10 + 5, seven, true, three);
            count += Get753(max, current * 10 + 3, seven, five, true);

            return count;
        }
    }
}
