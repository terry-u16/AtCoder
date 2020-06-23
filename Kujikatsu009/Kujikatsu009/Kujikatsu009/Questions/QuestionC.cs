using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/cf16-final/tasks/codefestival_2016_final_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var sum = 0;
            var questionSet = new HashSet<int>();

            for (int i = 1; sum < n; i++)
            {
                sum += i;
                questionSet.Add(i);
            }

            if (sum - n > 0)
            {
                questionSet.Remove(sum - n);
            }

            foreach (var question in questionSet)
            {
                yield return question;
            }
        }
    }
}
