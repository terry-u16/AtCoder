using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu005.Algorithms;
using Kujikatsu005.Collections;
using Kujikatsu005.Extensions;
using Kujikatsu005.Numerics;
using Kujikatsu005.Questions;

namespace Kujikatsu005.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/mujin-pc-2017/tasks/mujin_pc_2017_a
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();
            var count = new Modular(1);
            var overMax = 0;

            for (int i = 1; i < x.Length; i++)
            {
                var over = Math.Max(i - (x[i - 1] + 1) / 2, 0);
                overMax = Math.Max(overMax, over);
                count *= new Modular(i + 1 - overMax);
            }

            yield return count.Value;
        }
    }
}
