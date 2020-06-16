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
    /// https://atcoder.jp/contests/panasonic2020/tasks/panasonic2020_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadLongArray();
            var h = hw[0];
            var w = hw[1];

            if (h == 1 || w == 1)
            {
                yield return 1;
            }
            else
            {
                yield return (h * w + 1) / 2;
            }
        }
    }
}
