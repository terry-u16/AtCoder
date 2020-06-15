using Kujikatsu001.Questions;
using Kujikatsu001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu001.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc088/tasks/arc088_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var xy = inputStream.ReadLongArray();
            var x = xy[0];
            var y = xy[1];

            int i;
            for (i = 0; x <= y; i++)
            {
                x <<= 1;
            }

            yield return i;
        }
    }
}
