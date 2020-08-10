using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200810.Algorithms;
using Training20200810.Collections;
using Training20200810.Extensions;
using Training20200810.Numerics;
using Training20200810.Questions;

namespace Training20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/soundhound2018-summer-qual/tasks/soundhound2018_summer_qual_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (maxInt, length, distance) = inputStream.ReadValue<int, int, int>();

            var result = (long)(maxInt - distance) * (length - 1) / Math.Pow(maxInt, 2);

            if (distance != 0)
            {
                result *= 2;
            }

            yield return result;
        }
    }
}
