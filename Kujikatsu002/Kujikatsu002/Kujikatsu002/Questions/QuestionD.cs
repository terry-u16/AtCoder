using Kujikatsu002.Questions;
using Kujikatsu002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu002.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc034/tasks/agc034_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine().Replace("BC", "*");

            var aStack = 0;
            long count = 0;

            foreach (var c in s)
            {
                if (c == 'A')
                {
                    aStack++;
                }
                else if (c == '*')
                {
                    count += aStack;
                }
                else
                {
                    aStack = 0;
                }
            }

            yield return count;
        }
    }
}
