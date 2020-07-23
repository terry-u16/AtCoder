using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc017/tasks/abc017_3
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (dungeons, jewels) = inputStream.ReadValue<int, int>();
            var total = 0;
            var toExcludes = new int[jewels + 1];

            for (int i = 0; i < dungeons; i++)
            {
                var (left, right, score) = inputStream.ReadValue<int, int, int>();
                left--;
                right--;
                total += score;
                toExcludes[left] += score;
                toExcludes[right + 1] -= score;
            }

            for (int i = 0; i < jewels; i++)
            {
                toExcludes[i + 1] += toExcludes[i];
            }

            var max = 0;
            for (int i = 0; i < jewels; i++)
            {
                max = Math.Max(max, total - toExcludes[i]);
            }

            yield return max;
        }
    }
}
