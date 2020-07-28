using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu043.Algorithms;
using Kujikatsu043.Collections;
using Kujikatsu043.Extensions;
using Kujikatsu043.Numerics;
using Kujikatsu043.Questions;

namespace Kujikatsu043.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/cf16-final/tasks/codefestival_2016_final_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            int max;
            for (max = 1; true; max++)
            {
                if (max * (max + 1) / 2 >= n)
                {
                    break;
                }
            }

            var over = max * (max + 1) / 2 - n;
            for (int i = 1; i <= max; i++)
            {
                if (i != over)
                {
                    yield return i;
                }
            }
        }
    }
}
