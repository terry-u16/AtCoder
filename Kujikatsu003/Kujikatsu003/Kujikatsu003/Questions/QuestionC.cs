using Kujikatsu003.Questions;
using Kujikatsu003.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu003.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc029/tasks/agc029_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var blackCount = 0;
            long sum = 0;

            foreach (var c in s)
            {
                if (c == 'B')
                {
                    blackCount++;
                }
                else
                {
                    sum += blackCount;
                }
            }

            yield return sum;
        }
    }
}
